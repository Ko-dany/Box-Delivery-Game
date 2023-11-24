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

        private int[,] currentSelectedBox;

        // =============================== Methods ===============================

        public void DeactivateAllBoxes()
        {
            foreach(NewPictureBox box in existingBoxes)
            {
                if(box.Tool == 4 || box.Tool == 6)
                {
                    box.Image = imlToolBox.Images[6];
                }
                else if(box.Tool == 5 || box.Tool == 7)
                {
                    box.Image = imlToolBox.Images[7];
                }
            }
        }

        private void ActivateBox(object sender, EventArgs e)
        {
            DeactivateAllBoxes();
            NewPictureBox selectedPictureBox = sender as NewPictureBox;   // Cast sender as PictureBox or return null

            // code when clicked
            if (selectedPictureBox.Tool == 4 || selectedPictureBox.Tool == 6)   // Red box
            {
                selectedPictureBox.Image = imlToolBox.Images[8];
            }
            else if(selectedPictureBox.Tool == 5 || selectedPictureBox.Tool == 7)   // Green box
            {
                selectedPictureBox.Image = imlToolBox.Images[9];
            }
        }

        private void CreateGameboard(int rows, int columns, int[,] ToolBlocks)
        {

            if (HasGrid()) { RemoveGrid(); }

            int pictureBoxMargin = 3;
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
                    if((pictureBox.Tool == 4 || pictureBox.Tool == 6) || (pictureBox.Tool == 5 || pictureBox.Tool == 7)) { existingBoxes.Add(pictureBox); }
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


        // Removes the grid existing on the form.
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
    }
}
