using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Procp_Form.Visuals
{
    //clickable color - cyan
    //unclickable color - dark cyan
    
    class EmptyTile : GridTile
    {
        public EmptyTile()
        {
            clickableColor = Brushes.Cyan;
            unclickableColour = Brushes.DarkCyan;

            fillBrush = clickableColor;
        }
        public EmptyTile(int column, int row)
        {
            this.Column = column;
            this.Row = row;

            clickableColor = Brushes.Cyan;
            unclickableColour = Brushes.DarkCyan;

            fillBrush = clickableColor;
        }
    }
}
