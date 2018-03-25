namespace ChromeBookmarksMerger
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Node0.1");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Node0", new System.Windows.Forms.TreeNode[] {
            treeNode1});
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Node1");
            this.lblSrcBkmrk = new System.Windows.Forms.Label();
            this.txbxSrcBkmrk = new System.Windows.Forms.TextBox();
            this.lblDestBkmrk = new System.Windows.Forms.Label();
            this.btnSrcBkmrk = new System.Windows.Forms.Button();
            this.txtbxDestBkmrk = new System.Windows.Forms.TextBox();
            this.btnDestBkmrk = new System.Windows.Forms.Button();
            this.treevwSrcBkmrk = new System.Windows.Forms.TreeView();
            this.treevwDestBkmrk = new System.Windows.Forms.TreeView();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // lblSrcBkmrk
            // 
            this.lblSrcBkmrk.AutoSize = true;
            this.lblSrcBkmrk.Location = new System.Drawing.Point(13, 13);
            this.lblSrcBkmrk.Name = "lblSrcBkmrk";
            this.lblSrcBkmrk.Size = new System.Drawing.Size(92, 13);
            this.lblSrcBkmrk.TabIndex = 0;
            this.lblSrcBkmrk.Text = "Source Bookmark";
            // 
            // txbxSrcBkmrk
            // 
            this.txbxSrcBkmrk.Location = new System.Drawing.Point(16, 29);
            this.txbxSrcBkmrk.Name = "txbxSrcBkmrk";
            this.txbxSrcBkmrk.Size = new System.Drawing.Size(213, 20);
            this.txbxSrcBkmrk.TabIndex = 1;
            // 
            // lblDestBkmrk
            // 
            this.lblDestBkmrk.AutoSize = true;
            this.lblDestBkmrk.Location = new System.Drawing.Point(303, 13);
            this.lblDestBkmrk.Name = "lblDestBkmrk";
            this.lblDestBkmrk.Size = new System.Drawing.Size(111, 13);
            this.lblDestBkmrk.TabIndex = 2;
            this.lblDestBkmrk.Text = "Destination Bookmark";
            // 
            // btnSrcBkmrk
            // 
            this.btnSrcBkmrk.Location = new System.Drawing.Point(236, 25);
            this.btnSrcBkmrk.Name = "btnSrcBkmrk";
            this.btnSrcBkmrk.Size = new System.Drawing.Size(36, 23);
            this.btnSrcBkmrk.TabIndex = 3;
            this.btnSrcBkmrk.Text = "...";
            this.btnSrcBkmrk.UseVisualStyleBackColor = true;
            this.btnSrcBkmrk.Click += new System.EventHandler(this.btnBrwsSrcBkmrk_Click);
            // 
            // txtbxDestBkmrk
            // 
            this.txtbxDestBkmrk.Location = new System.Drawing.Point(306, 28);
            this.txtbxDestBkmrk.Name = "txtbxDestBkmrk";
            this.txtbxDestBkmrk.Size = new System.Drawing.Size(200, 20);
            this.txtbxDestBkmrk.TabIndex = 4;
            // 
            // btnDestBkmrk
            // 
            this.btnDestBkmrk.Location = new System.Drawing.Point(512, 25);
            this.btnDestBkmrk.Name = "btnDestBkmrk";
            this.btnDestBkmrk.Size = new System.Drawing.Size(38, 23);
            this.btnDestBkmrk.TabIndex = 5;
            this.btnDestBkmrk.Text = "...";
            this.btnDestBkmrk.UseVisualStyleBackColor = true;
            this.btnDestBkmrk.Click += new System.EventHandler(this.btnBrwsDestBkmrk_Click);
            // 
            // treevwSrcBkmrk
            // 
            this.treevwSrcBkmrk.Location = new System.Drawing.Point(16, 65);
            this.treevwSrcBkmrk.Name = "treevwSrcBkmrk";
            treeNode1.Name = "Node0.1";
            treeNode1.Text = "Node0.1";
            treeNode2.Name = "Node0";
            treeNode2.Text = "Node0";
            treeNode3.Name = "Node1";
            treeNode3.Text = "Node1";
            this.treevwSrcBkmrk.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode2,
            treeNode3});
            this.treevwSrcBkmrk.Size = new System.Drawing.Size(213, 171);
            this.treevwSrcBkmrk.TabIndex = 6;
            // 
            // treevwDestBkmrk
            // 
            this.treevwDestBkmrk.Location = new System.Drawing.Point(306, 65);
            this.treevwDestBkmrk.Name = "treevwDestBkmrk";
            this.treevwDestBkmrk.Size = new System.Drawing.Size(200, 171);
            this.treevwDestBkmrk.TabIndex = 7;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.InitialDirectory = "C:\\Users\\marashid\\Documents\\Personal_Stuff\\Personal Training and Development\\Visu" +
    "al Studio Projects\\Tools\\ChromeBookmarksMerger\\ChromeBookmarksMerger\\test_files";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(572, 310);
            this.Controls.Add(this.treevwDestBkmrk);
            this.Controls.Add(this.treevwSrcBkmrk);
            this.Controls.Add(this.btnDestBkmrk);
            this.Controls.Add(this.txtbxDestBkmrk);
            this.Controls.Add(this.btnSrcBkmrk);
            this.Controls.Add(this.lblDestBkmrk);
            this.Controls.Add(this.txbxSrcBkmrk);
            this.Controls.Add(this.lblSrcBkmrk);
            this.Name = "Form1";
            this.Text = "Chrome Bookmarks Merger";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSrcBkmrk;
        private System.Windows.Forms.TextBox txbxSrcBkmrk;
        private System.Windows.Forms.Label lblDestBkmrk;
        private System.Windows.Forms.Button btnSrcBkmrk;
        private System.Windows.Forms.TextBox txtbxDestBkmrk;
        private System.Windows.Forms.Button btnDestBkmrk;
        private System.Windows.Forms.TreeView treevwSrcBkmrk;
        private System.Windows.Forms.TreeView treevwDestBkmrk;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}

