using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DKoQGame
{
    internal interface IPlayManager
    {
        void InitializeGameBoard();

        void GetGameBoardInfoFromFile(string[] fileContent);

        int? GetToolFromPictureBox(int row, int column);

        void UpdateGameBoard(int row, int column, int tool);

        bool IsRedBox(NewPictureBox box);

        bool IsGreenBox(NewPictureBox box);

        bool IsValidMove(int targetRow, int targetColumn);

        bool IsCollidedWithSameColorDoor(NewPictureBox currentSelectedBox, int targetRow, int targetColumn);
    }
}
