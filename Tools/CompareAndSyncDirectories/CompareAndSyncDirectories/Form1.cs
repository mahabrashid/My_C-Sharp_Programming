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

/// <summary>
/// To-Do: 
/// untrack non-critical files from the project
/// tidy up notes across all project files
/// create a pre-face info screen explaining the application, its purpose and its functionality
/// write a back-up function before overriding 'Modified' files
/// add logging feature
/// tie down screen to parent form so that they're not all over the place
/// </summary>

namespace CompareAndSyncDirectories
{
    public partial class Form1 : Form
    {
        string sourceDirectory; //the selected src path in folder browser dialog
        string destinationDirectory; //the selected dest path in folder browser dialog
        string[] srcFilePaths;  //to store file paths in source directory
        string[] destFilePaths; //to store file paths in destination directory

        FylesHandler fh;

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
            string selSrc = getSelectedPathFromFolderDialog();
            if (!string.IsNullOrEmpty(selSrc))
                txtbxSrcDir.Text = selSrc;
        }

        private void btnBrwsDstDir_Click(object sender, EventArgs e)
        {
            string selDest = getSelectedPathFromFolderDialog();
            if (!string.IsNullOrEmpty(selDest))
                txtbxDestDir.Text = selDest;
        }

        private void btnCompare_Click(object sender, EventArgs e)
        {
            try
            {
                this.sourceDirectory = txtbxSrcDir.Text;
                this.destinationDirectory = txtbxDestDir.Text;

                srcFilePaths = Directory.EnumerateFileSystemEntries(txtbxSrcDir.Text).ToArray<string>();
                destFilePaths = Directory.EnumerateFileSystemEntries(txtbxDestDir.Text).ToArray<string>();

                System.Console.WriteLine("number of srcFilePaths: " + srcFilePaths.Length);
                System.Console.WriteLine("number of destFilePaths: " + destFilePaths.Length);

                //destFilePaths array length may be 0 if the dest directory is empty 
                //but srcFilePaths array is empty, there's no file for comparison
                if ((srcFilePaths != null && srcFilePaths.Count() != 0) && destFilePaths != null)
                {
                    this.fh = new FylesHandler(srcFilePaths, destFilePaths);
                    //fh.printAllSrcfylesYet2Check();
                    //fh.printAllDestfylesYet2Check();
                    fh.compareFiles();
                    //fh.printAllDifferingFyles();
                    populateListView(fh.getDifferingFylesDict());
                }
                else
                {
                    throw new IOException("No valid source or destination file paths found or source path is empty");
                }
            }
            catch (Exception ex)
            {
                if (ex is System.ArgumentException && ex.ToString().Contains("path is not of a legal form"))
                    System.Windows.Forms.MessageBox.Show("Invalid source or destination directory, or source directory is empty", "Error");
                else if (ex is IOException)
                    System.Windows.Forms.MessageBox.Show(ex.Message);
                else
                    System.Windows.Forms.MessageBox.Show("Illegal execution attempt encountered, check log for details.", "Error");

                Console.WriteLine(ex.Message);
            }
        }

        private void populateListView(Dictionary<KeyValuePair<Fyle, Fyle>, string> unmatchedSrcDestFylesDict)
        {
            listViewSrcFiles.Items.Clear();
            listViewDestFiles.Items.Clear();

            foreach (KeyValuePair<KeyValuePair<Fyle, Fyle>, string> unmatchedSrcDestFyle in unmatchedSrcDestFylesDict)
            {
                string difference = unmatchedSrcDestFyle.Value;
                Fyle differingSrcFyle = unmatchedSrcDestFyle.Key.Key;
                Fyle differingDestFyle = unmatchedSrcDestFyle.Key.Value;

                ///if any of the srcfyle or destfyle is null, then it's a 'new' srcfyle or destfyle, 
                ///so will only be added to its relevant listview, i.e. only src listview or only dest listview
                ///otherwise, it's a 'renamed' or 'modified' fyle and will be added to both listviews
                if (differingSrcFyle != null)
                {
                    ListViewItem srcListVwItem = new ListViewItem(new string[] { formatDiffCategoryForListView(difference, differingSrcFyle, differingDestFyle),
                                                                                    differingSrcFyle.FyleName,
                                                                                    differingSrcFyle.FyleModifiedDate.ToString(),
                                                                                    differingSrcFyle.FyleSize,
                                                                                    differingSrcFyle.AbsoluteFylePath });
                    listViewSrcFiles.Items.Add(srcListVwItem);
                }
                if (differingDestFyle != null)
                {
                    ListViewItem destListVwItem = new ListViewItem(new string[] { formatDiffCategoryForListView(difference, differingDestFyle, differingSrcFyle),
                                                                                    differingDestFyle.FyleName,
                                                                                    differingDestFyle.FyleModifiedDate.ToString(),
                                                                                    differingDestFyle.FyleSize,
                                                                                    differingDestFyle.AbsoluteFylePath });
                    listViewDestFiles.Items.Add(destListVwItem);
                }
            }
        }

