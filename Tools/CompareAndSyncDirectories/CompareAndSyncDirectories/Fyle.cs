using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CompareAndSyncDirectories
{
    /// <summary>
    /// Such class name is to avoid conflict with built-in File class
    /// Thi class creates file objects with useful attributes, such filename, absolute and relative paths, size, modified date
    /// </summary>
    class Fyle
    {
        public Fyle(string fylePath)
        {
            if (File.Exists(fylePath))
            {
                this.FyleName = Path.GetFileName(fylePath);
                this.AbsoluteFylePath = fylePath;
                this.FyleParentDirectory = string.Concat(Directory.GetParent(fylePath).ToString(), Path.DirectorySeparatorChar.ToString());
                this.FyleModifiedDate = File.GetLastWriteTime(fylePath);
                this._fyleSize = new FileInfo(fylePath).Length;
                this.FyleHash = CalculateMD5(fylePath);
            }
        }
        /// <summary>
        /// returns the file name
        /// </summary>
        /// property is set only from local class and is a read-only accessor for other classes
        public string FyleName { get; private set; }
        /// <summary>
        /// returns the absolute path of a Fyle
        /// </summary>
        /// property is set only from local class and is a read-only accessor for other classes
        public string AbsoluteFylePath { get; private set; }
        /// <summary>
        /// returns the size of a Fyle
        /// </summary>
        private long _fyleSize;
        public string FyleSize
        {
            get
            {
                if (this._fyleSize > 1024 * 1024 * 1024)
                    return _fyleSize / 1024 * 1024 + " GB";
                if (this._fyleSize > 1024 * 1024)
                    return _fyleSize / 1024 * 1024 + " MB";
                else if (this._fyleSize > 1024)
                    return _fyleSize / 1024 + " KB";
                else
                    return _fyleSize + " Bytes";
            }
        }
        /// <summary>
        /// returns the parent directory of a Fyle
        /// </summary>
        /// property is set only from local class and is a read-only accessor for other classes
        public string FyleParentDirectory { get; private set; }
        /// <summary>
        /// returns the modified date of a Fyle
        /// </summary>
        /// property is set only from local class and is a read-only accessor for other classes
        public DateTime FyleModifiedDate { get; private set; }
        /// <summary>
        /// 
        /// </summary>
        public string FyleHash { get; private set; }

        /// <summary>
        /// returns the relative path of a Fyle in relation to an absolute path passed as parameter
        /// </summary>
        /// <param name="directoryRef"></param>
        /// <returns></returns>
        public string getRelativePath(string directoryRef)
        {
            /// absolute path minus the directoryRef from which the relative path is to be worked out
            return AbsoluteFylePath.Substring(directoryRef.Length - 1);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="comparingFyle"></param>
        /// <returns></returns>
        public bool isNewerThan(Fyle comparingFyle)
        {
            /// compare the modified dates of two files and find out which one is newer
            if (this.FyleModifiedDate > comparingFyle.FyleModifiedDate)
                return true;
            else
                return false;
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
    }
}
