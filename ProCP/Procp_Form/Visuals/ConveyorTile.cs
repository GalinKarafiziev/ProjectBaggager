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
    public class ConveyorTile : GridTile
    {
        public int PositionInLine;

        public bool isLastTile;
        public ConveyorTile(int column, int row, int tileWidth, int tileHeight) : base(column, row, tileWidth, tileHeight)
        {
            this.column = column;
            this.row = row;
            width = tileWidth;
            height = tileHeight;

            clickableColor = Brushes.White;
            unclickableColour = Brushes.LightGray;

            fillBrush = clickableColor;

            imgpath = "../../Resources/conveyor.png";
            img = loadImage(imgpath, img);

            isLastTile = false;
        }

        protected override void DrawBaggage(Graphics g)
        {
            if (nodeInGrid != null)
            {
                Conveyor conv = (Conveyor)nodeInGrid;
                int count = conv.conveyorBelt.Length;
                for (int i = 0; i < count; i++)
                {
                    if (i == PositionInLine)
                    {
                        if (conv.conveyorBelt[i] != null)
                        {
                            RectangleF baggageRec = new RectangleF(column * width + 3, row * height + 3, width - 6, height - 6);
                            g.DrawImage(baggageImg, baggageRec);
                        }
                    }
                }
            }
        }
    }
}
