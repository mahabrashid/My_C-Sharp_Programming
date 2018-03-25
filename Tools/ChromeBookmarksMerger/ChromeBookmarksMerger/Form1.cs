using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChromeBookmarksMerger
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        /// <summary>
        /// get the path selected in FolderBrowserDialog
        /// </summary>
        /// <returns></returns>
        private string getSelectedFileFromDialog()
        {
            DialogResult fileBrwsrDialogRslt = openFileDialog1.ShowDialog();
            if (fileBrwsrDialogRslt == DialogResult.OK && !string.IsNullOrWhiteSpace(openFileDialog1.FileName))
            {
                return openFileDialog1.FileName;
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("No file selected", "Error");
                return null;
            }
        }

        private void btnBrwsSrcBkmrk_Click(object sender, EventArgs e)
        {
            string selectedSrcPath = getSelectedFileFromDialog();
            if (!string.IsNullOrEmpty(selectedSrcPath))
                txbxSrcBkmrk.Text = selectedSrcPath;
        }

        private void btnBrwsDestBkmrk_Click(object sender, EventArgs e)
        {
            string selectedDestPath = getSelectedFileFromDialog();
            if (!string.IsNullOrEmpty(selectedDestPath))
                txtbxDestBkmrk.Text = selectedDestPath;
        }
    }
}
