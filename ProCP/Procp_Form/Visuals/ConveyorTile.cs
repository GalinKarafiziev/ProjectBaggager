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
    class ConveyorTile : GridTile
    {
        public int PositionInLine;

        public bool isLastTile;
        public ConveyorTile(int column, int row, int tileWidth, int tileHeight) : base(column, row, tileWidth, tileHeight)
        {
            this.column = column;
            this.row = row;
            width = tileWidth;
            height = tileHeight;

            clickableColor = Brushes.SeaGreen;
            unclickableColour = Brushes.DarkSeaGreen;

            fillBrush = clickableColor;

            imgpath = "../../Resources/conveyor.png";
            loadImage(imgpath);

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
                            g.FillRectangle(Brushes.DarkGoldenrod, Column * width + 10, Row * height + 10, width - 20, height - 20);
                            //System.Diagnostics.Debug.Write("con tyle" + PositionInLine + "  ");
                        }
                    }
                }
            }
        }
    }
}
