using Procp_Form.Core;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Procp_Form.Visuals
{
    [Serializable]
    public class CheckInTile : GridTile
    {
        public CheckInTile(int column, int row, int tileWidth, int tileHeight) : base(column, row, tileWidth, tileHeight)
        {
            this.column = column;
            this.row = row;
            width = tileWidth;
            height = tileHeight;

            clickableColor = Brushes.White;
            unclickableColour = Brushes.LightGray;

            imgpath = "../../Resources/checkin.png";
            img = loadImage(imgpath, img);

            fillBrush = clickableColor;
        }

        protected override void DrawTileInfo(Graphics g, RectangleF r)
        {
            Font stringFont = new Font("Arial", height/3, FontStyle.Bold, GraphicsUnit.Pixel);
            CheckIn c = nodeInGrid as CheckIn;
            string s = Convert.ToString(c.Id);
            g.DrawString("ID: " + s, stringFont, Brushes.Red, r);
        }
    }
}
