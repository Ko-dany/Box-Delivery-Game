/*
 * Program: PROG2370-SEC4 Game Programming
 * Purpose: Assignment 2
 * Revision History:
 *      created by Dahyun Ko, Oct/31/2023
 */

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
using static System.Windows.Forms.AxHost;

namespace DKoQGame
{
    public partial class frmDesigner : Form
    {

        // =============================== Variables ===============================

        public GameManager gameManager;
        public List<Control> existingPictureBoxes;
        public int toolIndex;

        // =============================== Methods ===============================

        // Assgins image to the picturebox in the grid based on what user selected
        // then store the data(tool) into the GameBoard.
        public void AssignToolImage(object sender, EventArgs e)
        {
            NewPictureBox selectedPictureBox = sender as NewPictureBox;   // Cast sender as PictureBox or return null
            if(selectedPictureBox.Tool != toolIndex)
            {
                if (toolIndex == 0) selectedPictureBox.Image = null;
                else selectedPictureBox.Image = imlToolBox.Images[toolIndex];
                selectedPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;

                gameManager.StoreDataToBoard(selectedPictureBox.Row, selectedPictureBox.Column, toolIndex);
            }
        }

        // Create Grid on the form and store every row/column data into the GameBoard.
        // Initalize each slot's tool as 0.
        public void CreateGrid(int rows, int columns)
        {
            int startX = 250;
            int startY = 100;

            int pictureBoxSize = 100; // Dynamically
            int pictureBoxMargin = 3;

            gameManager.InitializeBoard(rows, columns);

            for (int row = 0; row < rows; row++)
            {
                for (int column = 0; column < columns; column++)
                {
                    NewPictureBox pictureBox = new NewPictureBox()
                    {
                        Location = new Point(startX + (column * (pictureBoxSize + pictureBoxMargin)), startY + (row * (pictureBoxSize + pictureBoxMargin))),
                        Size = new Size(pictureBoxSize, pictureBoxSize),
                        BorderStyle = BorderStyle.FixedSingle,
                        Row = row,
                        Column = column,
                        Tool = 0
                    };

                    gameManager.CreatePictureBoxData(pictureBox.Row, pictureBox.Column, pictureBox);
                    pictureBox.Click += new EventHandler(AssignToolImage);
                    Controls.Add(pictureBox);
                }
            }
        }

        // Checks if there's already grid existing on the form.
        // Returns true if grid is existing.
        public bool HasGrid()
        {
            existingPictureBoxes = new List<Control>();

            foreach (Control control in Controls)
            {
                if (control is NewPictureBox)
                {
                    existingPictureBoxes.Add(control);
                }
            }

            return existingPictureBoxes.Count > 0;
        }

        // Removes the grid existing on the form.
        public void RemoveGrid()
        {
            foreach (Control pictureBox in existingPictureBoxes)
            {
                Controls.Remove(pictureBox);
                pictureBox.Dispose();
            }
        }

        // =============================== Form Controls ===============================

        public frmDesigner()
        {
            InitializeComponent();
            this.Size = new System.Drawing.Size(1100, 700);
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmDesigner_Load(object sender, EventArgs e)
        {
            gameManager = new GameManager();
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            if (HasGrid())
            {
               DialogResult result = MessageBox.Show("Do you want to create a new level?\n" + "If you do, the current level will be lost", "QGame", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

               if(result == DialogResult.Yes)
                {
                    if (int.TryParse(txtRow.Text, out int rows) && int.TryParse(txtColumn.Text, out int columns) && rows > 0 && columns > 0)
                    {
                        if (HasGrid())
                        {
                            RemoveGrid();
                        }
                        CreateGrid(rows, columns);
                    }
                    else
                    {
                        MessageBox.Show("Please provide valid data for rows and columns.(Both must be integers)\n" + "Input string was not in a correct format.", "QGame", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                if (int.TryParse(txtRow.Text, out int rows) && int.TryParse(txtColumn.Text, out int columns) && rows > 0 && columns > 0)
                {
                    if (HasGrid())
                    {
                        RemoveGrid();
                    }
                    CreateGrid(rows, columns);
                }
                else
                {
                    MessageBox.Show("Please provide valid data for rows and columns.(Both must be integers)\n" + "Input string was not in a correct format.", "QGame", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Assign toolIndex based on the button user clickes.
        private void ToolButtonsHandler(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            toolIndex = btn.ImageIndex;
        }
        

        // When saving it generates the info message which tells how many objects in the grid, and content for the text file.
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gameManager.SaveFile();

            DialogResult r = saveFileDialog1.ShowDialog();
            switch (r)
            {
                case DialogResult.OK:
                    string fileName = saveFileDialog1.FileName;
                    StreamWriter writer = new StreamWriter(fileName);
                    writer.WriteLine(gameManager.FileContent);
                    writer.Close();

                    MessageBox.Show(gameManager.FileSaveInfo);
                    break;
                default:
                    break;
            }
        }
    }
}
