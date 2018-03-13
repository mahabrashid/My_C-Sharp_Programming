using System;
using System.Collections.Generic;
using System.Linq;
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
            FylePath = fylePath;
        }
        /// <summary>
        /// property is set only from local class and is a read-only accessor for other classes
        /// </summary>
        public string FyleName { get; private set; }
        /// <summary>
        /// property is set only from local class and is a read-only accessor for other classes
        /// </summary>
        public string FylePath { get; private set; }
        /// <summary>
        /// 
        /// </summary>
        public int FyleSize { get; private set; }
        
        public DateTime FyleModifiedDate { get; private set; }

        public string getRelativePath(string directoryRef)
        {
            /// absolute path minus the directoryRef from which the relative path is to be worked out
            return null;
        }

        public bool isNewerThan(Fyle comparingFyle)
        {
            /// compare the modified dates of two files and find out which one is newer
            return false;
        }
    }
}
