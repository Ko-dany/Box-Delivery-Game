using DKoQGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameDesign
{
    public interface IGameManager
    {
        void InitializeBoard(int rows, int columns);
        void CreatePictureBoxData(int row, int column, NewPictureBox pictureBox);
        void StoreToolData(int row, int column, int tool);
    }
}
