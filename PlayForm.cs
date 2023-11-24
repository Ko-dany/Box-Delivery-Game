using GameDesign;
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


namespace DKoQGame
{
    public partial class frmPlay : Form
    {

        // =============================== Variables ===============================

        private PlayManager playManager;
        private List<Control> existingPictureBoxes;
        private List<NewPictureBox> existingBoxes;

        private int[,] GameBoard { get; set; }
        private int gridBoxWidth;
        private int gridBoxHeight;
        int pictureBoxMargin = 3;

        private NewPictureBox currentSelectedBox;
        private static int totalMoves;

        // =============================== Methods ===============================
        public bool IsRedBox(NewPictureBox box)
        {
            if(box.Tool == 4 || box.Tool == 6) { return true; }
            return false;
        }
        public bool IsGreenBox(NewPictureBox box)
        {
            if (box.Tool == 5 || box.Tool == 7) { return true; }
            return false;
        }

        public void DeactivateAllBoxes()
        {
            foreach(NewPictureBox box in existingBoxes)
            {
                if(IsRedBox(box))
                {
                    box.Image = imlToolBox.Images[6];
                }
                else if(IsGreenBox(box))
                {
                    box.Image = imlToolBox.Images[7];
                }
            }
        }

        private void ActivateBox(object sender, EventArgs e)
        {
            DeactivateAllBoxes();
            NewPictureBox selectedPictureBox = sender as NewPictureBox;

            if (IsRedBox(selectedPictureBox))
            {
                selectedPictureBox.Image = imlToolBox.Images[8];
            }
            else if(IsGreenBox(selectedPictureBox))
            {
                selectedPictureBox.Image = imlToolBox.Images[9];
            }

            currentSelectedBox = (NewPictureBox)sender;
            selectedPictureBox.BringToFront();
        }

        private void CountTotalMoves()
        {
            totalMoves += 1;
            txtMoves.Text = totalMoves.ToString();
        }
        private void CreateGameboard(int rows, int columns, int[,] ToolBlocks)
        {

            if (HasGrid()) { RemoveGrid(); }


            int pictureBoxWidth = (gridBoxWidth - pictureBoxMargin * columns) / columns;
            int pictureBoxHeight = (gridBoxHeight - pictureBoxMargin * rows) / rows;

            int pictureBoxSize = Math.Min(pictureBoxWidth, pictureBoxHeight);
            pictureBoxSize = pictureBoxSize > 90 ? 90 : pictureBoxSize;

            existingBoxes = new List<NewPictureBox>();

            for (int row = 0; row < rows; row++)
            {
                for (int column = 0; column < columns; column++)
                {
                    NewPictureBox pictureBox = new NewPictureBox()
                    {
                        Location = new Point(column * (pictureBoxSize + pictureBoxMargin), row * (pictureBoxSize + pictureBoxMargin)),
                        Size = new Size(pictureBoxSize, pictureBoxSize),
                        Row = row,
                        Column = column,
                        Tool = ToolBlocks[row, column],
                        SizeMode = PictureBoxSizeMode.StretchImage,
                        Image = ToolBlocks[row, column] == 0 ? null : imlToolBox.Images[ToolBlocks[row, column]]
                    };
                    pictureBox.Click += new EventHandler(ActivateBox);
                    if(IsRedBox(pictureBox) || IsGreenBox(pictureBox)) 
                    { 
                        existingBoxes.Add(pictureBox);
                    }
                    pnlGameboard.Controls.Add(pictureBox);
                }
            }
        }

        private bool HasGrid()
        {
            existingPictureBoxes = new List<Control>();

            foreach (Control control in pnlGameboard.Controls)
            {
                if (control is NewPictureBox)
                {
                    existingPictureBoxes.Add(control);
                }
            }

            return existingPictureBoxes.Count > 0;
        }

        private void RemoveGrid()
        {
            foreach (Control pictureBox in existingPictureBoxes)
            {
                pnlGameboard.Controls.Remove(pictureBox);
                pictureBox.Dispose();
            }
        }

        // =============================== Form Controls ===============================

        public frmPlay()
        {
            InitializeComponent();
        }

        private void frmPlay_Load(object sender, EventArgs e)
        {
            playManager = new PlayManager();
            gridBoxWidth = pnlGameboard.Width;
            gridBoxHeight = pnlGameboard.Height;
            totalMoves = 0;
        }

