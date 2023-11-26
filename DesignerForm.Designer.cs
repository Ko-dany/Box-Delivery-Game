namespace DKoQGame
{
    partial class frmDesigner
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDesigner));
            this.mnuDesigner = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imlToolBox = new System.Windows.Forms.ImageList(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnGreenBox = new System.Windows.Forms.Button();
            this.btnRedBox = new System.Windows.Forms.Button();
            this.btnGreenDoor = new System.Windows.Forms.Button();
            this.btnRedDoor = new System.Windows.Forms.Button();
            this.btnWall = new System.Windows.Forms.Button();
            this.btnNone = new System.Windows.Forms.Button();
            this.lblColumn = new System.Windows.Forms.Label();
            this.txtRow = new System.Windows.Forms.TextBox();
            this.txtColumn = new System.Windows.Forms.TextBox();
            this.lblRow = new System.Windows.Forms.Label();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.sfdSave = new System.Windows.Forms.SaveFileDialog();
            this.pnlGrid = new System.Windows.Forms.Panel();
            this.mnuDesigner.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnuDesigner
            // 
            this.mnuDesigner.BackColor = System.Drawing.SystemColors.Control;
            this.mnuDesigner.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.mnuDesigner.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.mnuDesigner.Location = new System.Drawing.Point(0, 0);
            this.mnuDesigner.Name = "mnuDesigner";
            this.mnuDesigner.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.mnuDesigner.Size = new System.Drawing.Size(1357, 28);
            this.mnuDesigner.TabIndex = 1;
            this.mnuDesigner.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.closeToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(46, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(128, 26);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(128, 26);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // imlToolBox
            // 
            this.imlToolBox.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imlToolBox.ImageStream")));
            this.imlToolBox.TransparentColor = System.Drawing.Color.White;
            this.imlToolBox.Images.SetKeyName(0, "None.png");
            this.imlToolBox.Images.SetKeyName(1, "Wall.png");
            this.imlToolBox.Images.SetKeyName(2, "RedDoor.png");
            this.imlToolBox.Images.SetKeyName(3, "GreenDoor.png");
            this.imlToolBox.Images.SetKeyName(4, "None.png");
            this.imlToolBox.Images.SetKeyName(5, "None.png");
            this.imlToolBox.Images.SetKeyName(6, "RedBox.png");
            this.imlToolBox.Images.SetKeyName(7, "GreenBox.png");
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnGreenBox);
            this.panel1.Controls.Add(this.btnRedBox);
            this.panel1.Controls.Add(this.btnGreenDoor);
            this.panel1.Controls.Add(this.btnRedDoor);
            this.panel1.Controls.Add(this.btnWall);
            this.panel1.Controls.Add(this.btnNone);
            this.panel1.Location = new System.Drawing.Point(0, 111);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(267, 709);
            this.panel1.TabIndex = 8;
            // 
            // btnGreenBox
            // 
            this.btnGreenBox.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGreenBox.ImageIndex = 7;
            this.btnGreenBox.ImageList = this.imlToolBox;
            this.btnGreenBox.Location = new System.Drawing.Point(47, 517);
            this.btnGreenBox.Margin = new System.Windows.Forms.Padding(4);
            this.btnGreenBox.Name = "btnGreenBox";
            this.btnGreenBox.Size = new System.Drawing.Size(183, 84);
            this.btnGreenBox.TabIndex = 8;
            this.btnGreenBox.Text = "Green Box";
            this.btnGreenBox.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGreenBox.UseVisualStyleBackColor = true;
            this.btnGreenBox.Click += new System.EventHandler(this.ToolButtonsHandler);
            // 
            // btnRedBox
            // 
            this.btnRedBox.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRedBox.ImageIndex = 6;
            this.btnRedBox.ImageList = this.imlToolBox;
            this.btnRedBox.Location = new System.Drawing.Point(47, 416);
            this.btnRedBox.Margin = new System.Windows.Forms.Padding(4);
            this.btnRedBox.Name = "btnRedBox";
            this.btnRedBox.Size = new System.Drawing.Size(183, 84);
            this.btnRedBox.TabIndex = 7;
            this.btnRedBox.Text = "Red Box";
            this.btnRedBox.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRedBox.UseVisualStyleBackColor = true;
            this.btnRedBox.Click += new System.EventHandler(this.ToolButtonsHandler);
            // 
            // btnGreenDoor
            // 
            this.btnGreenDoor.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGreenDoor.ImageIndex = 3;
            this.btnGreenDoor.ImageList = this.imlToolBox;
            this.btnGreenDoor.Location = new System.Drawing.Point(47, 313);
            this.btnGreenDoor.Margin = new System.Windows.Forms.Padding(4);
            this.btnGreenDoor.Name = "btnGreenDoor";
            this.btnGreenDoor.Size = new System.Drawing.Size(183, 84);
            this.btnGreenDoor.TabIndex = 6;
            this.btnGreenDoor.Text = "Green Door";
            this.btnGreenDoor.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGreenDoor.UseVisualStyleBackColor = true;
            this.btnGreenDoor.Click += new System.EventHandler(this.ToolButtonsHandler);
            // 
            // btnRedDoor
            // 
            this.btnRedDoor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnRedDoor.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRedDoor.ImageIndex = 2;
            this.btnRedDoor.ImageList = this.imlToolBox;
            this.btnRedDoor.Location = new System.Drawing.Point(47, 211);
            this.btnRedDoor.Margin = new System.Windows.Forms.Padding(4);
            this.btnRedDoor.Name = "btnRedDoor";
            this.btnRedDoor.Size = new System.Drawing.Size(183, 84);
            this.btnRedDoor.TabIndex = 5;
            this.btnRedDoor.Text = "Red Door";
            this.btnRedDoor.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRedDoor.UseVisualStyleBackColor = true;
            this.btnRedDoor.Click += new System.EventHandler(this.ToolButtonsHandler);
            // 
            // btnWall
            // 
            this.btnWall.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnWall.ImageIndex = 1;
            this.btnWall.ImageList = this.imlToolBox;
            this.btnWall.Location = new System.Drawing.Point(47, 106);
            this.btnWall.Margin = new System.Windows.Forms.Padding(4);
            this.btnWall.Name = "btnWall";
            this.btnWall.Size = new System.Drawing.Size(183, 84);
            this.btnWall.TabIndex = 4;
            this.btnWall.Text = "Wall";
            this.btnWall.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnWall.UseVisualStyleBackColor = true;
            this.btnWall.Click += new System.EventHandler(this.ToolButtonsHandler);
            // 
            // btnNone
            // 
            this.btnNone.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNone.ImageIndex = 0;
            this.btnNone.ImageList = this.imlToolBox;
            this.btnNone.Location = new System.Drawing.Point(47, 4);
            this.btnNone.Margin = new System.Windows.Forms.Padding(4);
            this.btnNone.Name = "btnNone";
            this.btnNone.Size = new System.Drawing.Size(183, 84);
            this.btnNone.TabIndex = 3;
            this.btnNone.Text = "None";
            this.btnNone.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNone.UseVisualStyleBackColor = true;
            this.btnNone.Click += new System.EventHandler(this.ToolButtonsHandler);
            // 
            // lblColumn
            // 
            this.lblColumn.AutoSize = true;
            this.lblColumn.Location = new System.Drawing.Point(247, 52);
            this.lblColumn.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblColumn.Name = "lblColumn";
            this.lblColumn.Size = new System.Drawing.Size(62, 16);
            this.lblColumn.TabIndex = 4;
            this.lblColumn.Text = "Columns:";
            // 
            // txtRow
            // 
            this.txtRow.Location = new System.Drawing.Point(81, 49);
            this.txtRow.Margin = new System.Windows.Forms.Padding(4);
            this.txtRow.Name = "txtRow";
            this.txtRow.Size = new System.Drawing.Size(132, 22);
            this.txtRow.TabIndex = 0;
            // 
            // txtColumn
            // 
            this.txtColumn.Location = new System.Drawing.Point(317, 49);
            this.txtColumn.Margin = new System.Windows.Forms.Padding(4);
            this.txtColumn.Name = "txtColumn";
            this.txtColumn.Size = new System.Drawing.Size(132, 22);
            this.txtColumn.TabIndex = 1;
            // 
            // lblRow
            // 
            this.lblRow.AutoSize = true;
            this.lblRow.Location = new System.Drawing.Point(28, 52);
            this.lblRow.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRow.Name = "lblRow";
            this.lblRow.Size = new System.Drawing.Size(44, 16);
            this.lblRow.TabIndex = 2;
            this.lblRow.Text = "Rows:";
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(559, 36);
            this.btnGenerate.Margin = new System.Windows.Forms.Padding(4);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(195, 47);
            this.btnGenerate.TabIndex = 2;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // sfdSave
            // 
            this.sfdSave.FileName = "savegame1.qgame";
            // 
            // pnlGrid
            // 
            this.pnlGrid.Location = new System.Drawing.Point(274, 111);
            this.pnlGrid.Name = "pnlGrid";
            this.pnlGrid.Size = new System.Drawing.Size(1071, 709);
            this.pnlGrid.TabIndex = 9;
            // 
            // frmDesigner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1357, 828);
            this.Controls.Add(this.pnlGrid);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.lblRow);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txtColumn);
            this.Controls.Add(this.txtRow);
            this.Controls.Add(this.mnuDesigner);
            this.Controls.Add(this.lblColumn);
            this.MainMenuStrip = this.mnuDesigner;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmDesigner";
            this.Text = "Design Form";
            this.Load += new System.EventHandler(this.frmDesigner_Load);
            this.mnuDesigner.ResumeLayout(false);
            this.mnuDesigner.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip mnuDesigner;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnRedBox;
        private System.Windows.Forms.Button btnGreenDoor;
        private System.Windows.Forms.Button btnRedDoor;
        private System.Windows.Forms.Button btnWall;
        public System.Windows.Forms.ImageList imlToolBox;
        private System.Windows.Forms.Button btnNone;
        private System.Windows.Forms.Button btnGreenBox;
        private System.Windows.Forms.Label lblColumn;
        private System.Windows.Forms.TextBox txtRow;
        private System.Windows.Forms.TextBox txtColumn;
        private System.Windows.Forms.Label lblRow;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.SaveFileDialog sfdSave;
        private System.Windows.Forms.Panel pnlGrid;
    }
}