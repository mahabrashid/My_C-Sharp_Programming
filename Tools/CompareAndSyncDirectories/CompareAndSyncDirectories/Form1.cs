using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CompareAndSyncDirectories
{
    public partial class Form1 : Form
    {
        string[] srcFilePaths;  //to store file paths in source directory
        string[] destFilePaths; //to store file paths in destination directory

        public Form1()
        {
            InitializeComponent();
            System.Console.WriteLine("Form loaded correctly");
        }

        /// <summary>
        /// get the path selected in FolderBrowserDialog
        /// </summary>
        /// <returns></returns>
        private string getSelectedPathFromFolderDialog()
        {
            DialogResult fldrBrwsrDialogRslt = folderBrowserDialog1.ShowDialog();
            if (fldrBrwsrDialogRslt == DialogResult.OK && !string.IsNullOrWhiteSpace(folderBrowserDialog1.SelectedPath))
            {
                return folderBrowserDialog1.SelectedPath;
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("No directory selected", "Error");
                return null;
            }
        }

        private void btnBrwsSrcDir_Click(object sender, EventArgs e)
        {
            string selectedSrcPath = getSelectedPathFromFolderDialog();
            if (!string.IsNullOrEmpty(selectedSrcPath))
                txtbxSrcDir.Text = selectedSrcPath;
        }

        private void btnBrwsDstDir_Click(object sender, EventArgs e)
        {
            string selectedDestPath = getSelectedPathFromFolderDialog();
            if (!string.IsNullOrEmpty(selectedDestPath))
                txtbxDestDir.Text = selectedDestPath;
        }

        private void btnCompare_Click(object sender, EventArgs e)
        {
            try
            {
                srcFilePaths = Directory.EnumerateFileSystemEntries(txtbxSrcDir.Text).ToArray<string>();
                destFilePaths = Directory.EnumerateFileSystemEntries(txtbxDestDir.Text).ToArray<string>();

                System.Console.WriteLine("number of srcFilePaths: " + srcFilePaths.Length);
                System.Console.WriteLine("number of destFilePaths: " + destFilePaths.Length);

                //destFilePaths array length may be 0 if the dest directory is empty 
                //but srcFilePaths array is empty, there's no file for comparison
                if ((srcFilePaths != null || srcFilePaths.Count() != 0) && destFilePaths != null)
                {
                    FilesHandler fh = new FilesHandler(srcFilePaths, destFilePaths);
                    fh.compareFiles();
                    fh.printAllDifferingElementsInSrcfilesContainer();
                    fh.printAllDifferingElementsInDestfilesContainer();
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("Invalid source or destination directory, or source directory is empty", "Error");
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Either source or destination is not selected correctly", "Error");
                Console.WriteLine(ex.Message);
            }
        }
    }
}
