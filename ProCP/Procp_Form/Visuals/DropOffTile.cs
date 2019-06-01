using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Procp_Form.Visuals
{
    class DropOffTile : GridTile
    {
        public DropOffTile()
        {
            clickableColor = Brushes.SlateGray;
            unclickableColour = Brushes.DarkSlateGray;

            imgpath = "../../Resources/dropoff.png";
            img = Image.FromFile(imgpath);

            fillBrush = clickableColor;
        }
    }
}
