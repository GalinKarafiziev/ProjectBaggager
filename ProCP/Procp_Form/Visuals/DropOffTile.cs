using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Procp_Form.Visuals
{
    [Serializable]
    public class DropOffTile : GridTile
    {
        public DropOffTile()
        {
            clickableColor = Brushes.SlateGray;
            unclickableColour = Brushes.DarkSlateGray;

            fillBrush = clickableColor;
        }
    }
}
