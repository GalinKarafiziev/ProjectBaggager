using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Procp_Form.Visuals
{
    class CheckInTile : GridTile
    {
        public CheckInTile()
        {
            clickableColor = Brushes.PaleVioletRed;
            unclickableColour = Brushes.MediumVioletRed;

            fillBrush = Brushes.PaleVioletRed;
        }
    }
}
