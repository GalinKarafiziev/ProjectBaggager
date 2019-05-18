using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procp_Form.Visuals
{
    class SecurityTile : GridTile
    {
        public SecurityTile()
        {
            clickableColor = Brushes.Blue;
            unclickableColour = Brushes.DarkBlue;

            fillBrush = Brushes.Blue;
        }
    }
}
