using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DKoQGame
{
    public class NewPictureBox : PictureBox
    {
        public int Row { get; set; }
        public int Column { get; set; }
        public int Tool {  get; set; } 
    }
}
