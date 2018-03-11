namespace CompareAndSyncDirectories
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem(new string[] {
            "Apple",
            "Pie",
            "Tart"}, -1);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.lblSrcDir = new System.Windows.Forms.Label();
            this.txtbxSrcDir = new System.Windows.Forms.TextBox();
            this.tlTip = new System.Windows.Forms.ToolTip(this.components);
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.btnBrwsSrcDir = new System.Windows.Forms.Button();
            this.lblDestDir = new System.Windows.Forms.Label();
            this.txtbxDestDir = new System.Windows.Forms.TextBox();
            this.btnBrwsDstDir = new System.Windows.Forms.Button();
            this.btnCompare = new System.Windows.Forms.Button();
            this.listViewSrcFiles = new System.Windows.Forms.ListView();
            this.colHdrLstVwSrcFDiff = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colHdrLstVwSrcFName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colHdrLstVwSrcFPath = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.item1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.item2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.item3ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.subitem31ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.subitem32ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listViewDestFiles = new System.Windows.Forms.ListView();
            this.btnSyncDest2Src = new System.Windows.Forms.Button();
            this.btnSyncSrc2Dest = new System.Windows.Forms.Button();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblSrcDir
            // 
            this.lblSrcDir.AutoSize = true;
            this.lblSrcDir.Location = new System.Drawing.Point(13, 12);
            this.lblSrcDir.Name = "lblSrcDir";
            this.lblSrcDir.Size = new System.Drawing.Size(57, 13);
            this.lblSrcDir.TabIndex = 0;
            this.lblSrcDir.Text = "Source Dir";
            this.tlTip.SetToolTip(this.lblSrcDir, "Select a source directory");
            // 
            // txtbxSrcDir
            // 
            this.txtbxSrcDir.Location = new System.Drawing.Point(16, 28);
            this.txtbxSrcDir.Name = "txtbxSrcDir";
            this.txtbxSrcDir.Size = new System.Drawing.Size(333, 20);
            this.txtbxSrcDir.TabIndex = 1;
            this.tlTip.SetToolTip(this.txtbxSrcDir, "Select a source directory");
            // 
            // tlTip
            // 
            this.tlTip.UseAnimation = false;
            // 
            // folderBrowserDialog1
            // 
            this.folderBrowserDialog1.SelectedPath = "C:\\Users\\marashid\\Documents\\Personal_Stuff\\Personal Training and Development\\Visu" +
    "al Studio Projects\\CompareAndSyncDirectories\\CompareAndSyncDirectories\\test file" +
    "s";
            this.folderBrowserDialog1.ShowNewFolderButton = false;
            // 
            // btnBrwsSrcDir
            // 
            this.btnBrwsSrcDir.Location = new System.Drawing.Point(355, 28);
            this.btnBrwsSrcDir.Name = "btnBrwsSrcDir";
            this.btnBrwsSrcDir.Size = new System.Drawing.Size(30, 23);
            this.btnBrwsSrcDir.TabIndex = 2;
            this.btnBrwsSrcDir.Text = "...";
            this.btnBrwsSrcDir.UseVisualStyleBackColor = true;
            this.btnBrwsSrcDir.Click += new System.EventHandler(this.btnBrwsSrcDir_Click);
            // 
            // lblDestDir
            // 
            this.lblDestDir.AutoSize = true;
            this.lblDestDir.Location = new System.Drawing.Point(16, 65);
            this.lblDestDir.Name = "lblDestDir";
            this.lblDestDir.Size = new System.Drawing.Size(76, 13);
            this.lblDestDir.TabIndex = 3;
            this.lblDestDir.Text = "Destination Dir";
            // 
            // txtbxDestDir
            // 
            this.txtbxDestDir.Location = new System.Drawing.Point(16, 83);
            this.txtbxDestDir.Name = "txtbxDestDir";
            this.txtbxDestDir.Size = new System.Drawing.Size(333, 20);
            this.txtbxDestDir.TabIndex = 4;
            // 
            // btnBrwsDstDir
            // 
            this.btnBrwsDstDir.Location = new System.Drawing.Point(356, 83);
            this.btnBrwsDstDir.Name = "btnBrwsDstDir";
            this.btnBrwsDstDir.Size = new System.Drawing.Size(29, 23);
            this.btnBrwsDstDir.TabIndex = 5;
            this.btnBrwsDstDir.Text = "...";
            this.btnBrwsDstDir.UseVisualStyleBackColor = true;
            this.btnBrwsDstDir.Click += new System.EventHandler(this.btnBrwsDstDir_Click);
            // 
            // btnCompare
            // 
            this.btnCompare.Location = new System.Drawing.Point(283, 128);
            this.btnCompare.Name = "btnCompare";
            this.btnCompare.Size = new System.Drawing.Size(102, 23);
            this.btnCompare.TabIndex = 6;
            this.btnCompare.Text = "Compare Files";
            this.btnCompare.UseVisualStyleBackColor = true;
            this.btnCompare.Click += new System.EventHandler(this.btnCompare_Click);
            // 
            // listViewSrcFiles
            // 
            this.listViewSrcFiles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colHdrLstVwSrcFDiff,
            this.colHdrLstVwSrcFName,
            this.colHdrLstVwSrcFPath});
            this.listViewSrcFiles.ContextMenuStrip = this.contextMenuStrip1;
            this.listViewSrcFiles.FullRowSelect = true;
            this.listViewSrcFiles.GridLines = true;
            this.listViewSrcFiles.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1});
            this.listViewSrcFiles.Location = new System.Drawing.Point(15, 172);
            this.listViewSrcFiles.Name = "listViewSrcFiles";
            this.listViewSrcFiles.Size = new System.Drawing.Size(369, 118);
            this.listViewSrcFiles.TabIndex = 8;
            this.listViewSrcFiles.UseCompatibleStateImageBehavior = false;
            this.listViewSrcFiles.View = System.Windows.Forms.View.Details;
            // 
            // colHdrLstVwSrcFDiff
            // 
            this.colHdrLstVwSrcFDiff.Text = "Difference";
            this.colHdrLstVwSrcFDiff.Width = 82;
            // 
            // colHdrLstVwSrcFName
            // 
            this.colHdrLstVwSrcFName.Text = "File Name";
            this.colHdrLstVwSrcFName.Width = 123;
            // 
            // colHdrLstVwSrcFPath
            // 
            this.colHdrLstVwSrcFPath.Text = "File Path";
            this.colHdrLstVwSrcFPath.Width = 176;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.item1ToolStripMenuItem,
            this.item2ToolStripMenuItem,
            this.item3ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.contextMenuStrip1.Size = new System.Drawing.Size(181, 92);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItem1.Text = "toolStripMenuItem1";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItem2.Text = "toolStripMenuItem2";
            // 
            // item1ToolStripMenuItem
            // 
            this.item1ToolStripMenuItem.Name = "item1ToolStripMenuItem";
            this.item1ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.item1ToolStripMenuItem.Text = "item1";
            // 
            // item2ToolStripMenuItem
            // 
            this.item2ToolStripMenuItem.Name = "item2ToolStripMenuItem";
            this.item2ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.item2ToolStripMenuItem.Text = "item2";
            // 
            // item3ToolStripMenuItem
            // 
            this.item3ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.subitem31ToolStripMenuItem,
            this.subitem32ToolStripMenuItem});
            this.item3ToolStripMenuItem.Name = "item3ToolStripMenuItem";
            this.item3ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.item3ToolStripMenuItem.Text = "item3";
            // 
            // subitem31ToolStripMenuItem
            // 
            this.subitem31ToolStripMenuItem.Name = "subitem31ToolStripMenuItem";
            this.subitem31ToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.subitem31ToolStripMenuItem.Text = "subitem3.1";
            // 
            // subitem32ToolStripMenuItem
            // 
            this.subitem32ToolStripMenuItem.Name = "subitem32ToolStripMenuItem";
            this.subitem32ToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.subitem32ToolStripMenuItem.Text = "subitem3.2";
            // 
            // listViewDestFiles
            // 
            this.listViewDestFiles.Location = new System.Drawing.Point(16, 343);
            this.listViewDestFiles.Name = "listViewDestFiles";
            this.listViewDestFiles.Size = new System.Drawing.Size(369, 74);
            this.listViewDestFiles.TabIndex = 9;
            this.listViewDestFiles.UseCompatibleStateImageBehavior = false;
            // 
            // btnSyncDest2Src
            // 
            this.btnSyncDest2Src.Enabled = false;
            this.btnSyncDest2Src.Image = ((System.Drawing.Image)(resources.GetObject("btnSyncDest2Src.Image")));
            this.btnSyncDest2Src.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSyncDest2Src.Location = new System.Drawing.Point(205, 296);
            this.btnSyncDest2Src.Name = "btnSyncDest2Src";
            this.btnSyncDest2Src.Size = new System.Drawing.Size(70, 29);
            this.btnSyncDest2Src.TabIndex = 11;
            this.btnSyncDest2Src.Text = "Sync";
            this.btnSyncDest2Src.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnSyncDest2Src.UseVisualStyleBackColor = true;
            // 
            // btnSyncSrc2Dest
            // 
            this.btnSyncSrc2Dest.Enabled = false;
            this.btnSyncSrc2Dest.Image = ((System.Drawing.Image)(resources.GetObject("btnSyncSrc2Dest.Image")));
            this.btnSyncSrc2Dest.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSyncSrc2Dest.Location = new System.Drawing.Point(101, 296);
            this.btnSyncSrc2Dest.Name = "btnSyncSrc2Dest";
            this.btnSyncSrc2Dest.Size = new System.Drawing.Size(70, 29);
            this.btnSyncSrc2Dest.TabIndex = 10;
            this.btnSyncSrc2Dest.Text = "Sync";
            this.btnSyncSrc2Dest.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnSyncSrc2Dest.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(396, 421);
            this.Controls.Add(this.btnSyncDest2Src);
            this.Controls.Add(this.btnSyncSrc2Dest);
            this.Controls.Add(this.listViewDestFiles);
            this.Controls.Add(this.listViewSrcFiles);
            this.Controls.Add(this.btnCompare);
            this.Controls.Add(this.btnBrwsDstDir);
            this.Controls.Add(this.txtbxDestDir);
            this.Controls.Add(this.lblDestDir);
            this.Controls.Add(this.btnBrwsSrcDir);
            this.Controls.Add(this.txtbxSrcDir);
            this.Controls.Add(this.lblSrcDir);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Name = "Form1";
            this.Text = "Compare & Sync";
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSrcDir;
        private System.Windows.Forms.TextBox txtbxSrcDir;
        protected internal System.Windows.Forms.ToolTip tlTip;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button btnBrwsSrcDir;
        private System.Windows.Forms.Label lblDestDir;
        private System.Windows.Forms.TextBox txtbxDestDir;
        private System.Windows.Forms.Button btnBrwsDstDir;
        private System.Windows.Forms.Button btnCompare;
        private System.Windows.Forms.ListView listViewSrcFiles;
        private System.Windows.Forms.ListView listViewDestFiles;
        private System.Windows.Forms.ColumnHeader colHdrLstVwSrcFName;
        private System.Windows.Forms.ColumnHeader colHdrLstVwSrcFPath;
        private System.Windows.Forms.Button btnSyncDest2Src;
        private System.Windows.Forms.ColumnHeader colHdrLstVwSrcFDiff;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem item1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem item2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem item3ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem subitem31ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem subitem32ToolStripMenuItem;
        private System.Windows.Forms.Button btnSyncSrc2Dest;
    }
}

