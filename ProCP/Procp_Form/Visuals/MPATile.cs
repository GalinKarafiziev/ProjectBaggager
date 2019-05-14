using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procp_Form.Visuals
{
    class MPATile : GridTile
    {
        public MPATile()
        {
            clickableColor = Brushes.Purple;
            unclickableColour = Brushes.MediumPurple;

            fillBrush = Brushes.Purple;
        }
    }
}
