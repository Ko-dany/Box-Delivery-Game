/*
 * Program: PROG2370-SEC4 Game Programming
 * Purpose: Assignment 2
 * Revision History:
 *      created by Dahyun Ko, Oct/31/2023
 */

using DKoQGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameDesign
{
    public interface IDesignManager
    {
        void InitializeBoard(int rows, int columns);
        void CreatePictureBoxData(int row, int column, NewPictureBox pictureBox);
        void StoreToolData(int row, int column, int tool);
        void SaveFile();
    }
}
