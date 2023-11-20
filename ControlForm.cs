using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DKoQGame
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnDesign_Click(object sender, EventArgs e)
        {
            frmDesigner frmDesigner= new frmDesigner();
            frmDesigner.Show();
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            frmPlay frmPlay = new frmPlay();
            frmPlay.Show();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
