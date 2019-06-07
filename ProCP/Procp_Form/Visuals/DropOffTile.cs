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
            width = tileWidth;
            height = tileHeight;

            clickableColor = Brushes.White;
            unclickableColour = Brushes.LightGray;

            imgpath = "../../Resources/dropoff.png";
            img = Image.FromFile(imgpath);

            fillBrush = clickableColor;
        }

        protected override void DrawTileInfo(Graphics g, RectangleF r)
        {
            Font stringFont = new Font("Arial", height / 3, FontStyle.Bold, GraphicsUnit.Pixel);
            DropOff d = nodeInGrid as DropOff;
            string s = Convert.ToString(d.DestinationGate);
            g.DrawString("Gate: " + s, stringFont, Brushes.Red, r);
        }
    }
}
