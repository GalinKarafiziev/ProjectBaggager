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
    public class CheckInTile : GridTile
    {
        public CheckInTile(int tileWidth, int tileHeight)
        {
            clickableColor = Brushes.PaleVioletRed;
            unclickableColour = Brushes.MediumVioletRed;

            imgpath = "../../Resources/checkin.png";
            loadImage(imgpath, tileWidth, tileHeight);

            fillBrush = Brushes.PaleVioletRed;
        }
    }
}
