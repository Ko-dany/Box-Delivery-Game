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

        private GameManager gameManager;
        private List<Control> existingPictureBoxes;
        private int selectedToolIndex;
        private int gridBoxWidth;
        private int gridBoxHeight;

        // =============================== Methods ===============================

        // Assgins image to the picturebox in the grid based on what user selected
        // then store the data(tool) into the GameBoard.
        private void AssignToolImage(object sender, EventArgs e)
        {
            NewPictureBox selectedPictureBox = sender as NewPictureBox;   // Cast sender as PictureBox or return null

            if(selectedPictureBox.Tool != selectedToolIndex) // Change image only when different tool is selected
            {
                selectedPictureBox.Image = selectedToolIndex == 0 ? null : imlToolBox.Images[selectedToolIndex];
                gameManager.StoreToolData(selectedPictureBox.Row, selectedPictureBox.Column, selectedToolIndex);
            }
        }


        // Create Grid on the form and store every row/column data into the GameBoard.
        // Initalize each slot's tool as 0.
        private void CreateGrid(int rows, int columns)
        {
            int pictureBoxMargin = 3;
            int pictureBoxWidth = (gridBoxWidth- pictureBoxMargin*columns) / columns;
            int pictureBoxHeight = (gridBoxHeight-pictureBoxMargin*rows)/ rows;

            int pictureBoxSize = Math.Min(pictureBoxWidth, pictureBoxHeight);
            pictureBoxSize = pictureBoxSize > 130 ? 130 : pictureBoxSize;
            MessageBox.Show(pictureBoxSize.ToString());

            gameManager.InitializeBoard(rows, columns);

            for (int row = 0; row < rows; row++)
            {
                for (int column = 0; column < columns; column++)
                {
                    NewPictureBox pictureBox = new NewPictureBox()
                    {
                        Location = new Point(column * (pictureBoxSize + pictureBoxMargin), row * (pictureBoxSize + pictureBoxMargin)),
                        Size = new Size(pictureBoxSize, pictureBoxSize),
                        BorderStyle = BorderStyle.FixedSingle,
                        Row = row,
                        Column = column,
                        Tool = 0,
                        SizeMode = PictureBoxSizeMode.StretchImage
                    };
                    gameManager.CreatePictureBoxData(pictureBox.Row, pictureBox.Column, pictureBox);
                    pictureBox.Click += new EventHandler(AssignToolImage);
                    pnlGrid.Controls.Add(pictureBox);
                    
                }
            }
        }


        // Checks if there's already grid existing on the form.
        // Returns true if grid is existing.
        private bool HasGrid()
        {
            existingPictureBoxes = new List<Control>();

            foreach (Control control in pnlGrid.Controls)
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
                pnlGrid.Controls.Remove(pictureBox);
                pictureBox.Dispose();
            }
        }

        // =============================== Form Controls ===============================
        public frmDesigner()
        {
            InitializeComponent();
            this.Size = new System.Drawing.Size(1100, 750);
        }

        private void frmDesigner_Load(object sender, EventArgs e)
        {
            gameManager = new GameManager();
            gridBoxWidth = pnlGrid.Width;
            gridBoxHeight = pnlGrid.Height;
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            if (HasGrid())  // When there is existing Grid
            {
               DialogResult result = MessageBox.Show("Do you want to create a new level?\n" + "If you do, the current level will be lost", "QGame", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

               if(result == DialogResult.Yes)   // If user selects "Yes"
                {
                    if (int.TryParse(txtRow.Text, out int rows) && int.TryParse(txtColumn.Text, out int columns) && rows > 0 && columns > 0)
                    {
                        RemoveGrid();
                        CreateGrid(rows, columns);
                    }
                    else
                    {
                        MessageBox.Show("Please provide valid data for rows and columns.(Both must be integers)\n" + "Input string was not in a correct format.", "QGame", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else    // When there is NOT existing Grid
            {
                if (int.TryParse(txtRow.Text, out int rows) && int.TryParse(txtColumn.Text, out int columns) && rows > 0 && columns > 0)
                {
                    CreateGrid(rows, columns);
                }
                else
                {
                    MessageBox.Show("Please provide valid data for rows and columns.(Both must be integers)\n" + "Input string was not in a correct format.", "QGame", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Assigns selectedToolIndex based on the button user selects.
        private void ToolButtonsHandler(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            selectedToolIndex = btn.ImageIndex;
        }
        

        // When saving, it generates the info message which tells how many objects in the grid, and content for the text file.
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult r = saveFileDialog1.ShowDialog();
            switch (r)
            {
                case DialogResult.OK:
                    gameManager.SaveFile();

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

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
