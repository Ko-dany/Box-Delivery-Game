/*
 * Program: PROG2370-SEC4 Game Programming
 * Purpose: Assignment 2
 * Revision History:
 *      created by Dahyun Ko, Oct/31/2023
 */

using DKoQGame;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameDesign
{
    public class DesignManager : IDesignManager
    {
        public NewPictureBox[,] Board { get; set; }
        public int Rows { get; set; }
        public int Columns { get; set; }
        public string FileSaveInfo {  get; set; }
        public string FileContent { get; set; }

        public void InitializeBoard(int rows, int columns)
        {
            Board = new NewPictureBox[rows, columns];
            Rows = rows; 
            Columns = columns;
        }

        public void CreatePictureBoxData(int row, int column, NewPictureBox pictureBox)
        {
            Board[row, column] = pictureBox;
        }

        public void StoreToolData(int row, int column, int tool)
        {
            Board[row, column].Tool = tool;
        }

        public void SaveFile()
        {
            FileContent = "";
            int walls = 0, doors = 0, boxes = 0;

            FileContent += $"{Rows}\n" + $"{Columns}\n";    //Rows and columns of the grid

            for (int row=0; row < Rows; row++)
            {
                for(int col=0; col < Columns; col++)
                {
                    int tool = Board[row, col].Tool;

                    FileContent += $"{row}\n"+ $"{col}\n"+ $"{tool}\n";     //Row, column and tool info for each slot

                    switch (tool)
                    {
                        case 1:
                            walls += 1;
                            break;
                        case 2:
                        case 3:
                            doors += 1;
                            break;
                        case 6:
                        case 7:
                            boxes += 1;
                            break;
                        default:
                            break;
                    }
                }
            }

            FileSaveInfo = $"File saved successfully.\n"
                +$"Total number of walls: {walls}\n"
                + $"Total number of doors: {doors}\n"
                + $"Total number of boxes: {boxes}\n";
        }

    }
}
