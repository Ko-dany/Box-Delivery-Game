namespace DKoQGame
{
    partial class frmPlay
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPlay));
            this.mnuPlay = new System.Windows.Forms.MenuStrip();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlGameboard = new System.Windows.Forms.Panel();
            this.lblMoves = new System.Windows.Forms.Label();
            this.txtMoves = new System.Windows.Forms.TextBox();
            this.txtBoxes = new System.Windows.Forms.TextBox();
            this.lblBoxes = new System.Windows.Forms.Label();
            this.btnUp = new System.Windows.Forms.Button();
            this.btnDown = new System.Windows.Forms.Button();
            this.btnLeft = new System.Windows.Forms.Button();
            this.btnRight = new System.Windows.Forms.Button();
            this.ofdOpen = new System.Windows.Forms.OpenFileDialog();
            this.imlToolBox = new System.Windows.Forms.ImageList(this.components);
            this.mnuPlay.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnuPlay
            // 
            this.mnuPlay.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.mnuPlay.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem});
            this.mnuPlay.Location = new System.Drawing.Point(0, 0);
            this.mnuPlay.Name = "mnuPlay";
            this.mnuPlay.Size = new System.Drawing.Size(1357, 28);
            this.mnuPlay.TabIndex = 0;
            this.mnuPlay.Text = "menuStrip1";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem1,
            this.closeToolStripMenuItem});
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(46, 24);
            this.openToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem1
            // 
            this.openToolStripMenuItem1.Name = "openToolStripMenuItem1";
            this.openToolStripMenuItem1.Size = new System.Drawing.Size(224, 26);
            this.openToolStripMenuItem1.Text = "Load Game";
            this.openToolStripMenuItem1.Click += new System.EventHandler(this.openToolStripMenuItem1_Click);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // pnlGameboard
            // 
            this.pnlGameboard.Location = new System.Drawing.Point(12, 43);
            this.pnlGameboard.Name = "pnlGameboard";
            this.pnlGameboard.Size = new System.Drawing.Size(966, 760);
            this.pnlGameboard.TabIndex = 1;
            // 
            // lblMoves
            // 
            this.lblMoves.AutoSize = true;
            this.lblMoves.Location = new System.Drawing.Point(1007, 84);
            this.lblMoves.Name = "lblMoves";
            this.lblMoves.Size = new System.Drawing.Size(113, 16);
            this.lblMoves.TabIndex = 2;
            this.lblMoves.Text = "Number of Moves";
            // 
            // txtMoves
            // 
            this.txtMoves.Enabled = false;
            this.txtMoves.Location = new System.Drawing.Point(1010, 110);
            this.txtMoves.Name = "txtMoves";
            this.txtMoves.ReadOnly = true;
            this.txtMoves.Size = new System.Drawing.Size(207, 22);
            this.txtMoves.TabIndex = 3;
            this.txtMoves.Text = "0";
            this.txtMoves.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtBoxes
            // 
            this.txtBoxes.Enabled = false;
            this.txtBoxes.Location = new System.Drawing.Point(1010, 209);
            this.txtBoxes.Name = "txtBoxes";
            this.txtBoxes.ReadOnly = true;
            this.txtBoxes.Size = new System.Drawing.Size(207, 22);
            this.txtBoxes.TabIndex = 5;
            this.txtBoxes.Text = "0";
            this.txtBoxes.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblBoxes
            // 
            this.lblBoxes.AutoSize = true;
            this.lblBoxes.Location = new System.Drawing.Point(1007, 183);
            this.lblBoxes.Name = "lblBoxes";
            this.lblBoxes.Size = new System.Drawing.Size(178, 16);
            this.lblBoxes.TabIndex = 4;
            this.lblBoxes.Text = "Number of Remaining Boxes";
            // 
            // btnUp
            // 
            this.btnUp.Location = new System.Drawing.Point(1133, 563);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(79, 72);
            this.btnUp.TabIndex = 6;
            this.btnUp.Text = "Up";
            this.btnUp.UseVisualStyleBackColor = true;
            // 
            // btnDown
            // 
            this.btnDown.Location = new System.Drawing.Point(1133, 659);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(79, 72);
            this.btnDown.TabIndex = 7;
            this.btnDown.Text = "Down";
            this.btnDown.UseVisualStyleBackColor = true;
            // 
            // btnLeft
            // 
            this.btnLeft.Location = new System.Drawing.Point(1036, 659);
            this.btnLeft.Name = "btnLeft";
            this.btnLeft.Size = new System.Drawing.Size(79, 72);
            this.btnLeft.TabIndex = 8;
            this.btnLeft.Text = "Left";
            this.btnLeft.UseVisualStyleBackColor = true;
            // 
            // btnRight
            // 
            this.btnRight.Location = new System.Drawing.Point(1229, 659);
            this.btnRight.Name = "btnRight";
            this.btnRight.Size = new System.Drawing.Size(79, 72);
            this.btnRight.TabIndex = 9;
            this.btnRight.Text = "Right";
            this.btnRight.UseVisualStyleBackColor = true;
            // 
            // ofdOpen
            // 
            this.ofdOpen.FileName = "openFileDialog1";
            // 
            // imlToolBox
            // 
            this.imlToolBox.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imlToolBox.ImageStream")));
            this.imlToolBox.TransparentColor = System.Drawing.Color.White;
            this.imlToolBox.Images.SetKeyName(0, "None.png");
            this.imlToolBox.Images.SetKeyName(1, "Wall.png");
            this.imlToolBox.Images.SetKeyName(2, "RedDoor.png");
            this.imlToolBox.Images.SetKeyName(3, "GreenDoor.png");
            this.imlToolBox.Images.SetKeyName(4, "RedBox.png");
            this.imlToolBox.Images.SetKeyName(5, "GreenBox.png");
            this.imlToolBox.Images.SetKeyName(6, "RedBox.png");
            this.imlToolBox.Images.SetKeyName(7, "GreenBox.png");
            this.imlToolBox.Images.SetKeyName(8, "RedBox_Selected.png");
            this.imlToolBox.Images.SetKeyName(9, "GreenBox_Selected.png");
            // 
            // frmPlay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1357, 828);
            this.Controls.Add(this.btnRight);
            this.Controls.Add(this.btnLeft);
            this.Controls.Add(this.btnDown);
            this.Controls.Add(this.btnUp);
            this.Controls.Add(this.txtBoxes);
            this.Controls.Add(this.lblBoxes);
            this.Controls.Add(this.txtMoves);
            this.Controls.Add(this.lblMoves);
            this.Controls.Add(this.pnlGameboard);
            this.Controls.Add(this.mnuPlay);
            this.MainMenuStrip = this.mnuPlay;
            this.Name = "frmPlay";
            this.Text = "Play Form";
            this.Load += new System.EventHandler(this.frmPlay_Load);
            this.mnuPlay.ResumeLayout(false);
            this.mnuPlay.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mnuPlay;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.Panel pnlGameboard;
        private System.Windows.Forms.Label lblMoves;
        private System.Windows.Forms.TextBox txtMoves;
        private System.Windows.Forms.TextBox txtBoxes;
        private System.Windows.Forms.Label lblBoxes;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.Button btnLeft;
        private System.Windows.Forms.Button btnRight;
        private System.Windows.Forms.OpenFileDialog ofdOpen;
        public System.Windows.Forms.ImageList imlToolBox;
    }
}