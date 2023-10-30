using GameDesign;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;

namespace DKoQGame
{
    public partial class frmDesigner : Form
    {
        GridGenerator gameDesign;

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
            gameDesign = new GridGenerator();
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            if(int.TryParse(txtRow.Text, out int rows) && int.TryParse(txtColumn.Text, out int columns))
            {
                gameDesign.RemoveGrid(this);
                gameDesign.CreateGrid(this, rows, columns);
            }
            else
            {
                MessageBox.Show("Please provide valid data for rows and columns.(Both must be integers)\n" + "Input string was not in a correct format.", "QGame", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
