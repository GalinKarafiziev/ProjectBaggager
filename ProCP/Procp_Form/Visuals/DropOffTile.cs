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
            img = loadImage(imgpath, img);

            fillBrush = clickableColor;
        }

        protected override void DrawTileInfo(Graphics g, RectangleF r)
        {
            Font stringFont = new Font("Arial", height / 3, FontStyle.Bold, GraphicsUnit.Pixel);
            DropOff dropOff = nodeInGrid as DropOff;
            string gateId = Convert.ToString(dropOff.DestinationGate);
            string baggages = Convert.ToString(dropOff.baggages.Count());
            string capacity = Convert.ToString(dropOff.baggages.Capacity);
            //g.DrawString($"Gate: {gateId}", stringFont, Brushes.Red, r);
            g.DrawString($"Gate: {gateId} - {baggages} / {capacity}", stringFont, Brushes.Red, r);
        }
    }
}
