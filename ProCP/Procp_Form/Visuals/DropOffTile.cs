using Procp_Form.Core;
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
        public DropOffTile(int column, int row, int tileWidth, int tileHeight) : base(column, row, tileWidth, tileHeight)
        {
            this.column = column;
            this.row = row;

            clickableColor = Brushes.SlateGray;
            unclickableColour = Brushes.DarkSlateGray;

            imgpath = "../../Resources/dropoff.png";
            loadImage(imgpath, tileWidth, tileHeight);

            fillBrush = clickableColor;
        }

        protected override void DrawTileInfo(Graphics g, RectangleF r, int tileHeight)
        {
            Font stringFont = new Font("Arial", tileHeight / 3, FontStyle.Bold, GraphicsUnit.Pixel);
            DropOff d = nodeInGrid as DropOff;
            string s = Convert.ToString(d.DestinationGate);
            g.DrawString("Gate: " + s, stringFont, Brushes.Red, r);
        }
    }
}
