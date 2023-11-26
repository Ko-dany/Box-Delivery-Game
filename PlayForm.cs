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

        private int gridBoxWidth;
        private int gridBoxHeight;
        int pictureBoxMargin = 3;

        private NewPictureBox currentSelectedBox;
        private static int totalMoves;

        // =============================== Methods ===============================
        public void DeactivateAllBoxes()
        {
            currentSelectedBox = null;
            foreach (NewPictureBox box in existingBoxes)
            {
                if (playManager.IsRedBox(box))
                {
                    box.Image = imlToolBox.Images[6];
                }
                else if (playManager.IsGreenBox(box))
                {
                    box.Image = imlToolBox.Images[7];
                }
            }
        }

        private void ActivateBox(object sender, EventArgs e)
        {
            DeactivateAllBoxes();
            NewPictureBox selectedPictureBox = sender as NewPictureBox;

            if (playManager.IsRedBox(selectedPictureBox) || playManager.IsGreenBox(selectedPictureBox))
            {
                currentSelectedBox = (NewPictureBox)sender;
                selectedPictureBox.BringToFront();

                selectedPictureBox.Image = playManager.IsRedBox(selectedPictureBox) ? imlToolBox.Images[8] : imlToolBox.Images[9];
            }
        }

        private bool ButtonIsSelected()
        {
            return (currentSelectedBox != null);
        }

        private void InitializeCounts()
        {
            totalMoves = 0;
            existingBoxes = new List<NewPictureBox>();
        }

        private void UpdateTotalMoves()
        {
            txtMoves.Text = totalMoves.ToString();
        }
        private void UpdateTotalBoxes()
        {
            txtBoxes.Text = existingBoxes.Count.ToString();
        }
        private void CreateGameboard(int rows, int columns, int[,] ToolBlocks)
        {
            int pictureBoxWidth = (gridBoxWidth - pictureBoxMargin * columns) / columns;
            int pictureBoxHeight = (gridBoxHeight - pictureBoxMargin * rows) / rows;

            int pictureBoxSize = Math.Min(pictureBoxWidth, pictureBoxHeight);
            pictureBoxSize = pictureBoxSize > 90 ? 90 : pictureBoxSize;

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
                    if (playManager.IsRedBox(pictureBox) || playManager.IsGreenBox(pictureBox))
                    {
                        existingBoxes.Add(pictureBox);
                    }
                    pnlGameboard.Controls.Add(pictureBox);
                }
            }

            ActivateMoveButtons();
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

        private void ActivateMoveButtons()
        {
            btnUp.Enabled = btnDown.Enabled = btnLeft.Enabled = btnRight.Enabled = true;
        }

        private void DeactivateMoveButtons()
        {
            btnUp.Enabled = btnDown.Enabled = btnLeft.Enabled = btnRight.Enabled = false;
        }

        private void MoveBox(int targetRow, int targetColumn)
        {
            currentSelectedBox.Top += (targetRow - currentSelectedBox.Row) * (currentSelectedBox.Height + pictureBoxMargin);
            currentSelectedBox.Left += (targetColumn - currentSelectedBox.Column) * (currentSelectedBox.Width + pictureBoxMargin);

            currentSelectedBox.Row = targetRow;
            currentSelectedBox.Column = targetColumn;

            playManager.UpdateGameBoard(targetRow, targetColumn, currentSelectedBox.Tool);
        }

        private void MoveButtonHandler(string move)
        {
            if (!ButtonIsSelected())
            {
                MessageBox.Show("Please select a box.");
            }
            else
            {
                int currentRow = currentSelectedBox.Row;
                int currentColumn = currentSelectedBox.Column;

                int targetRow = currentRow;
                int targetColumn = currentColumn;

                switch (move)
                {
                    case "Up":
                        targetRow--;
                        break;
                    case "Down":
                        targetRow++;
                        break;
                    case "Left":
                        targetColumn--;
                        break;
                    case "Right":
                        targetColumn++;
                        break;
                    default:
                        break;
                }

                //MessageBox.Show($"Go to [{targetRow}, {targetColumn}]: {playManager.GetToolFromPictureBox(targetRow, targetColumn)}");
                if (playManager.IsValidMove(targetRow, targetColumn))
                {
                    if (playManager.GetToolFromPictureBox(targetRow, targetColumn) == 0)
                    {
                        MoveBox(targetRow, targetColumn);
                        totalMoves += 1;
                    }
                    else
                    {
                        if (playManager.IsCollided(currentSelectedBox, targetRow, targetColumn))
                        {
                            pnlGameboard.Controls.Remove(currentSelectedBox);
                            existingBoxes.Remove(currentSelectedBox);
                            currentSelectedBox.Dispose();

                            totalMoves += 1;
                            UpdateTotalBoxes();
                        }
                    }
                    playManager.UpdateGameBoard(currentRow, currentColumn, 0);

                    UpdateTotalMoves();
                }
            }

            if(existingBoxes.Count <= 0)
            {
                MessageBox.Show("Congratuations!\nGame End", "QGame", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                InitializeGame();
            }
        }

        private void InitializeGame()
        {
            if (HasGrid()) { RemoveGrid(); }
            
            DeactivateMoveButtons();

            InitializeCounts();
            UpdateTotalMoves();
            UpdateTotalBoxes();
        }

        // =============================== Form Controls ===============================

        public frmPlay()
        {
            InitializeComponent();

            InitializeGame();
        }

        private void frmPlay_Load(object sender, EventArgs e)
        {
            playManager = new PlayManager();
            gridBoxWidth = pnlGameboard.Width;
            gridBoxHeight = pnlGameboard.Height;
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
                    InitializeGame();
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
            MoveButtonHandler("Up");
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            MoveButtonHandler("Down");
        }

        private void btnLeft_Click(object sender, EventArgs e)
        {
            MoveButtonHandler("Left");
        }

        private void btnRight_Click(object sender, EventArgs e)
        {
            MoveButtonHandler("Right");
        }
    }
}