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
            clickableColor = Brushes.White;
            unclickableColour = Brushes.LightGray;

            imgpath = "../../Resources/dropoff.png";
            img = Image.FromFile(imgpath);

            fillBrush = clickableColor;
        }
    }
}
