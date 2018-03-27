using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompareAndSyncDirectories
{
    class FylesHandler
    {
        List<Fyle> srcFylesYet2CheckList = new List<Fyle>();
        List<Fyle> destFylesYet2CheckList = new List<Fyle>();

        Dictionary<KeyValuePair<Fyle, Fyle>, string> unmatchedSrcDestFylesDict = new Dictionary<KeyValuePair<Fyle, Fyle>, string>();

        public FylesHandler(string[] srcFilePaths, string[] destFilePaths)
        {
            this.srcFylesYet2CheckList = sanitizeFyles(srcFilePaths);
            this.destFylesYet2CheckList = sanitizeFyles(destFilePaths);
        }

        /// <summary>
        /// public method to trigger the operation from other classes
        /// </summary>
        public void compareFiles()
        {
            //as long as there's file(s) in source-files-dictionary, keep looping, each time eliminating a file that's been checked
            if (srcFylesYet2CheckList.Count != 0)
            {
                eliminateCheckedFilesFromContainers();
                compareFiles();
            }

            //now let's also highlight anything left in destfiles-yet2check container
            processAdditionalFilesInDestfilesCollection();
        }

        public Dictionary<KeyValuePair<Fyle, Fyle>, string> getDifferingFylesDict()
        {
            return unmatchedSrcDestFylesDict;
        }

        public void removeElementFromDifferingFylesDict(string enquiringfylePath)
        {
           foreach (KeyValuePair<KeyValuePair<Fyle, Fyle>, string> unmatchedSrcDestFylesKey in unmatchedSrcDestFylesDict)
            {
                Fyle differingScrFyle = unmatchedSrcDestFylesKey.Key.Key;
                Fyle differingDestFyle = unmatchedSrcDestFylesKey.Key.Value;

                if (differingScrFyle != null && enquiringfylePath.Equals(differingScrFyle.AbsoluteFylePath))
                {
                    unmatchedSrcDestFylesDict.Remove(unmatchedSrcDestFylesKey.Key);
                    return;
                }
                else if (differingDestFyle != null && enquiringfylePath.Equals(differingDestFyle.AbsoluteFylePath))
                {
                    unmatchedSrcDestFylesDict.Remove(unmatchedSrcDestFylesKey.Key);
                    return;
                }
            }
            
        }

        public Fyle getPartnerFyleFromAFylePath(string enquiringfylePath)
        {
            foreach (KeyValuePair<KeyValuePair<Fyle, Fyle>, string> unmatchedSrcDestFylesKey in unmatchedSrcDestFylesDict)
            {
                Fyle differingScrFyle = unmatchedSrcDestFylesKey.Key.Key;
                Fyle differingDestFyle = unmatchedSrcDestFylesKey.Key.Value;

                if (differingScrFyle != null && enquiringfylePath.Equals(differingScrFyle.AbsoluteFylePath))
                    return differingDestFyle;
                else if (differingDestFyle != null && enquiringfylePath.Equals(differingDestFyle.AbsoluteFylePath))
                    return differingScrFyle;
            }
            return null;
        }

        public void printAllSrcfylesYet2Check()
        {
            Console.WriteLine("Elements in Source directory:\n************************************************");
            printAllElementsInFylesContainer(srcFylesYet2CheckList);
        }

        public void printAllDestfylesYet2Check()
        {
            Console.WriteLine("Elements in Destination directory:\n************************************************");
            printAllElementsInFylesContainer(destFylesYet2CheckList);
        }

        public void printAllDifferingFyles()
        {
            foreach (KeyValuePair<KeyValuePair<Fyle, Fyle>, string> unmatchedSrcDestFyle in unmatchedSrcDestFylesDict)
            {
                string difference = unmatchedSrcDestFyle.Value;
                Fyle differingScrFyle = unmatchedSrcDestFyle.Key.Key;
                Fyle differingDestFyle = unmatchedSrcDestFyle.Key.Value;

                Console.WriteLine("===============");
                Console.WriteLine("|" + difference + "|");
                Console.WriteLine("===============");
                if (differingScrFyle != null)
                {
                    Console.WriteLine("Differing Src file:");
                    printFyleAttributes(differingScrFyle);
                    Console.WriteLine("----------------------------------------------------------------------------------------------------");
                }
                if (differingDestFyle != null)
                {
                    Console.WriteLine("Differing Dest file:");
                    printFyleAttributes(differingDestFyle);
                    Console.WriteLine("----------------------------------------------------------------------------------------------------");
                }
            }
            Console.WriteLine("Total elements: " + unmatchedSrcDestFylesDict.Count);
            Console.WriteLine("----------------------------------------------------------------------------------------------------");
        }

        private void printAllElementsInFylesContainer(List<Fyle> fylesList)
        {
            foreach (Fyle fyle in fylesList)
            {
                printFyleAttributes(fyle);
            }
            Console.WriteLine("Total elements: " + fylesList.Count);
            Console.WriteLine("----------------------------------------------------------------------------------------------------");
        }

        private void printFyleAttributes(Fyle fyle)
        {
            Console.WriteLine("Filename: " + fyle.FyleName);
            Console.WriteLine("File parent directory: " + fyle.FyleParentDirectory);
        }

        /// <summary>
        /// extract all files and their attributes and hashes, and return them
        /// </summary>
        /// <param name="filePaths"></param>
        private List<Fyle> sanitizeFyles(string[] filePaths)
        {
            List<Fyle> fylesList = new List<Fyle>();
            extractFilesFromDirectories(fylesList, filePaths);
            return fylesList;
        }

        /// <summary>
        /// check if a filepath is valid; if the path refers to a sub-directory, then iterate through the sub-directory to extract files
        /// get filenames, their directory prefixes and hashes to store in designated container
        /// </summary>
        /// <param name="pathHashDict"></param>
        /// <param name="filePaths"></param>
        private void extractFilesFromDirectories(List<Fyle> filesList, string[] filePaths)
        {
            foreach (string filePath in filePaths)
            {
                if (File.Exists(filePath))
                {
                    //add the filepath & filename as a key, and filehash as a value to the designated container
                    filesList.Add(new Fyle(filePath));
                }
                //if the filepath refers to a directory
                else if (Directory.Exists(filePath))
                    //recurse through the method again
                    extractFilesFromDirectories(filesList, Directory.EnumerateFileSystemEntries(filePath).ToArray<string>());
            }
        }

        /// <summary>
        /// take each of the yet2check srcFile and compare it against all yet2check dest files in corresponding containers
        /// as a file is decided as renamed, modified or new, it is removed from the both containers to avoid repeated lookup of a srcfile or against a destfile that is already been decided upon
        /// </summary>
        private void eliminateCheckedFilesFromContainers()
        {
            ///NOTE: foreach doesn't allow altering the container within the loop while still iterating,
            ///so everytime an item is removed from the container the process has to return to the calling point

            foreach (Fyle srcfyle in srcFylesYet2CheckList)
            {
                foreach (Fyle destfyle in destFylesYet2CheckList)
                {
                    ///if the hashes match, then check if the names match
                    ///if the names also match, then there's no change between the files, so do nothing
                    ///else the file has been renamed, so flag this as a renamed file
                    ///finally remove the item from both containers to avoid unnecessary lookup of a srcfile or against a destfile that is already been decided upon
                    if (srcfyle.FyleHash.Equals(destfyle.FyleHash))//if the hashes match
                    {
                        if (!srcfyle.FyleName.Equals(destfyle.FyleName))//and names do not match, it must be a renamed file
                        {
                            unmatchedSrcDestFylesDict.Add(new KeyValuePair<Fyle, Fyle>(srcfyle, destfyle), "Renamed");
                        }
                        //otherwise both hashes and names have matched, so the file is unchanged and doesn't need to be flagged

                        //finally remove the item from the destfiles-yet2check-dictionary
                        //and remove the item from the srcfiles-yet2check-dictionary
                        destFylesYet2CheckList.Remove(destfyle);
                        srcFylesYet2CheckList.Remove(srcfyle);
                        return; //a decision has been made, so return to the calling point
                    }

                    ///if the hashes do not match, then check if the names match
                    ///if the names match, then the file has been modified, so flag this as a modified file
                    ///else a match maybe found in next lookups of destfiles collection, so continue the lookup process
                    else if (!srcfyle.FyleHash.Equals(destfyle.FyleHash))
                    {
                        if (srcfyle.FyleName.Equals(destfyle.FyleName))
                        {
                            unmatchedSrcDestFylesDict.Add(new KeyValuePair<Fyle, Fyle>(srcfyle, destfyle), "Modified");
                            destFylesYet2CheckList.Remove(destfyle);
                            srcFylesYet2CheckList.Remove(srcfyle);
                            return;
                        }
                    }
                }
                ///if the srcfile hasn't been matched against any destfiles and code gets here, then the srcfile must be a new file
                unmatchedSrcDestFylesDict.Add(new KeyValuePair<Fyle, Fyle>(srcfyle, null), "New");
                srcFylesYet2CheckList.Remove(srcfyle);

                return;
            }
        }

        private void processAdditionalFilesInDestfilesCollection()
        {
            if (destFylesYet2CheckList.Count == 0)
            {
                return;
            }
            else
            {
                foreach (Fyle destfyle in destFylesYet2CheckList)
                {
                    unmatchedSrcDestFylesDict.Add(new KeyValuePair<Fyle, Fyle>(null, destfyle), "New");
                    destFylesYet2CheckList.Remove(destfyle);
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
            using (var md5 = System.Security.Cryptography.MD5.Create())
            {
                using (var stream = File.OpenRead(filename))
                {
                    var hash = md5.ComputeHash(stream);
                    return BitConverter.ToString(hash).Replace("-", string.Empty).ToLower();
                }
            }
        }

    }
}