        private string formatDiffCategoryForListView(string difference, Fyle comparingFyle, Fyle comparedFyle)
        {
            if (difference.Equals("Modified"))
            {
                if (comparingFyle.isNewerThan(comparedFyle))
                    return string.Concat(difference, " (newer)");
                else
                    return string.Concat(difference, " (older)");
            }
            else
                return difference;
        }

        private void listViews_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (sender.Equals(listViewSrcFiles))
            {
                btnSyncDest2Src.Enabled = false;

                if (listViewSrcFiles.SelectedItems.Count > 0)
                    btnSyncSrc2Dest.Enabled = true;
            }
            if (sender.Equals(listViewDestFiles))
            {
                btnSyncSrc2Dest.Enabled = false;

                if (listViewDestFiles.SelectedItems.Count > 0)
                    btnSyncDest2Src.Enabled = true;
            }
        }

        private void btnSync_click(object sender, EventArgs e)
        {
            try
            {
                ListView.SelectedListViewItemCollection selectedListvwItemsCollection = null;

                if (sender.Equals(btnSyncSrc2Dest))
                {
                    selectedListvwItemsCollection = listViewSrcFiles.SelectedItems;
                }
                else if (sender.Equals(btnSyncDest2Src))
                {
                    selectedListvwItemsCollection = listViewDestFiles.SelectedItems;

                }

                if (selectedListvwItemsCollection.Count < 1)
                {
                    throw new Exception("No selected item found in the list view");
                }

                foreach (ListViewItem selectedItem in selectedListvwItemsCollection)
                {
                    string difference = selectedItem.SubItems[0].Text;
                    string selectedFylePath = selectedItem.SubItems[4].Text;
                    string selectedFyleName = selectedItem.SubItems[1].Text;
                    Fyle partnerFyle = fh.getPartnerFyleFromAFylePath(selectedFylePath);

                    if (difference.Equals("Renamed") && partnerFyle != null)
                    {
                        ///for renamed fyles, replace the partner fyle name with selected fyle name i.e.(partner fyle parent path + selected fyle name)
                        Console.WriteLine("'{0} ' will BE REPLACED WITH '{1} [{2}]'", partnerFyle.AbsoluteFylePath, string.Concat(partnerFyle.FyleParentDirectory, selectedFyleName), difference);
                        File.Move(partnerFyle.AbsoluteFylePath, string.Concat(partnerFyle.FyleParentDirectory, selectedFyleName));
                    }
                    else if (difference.Contains("Modified") && partnerFyle != null)
                    {
                        //string backupPath = "";
                        //if (selectedListvwItemsCollection.Equals(listViewSrcFiles.SelectedItems))
                        //    backupPath = string.Concat(Path.GetDirectoryName(".\\"), Path.DirectorySeparatorChar.ToString(), "SRCFOLDER", selectedFylePath.Substring(sourceDirectory.Length));
                        //else if (selectedListvwItemsCollection.Equals(listViewDestFiles.SelectedItems))
                        //    backupPath = string.Concat(Path.GetDirectoryName(".\\"), Path.DirectorySeparatorChar.ToString(), "DESTFOLDER", selectedFylePath.Substring(destinationDirectory.Length));
                        //Console.WriteLine("Replace file will be backed up in {0}", backupPath);

                        ///for modified fyles, copy selected fyle path to corresponding partner fyle path with override flag on
                        Console.WriteLine("'{0} [{1}]' WILL REPLACE '{2}'", selectedFylePath, difference, partnerFyle.AbsoluteFylePath);
                        File.Copy(selectedFylePath, partnerFyle.AbsoluteFylePath, true);
                    }
                    else if (difference.Equals("New"))
                    {
                        ///for new fyles, we first determine the copying path for the new fyle based on its source and destination
                        string copyingPathForNewFyle = string.Empty;
                        ///if src fyle is being copied to dest directory, the copying path for the new fyle is (dest directory + src fyle's relative path from src directory)
                        if (selectedListvwItemsCollection.Equals(listViewSrcFiles.SelectedItems))
                            copyingPathForNewFyle = string.Concat(destinationDirectory, selectedFylePath.Substring(sourceDirectory.Length));
                        ///if dest fyle is being copied to src directory, the copying path for the new fyle is (src directory + dest fyle's relative path from dest directory)
                        else if (selectedListvwItemsCollection.Equals(listViewDestFiles.SelectedItems))
                            copyingPathForNewFyle = string.Concat(sourceDirectory, selectedFylePath.Substring(destinationDirectory.Length));

                        if (!Directory.Exists(Path.GetDirectoryName(copyingPathForNewFyle)))
                            Directory.CreateDirectory(Path.GetDirectoryName(copyingPathForNewFyle));

                        Console.WriteLine("'{0} [{1}]' will be copied into '{2}'", selectedFylePath, difference, copyingPathForNewFyle);
                        File.Copy(selectedFylePath, copyingPathForNewFyle);

                    }
                    else
                    {
                        throw new Exception("No partner fyle matched the selected item in the listview");
                    }

                    ///remove the item from Dictionary<Key<selected fyle, partner fyle>, "difference">, so when the listview is repopulated, it's excluded from the list
                    fh.removeElementFromDifferingFylesDict(selectedFylePath);
                }

                populateListView(fh.getDifferingFylesDict());
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Error");
                Console.WriteLine(ex.Message);
            }
        }
    }
}

