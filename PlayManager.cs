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

        public int RedBoxes { get; set; } = 0;
        public int RedDoors { get; set; } = 0;
        public int GreenBoxes { get; set; } = 0;
        public int GreenDoors { get; set; } = 0;

        public void InitializeGameBoard()
        {
            RedBoxes = RedDoors = GreenBoxes = GreenDoors = 0;
        }


        // Conver txt file to int[,] data for the gameboard
        public void GetGameBoardInfoFromFile(string[] fileContent)
        {
            InitializeGameBoard();
            Rows = int.Parse(fileContent[0]);
            Columns = int.Parse(fileContent[1]);

            Tools = new int[Rows, Columns];


            for (int i = 2; i < fileContent.Length; i += 3)
            {
                int row, column, toolType;
                if (int.TryParse(fileContent[i].Trim(), out row) && int.TryParse(fileContent[i + 1].Trim(), out column) && int.TryParse(fileContent[i + 2].Trim(), out toolType))
                {
                    Tools[row, column] = toolType;
                    switch (toolType)
                    {
                        case 2:
                            RedDoors += 1;
                            break;
                        case 6:
                            RedBoxes += 1;
                            break;
                        case 3:
                            GreenDoors += 1;
                            break;
                        case 7:
                            GreenBoxes += 1;
                            break;
                        default:
                            break;
                    }
                }
            }

            // If the number of boxes and doors are not equivalent, throw an error.
        }

        public int? GetToolFromPictureBox(int row, int column)
        {
            if (IsValidMove(row, column)) { return Tools[row, column]; }
            else { return null;  }
        }

        public void UpdateGameBoard(int row, int column, int tool)
        {
            Tools[row, column] = tool;
        }

        public bool IsRedBox(NewPictureBox box)
        {
            if (box.Tool == 6) { return true; }
            return false;
        }
        public bool IsGreenBox(NewPictureBox box)
        {
            if (box.Tool == 7) { return true; }
            return false;
        }

        public bool IsValidMove(int targetRow, int targetColumn)
        {
            return targetRow >= 0 && targetRow < Rows && targetColumn >= 0 && targetColumn < Columns;
        }

        public bool IsCollidedWithSameColorDoor(NewPictureBox currentSelectedBox, int targetRow, int targetColumn)
        {
            return (IsRedBox(currentSelectedBox) && (GetToolFromPictureBox(targetRow, targetColumn) == 2)) || ((IsGreenBox(currentSelectedBox)) && ((GetToolFromPictureBox(targetRow, targetColumn) == 3)));

        }
    }
}
