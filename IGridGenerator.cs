using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameDesign
{
    public interface IGridGenerator
    {
        void CreateGrid(Form form, int rows, int columns);
        void RemoveGrid(Form form);
    }
}
