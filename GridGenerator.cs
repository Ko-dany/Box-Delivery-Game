using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameDesign
{
    public class GridGenerator : IGridGenerator
    {
        public Dictionary<int[,], string> Grid { get; set; }

        public void CreateGrid(Form form, int rows, int columns)
        {
            int startX = 250;
            int startY = 100;
            int pictureBoxSize = 100;
            int pictureBoxMargin = 3;

            for (int i = 0; i < rows; i++)
            {
                for(int j = 0; j < columns; j++)
                {
                    PictureBox pictureBox = new PictureBox()
                    {
                        Location = new Point(startX + (j * (pictureBoxSize + pictureBoxMargin)), startY + (i * (pictureBoxSize + pictureBoxMargin))),
                        Size = new Size(pictureBoxSize, pictureBoxSize),
                        BorderStyle = BorderStyle.FixedSingle,
                    };

                    form.Controls.Add(pictureBox);
                }
            }
        }

        public void RemoveGrid(Form form)
        {
            List<Control> pictureBoxesToRemove = new List<Control>();

            foreach (Control control in form.Controls)
            {
                if (control is PictureBox)
                {
                    pictureBoxesToRemove.Add(control);
                }
            }

            foreach (Control pictureBox in pictureBoxesToRemove)
            {
                form.Controls.Remove(pictureBox);
                pictureBox.Dispose();
            }
        }
        
    }
}
