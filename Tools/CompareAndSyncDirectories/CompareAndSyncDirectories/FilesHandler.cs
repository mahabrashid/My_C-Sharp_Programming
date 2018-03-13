using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CompareAndSyncDirectories
{
    class FilesHandler
    {
        /// <summary>
        /// dictionary to store all source files with their corresponding attributes
        /// file paths and file names in key which is a KeyValuePair itself, and hash in value which is a string
        /// </summary>
        Dictionary<KeyValuePair<string, string>, string> srcfilesNameHashDictYet2Check = new Dictionary<KeyValuePair<string, string>, string>();
        Dictionary<KeyValuePair<string, string>, string> destfilesNameHashDictYet2Check = new Dictionary<KeyValuePair<string, string>, string>();
        /// <summary>
        /// dictionary to store all unmatched, i.e. either renamed, modified or new files, from the source files container
        /// file paths and file names in key which is a KeyValuePair itself, and a string indicating renamed, modified or new file in value
        /// </summary>
        Dictionary<KeyValuePair<string, string>, string> unmatchedSrcfilesNameHashDict = new Dictionary<KeyValuePair<string, string>, string>();
        Dictionary<KeyValuePair<string, string>, string> unmatchedDestfilesNameHashDict = new Dictionary<KeyValuePair<string, string>, string>();

        public FilesHandler(string[] srcFilePaths, string[] destFilePaths)
        {
            this.srcfilesNameHashDictYet2Check = sanitizeFiles(srcFilePaths);
            this.destfilesNameHashDictYet2Check = sanitizeFiles(destFilePaths);
        }

        /// <summary>
        /// extract all files and their attributes and hashes, and return them
        /// </summary>
        /// <param name="filePaths"></param>
        private Dictionary<KeyValuePair<string, string>, string> sanitizeFiles(string[] filePaths)
        {
            Dictionary<KeyValuePair<string, string>, string> filesPathNameHashDict = new Dictionary<KeyValuePair<string, string>, string>();

            extractParentdirFilenamesAndHashes(filesPathNameHashDict, filePaths);

            return filesPathNameHashDict;
        }
        /// <summary>
        /// check if a filepath is valid; if the path refers to a sub-directory, then iterate through the sub-directory to extract files
        /// get filenames, their directory prefixes and hashes to store in designated container
        /// </summary>
        /// <param name="pathHashDict"></param>
        /// <param name="filePaths"></param>
        private void extractParentdirFilenamesAndHashes(Dictionary<KeyValuePair<string, string>, string> pathHashDict, string[] filePaths)
        {
            foreach (string filePath in filePaths)
            {
                if (File.Exists(filePath))
                {
                    //add the filepath & filename as a key, and filehash as a value to the designated container
                    pathHashDict.Add(separateFilePathAndFilename(filePath), CalculateMD5(filePath));
                }
                //if the filepath refers to a directory
                else if (Directory.Exists(filePath))
                    //recurse through the method again
                    extractParentdirFilenamesAndHashes(pathHashDict, Directory.EnumerateFileSystemEntries(filePath).ToArray<string>());
            }
        }

        /// <summary>
        /// separate a file's parent path from its name and return as a key-value pair
        /// </summary>
        /// <param name="filepath"></param>
        /// <returns></returns>
        private KeyValuePair<string, string> separateFilePathAndFilename(string filepath)
        {
            string filename = Path.GetFileName(filepath);
            ///To-do: calculate relative path from the selected directory on the windows form for parent directory
            ///this will enable us to copy a file to a specific destination path relative to selected dest directory 
            ///as the absolute path in src and dest directories would not match between different machines or where files are backed up in different locations
            string parentDir = Directory.GetParent(filepath).ToString();

            return new KeyValuePair<string, string>(parentDir, filename);
        }

        /// <summary>
        /// public method to trigger the operation from other classes
        /// </summary>
        public void compareFiles()
        {
            //as long as there's file(s) in source-files-dictionary, keep looping, each time eliminating a file that's been checked
            if (srcfilesNameHashDictYet2Check.Count != 0)
            {
                eliminateCheckedFilesFromContainers();
                compareFiles();
            }

            //now let's also highlight anything left in destfiles-yet2check container
            processAdditionalFilesInDestfilesCollection();
        }

        /// <summary>
        /// take each of the yet2check srcFile and compare it against all yet2check dest files in corresponding containers
        /// as a file is decided as renamed, modified or new, it is removed from the both containers to avoid repeated lookup of a srcfile or against a destfile that is already been decided upon
        /// </summary>
        private void eliminateCheckedFilesFromContainers()
        {
            ///NOTE: foreach doesn't allow altering the container within the loop while still iterating,
            ///so everytime an item is removed from the container the process has to return to the calling point

            foreach (KeyValuePair<KeyValuePair<string, string>, string> srcfileHashPair in srcfilesNameHashDictYet2Check)
            {
                string srcfileParentDir = srcfileHashPair.Key.Key;
                string srcfileName = srcfileHashPair.Key.Value;
                string srcfileHash = srcfileHashPair.Value;

                foreach (KeyValuePair<KeyValuePair<string, string>, string> destfileHashPair in destfilesNameHashDictYet2Check)
                {
                    string destfileParentDir = destfileHashPair.Key.Key;
                    string destfileName = destfileHashPair.Key.Value;
                    string destfileHash = destfileHashPair.Value;

                    ///if the hashes match, then check if the names match
                    ///if the names also match, then there's no change between the files, so do nothing
                    ///else the file has been renamed, so flag this as a renamed file
                    ///finally remove the item from both containers to avoid unnecessary lookup of a srcfile or against a destfile that is already been decided upon
                    if (srcfileHash.Equals(destfileHash))//if the hashes match
                    {
                        if (!srcfileName.Equals(destfileName))//and names do not match, it must be a renamed file
                        {
                            unmatchedSrcfilesNameHashDict.Add(srcfileHashPair.Key, "Renamed");
                            unmatchedDestfilesNameHashDict.Add(destfileHashPair.Key, "Renamed");
                        }
                        //otherwise both hashes and names have matched, so the file is unchanged and doesn't need to be flagged
                        //finally remove the item from the destfiles-yet2check-dictionary
                        //and remove the item from the srcfiles-yet2check-dictionary
                        destfilesNameHashDictYet2Check.Remove(destfileHashPair.Key);
                        srcfilesNameHashDictYet2Check.Remove(srcfileHashPair.Key);
                        return; //a decision has been made, so return to the calling point
                    }

                    ///if the hashes do not match, then check if the names match
                    ///if the names match, then the file has been modified, so flag this as a modified file
                    ///else a match maybe found in next lookups, so continue the lookup process
                    else if (!srcfileHash.Equals(destfileHash))
                    {
                        if (srcfileName.Equals(destfileName))
                        {
                            unmatchedSrcfilesNameHashDict.Add(srcfileHashPair.Key, "Modified");
                            unmatchedDestfilesNameHashDict.Add(destfileHashPair.Key, "Modified");
                            destfilesNameHashDictYet2Check.Remove(destfileHashPair.Key);
                            srcfilesNameHashDictYet2Check.Remove(srcfileHashPair.Key);
                            return;
                        }
                    }
                }
                ///if the srcfile hasn't been matched against any destfiles and code gets here, then the srcfile must be a new file
                unmatchedSrcfilesNameHashDict.Add(srcfileHashPair.Key, "New");
                srcfilesNameHashDictYet2Check.Remove(srcfileHashPair.Key);
                return;
            }
        }

        private void processAdditionalFilesInDestfilesCollection()
        {
            if (destfilesNameHashDictYet2Check.Count == 0)
            {
                return;
            }
            else
            {
                foreach (KeyValuePair<KeyValuePair<string, string>, string> destfileHashPair in destfilesNameHashDictYet2Check)
                {
                    string destfileName = destfileHashPair.Key.Value;
                    unmatchedDestfilesNameHashDict.Add(destfileHashPair.Key, "New");
                    destfilesNameHashDictYet2Check.Remove(destfileHashPair.Key);
                    break;
                }
                processAdditionalFilesInDestfilesCollection();
            }
        }

        /// <summary>
        /// calculates MD5 hash for a file
        /// reference: https://stackoverflow.com/questions/10520048/calculate-md5-checksum-for-a-file/10520086#10520086
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        private string CalculateMD5(string filename)
        {
            using (var md5 = MD5.Create())
            {
                using (var stream = File.OpenRead(filename))
                {
                    var hash = md5.ComputeHash(stream);
                    return BitConverter.ToString(hash).Replace("-", string.Empty).ToLower();
                }
            }
        }

        public void printAllDifferingElementsInSrcfilesContainer()
        {
            Console.WriteLine("Differing elements in Source directory:\n************************************************");
            printAllElementsInFilesContainer(unmatchedSrcfilesNameHashDict);
        }

        public void printAllDifferingElementsInDestfilesContainer()
        {
            Console.WriteLine("Differing elements in Destination directory:\n************************************************");
            printAllElementsInFilesContainer(unmatchedDestfilesNameHashDict);
        }

        private void printAllElementsInFilesContainer(Dictionary<KeyValuePair<string, string>, string> pathHashDict)
        {
            foreach (KeyValuePair<KeyValuePair<string, string>, string> keyValue in pathHashDict)
            {
                Console.WriteLine("Filename: " + keyValue.Key.Value);
                Console.WriteLine("File parent directory: " + keyValue.Key.Key);
                Console.WriteLine("\t\tFile hash: " + keyValue.Value);
                Console.WriteLine("----------------------------------------------------------------------------------------------------");
            }
            Console.WriteLine("Total elements: " + pathHashDict.Count);
        }
    }
}