        private void openToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DialogResult result = ofdOpen.ShowDialog();
            if (result == DialogResult.OK)
            {
                string filePath = ofdOpen.Filter;

                try
                {
                    filePath = ofdOpen.FileName;
                    
                    string[] fileContent = File.ReadAllLines(filePath);                    

                    playManager.GetGameBoardInfoFromFile(fileContent);
                    CreateGameboard(playManager.Rows, playManager.Columns, playManager.Tools);

                    txtBoxes.Text = (playManager.RedBoxes + playManager.GreenBoxes).ToString();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Execption is happenning!:\n" + ex.Message);
                }

            }

        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            int currentRow = currentSelectedBox.Row;
            int currentColumn = currentSelectedBox.Column;

            int currentRowUp = currentRow - 1;

            MessageBox.Show($"Go to [{currentRowUp}, {currentColumn}]: {playManager.GetToolFromPictureBox(currentRowUp, currentColumn)}");
            if (currentRowUp >= 0)
            {
                if (playManager.GetToolFromPictureBox(currentRowUp, currentColumn) == 0)    //When it's empty tile
                {
                    currentSelectedBox.Top -= (currentSelectedBox.Height + pictureBoxMargin);

                    currentSelectedBox.Row = currentRowUp;
                    playManager.UpdateGameBoard(currentSelectedBox.Row, currentSelectedBox.Column, currentSelectedBox.Tool);
                    playManager.UpdateGameBoard(currentRow, currentColumn, 0);

                    CountTotalMoves();
                }
            }
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            int currentRow = currentSelectedBox.Row;
            int currentColumn = currentSelectedBox.Column;

            int currentRowDown = currentRow + 1;

            MessageBox.Show($"Go to [{currentRowDown}, {currentColumn}]: {playManager.GetToolFromPictureBox(currentRowDown, currentColumn)}");
            if (currentRowDown <= playManager.Rows)
            {
                if (playManager.GetToolFromPictureBox(currentRowDown, currentColumn) == 0)    //When it's empty tile
                {
                    currentSelectedBox.Top += (currentSelectedBox.Height + pictureBoxMargin);

                    currentSelectedBox.Row = currentRowDown;
                    playManager.UpdateGameBoard(currentSelectedBox.Row, currentSelectedBox.Column, currentSelectedBox.Tool);
                    playManager.UpdateGameBoard(currentRow, currentColumn, 0);

                    CountTotalMoves();
                }
            }
        }

        private void btnLeft_Click(object sender, EventArgs e)
        {
            int currentRow = currentSelectedBox.Row;
            int currentColumn = currentSelectedBox.Column;

            int currentColumnLeft = currentColumn - 1;

            MessageBox.Show($"Go to [{currentRow}, {currentColumnLeft}]: {playManager.GetToolFromPictureBox(currentRow, currentColumnLeft)}");
            if (currentColumnLeft >=0)
            {
                if (playManager.GetToolFromPictureBox(currentRow, currentColumnLeft) == 0)    //When it's empty tile
                {
                    currentSelectedBox.Left -= (currentSelectedBox.Width + pictureBoxMargin);

                    currentSelectedBox.Column = currentColumnLeft;
                    playManager.UpdateGameBoard(currentSelectedBox.Row, currentSelectedBox.Column, currentSelectedBox.Tool);
                    playManager.UpdateGameBoard(currentRow, currentColumn, 0);

                    CountTotalMoves();
                }
            }
        }

        private void btnRight_Click(object sender, EventArgs e)
        {
            int currentRow = currentSelectedBox.Row;
            int currentColumn = currentSelectedBox.Column;

            int currentColumnRight = currentColumn + 1;

            MessageBox.Show($"Go to [{currentRow}, {currentColumnRight}]: {playManager.GetToolFromPictureBox(currentRow, currentColumnRight)}");
            if (currentColumnRight >= 0)
            {
                if (playManager.GetToolFromPictureBox(currentRow, currentColumnRight) == 0)    //When it's empty tile
                {
                    currentSelectedBox.Left += (currentSelectedBox.Width + pictureBoxMargin);

                    currentSelectedBox.Column = currentColumnRight;
                    playManager.UpdateGameBoard(currentSelectedBox.Row, currentSelectedBox.Column, currentSelectedBox.Tool);
                    playManager.UpdateGameBoard(currentRow, currentColumn, 0);

                    CountTotalMoves();
                }
            }
        }
    }
}
