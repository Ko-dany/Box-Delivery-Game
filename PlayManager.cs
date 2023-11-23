using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DKoQGame
{
    internal class PlayManager : IPlayManager
    {
        public int Rows { get; set; }
        public int Columns { get; set; }
        public int[,] Tools { get; set; }


        // Conver txt file to int[,] data for the gameboard
        public void GetGameBoardInfo(string[] fileContent)
        {

            Rows = int.Parse(fileContent[0]);
            Columns = int.Parse(fileContent[1]);

            Tools = new int[Rows, Columns];


            for (int i = 2; i < fileContent.Length; i += 3)
            {
                int row, column, toolType;
                if (int.TryParse(fileContent[i].Trim(), out row) && int.TryParse(fileContent[i + 1].Trim(), out column) && int.TryParse(fileContent[i + 2].Trim(), out toolType))
                {
                    Tools[row, column] = toolType;
                }
            }
        }
    }
}
