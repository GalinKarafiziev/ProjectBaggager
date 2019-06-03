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
        public int checkInId;
        public CheckInTile(int column, int row, int tileWidth, int tileHeight) : base(column, row, tileWidth, tileHeight)
        {
            this.column = column;
            this.row = row;
            width = tileWidth;
            height = tileHeight;

            clickableColor = Brushes.PaleVioletRed;
            unclickableColour = Brushes.MediumVioletRed;

            imgpath = "../../Resources/checkin.png";
            loadImage(imgpath);

            fillBrush = Brushes.PaleVioletRed;
        }
    }
}
