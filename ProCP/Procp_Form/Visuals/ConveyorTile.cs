﻿using Procp_Form.Core;
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
        public ConveyorTile(int tileWidth, int tileHeight)
        {
            clickableColor = Brushes.White;
            unclickableColour = Brushes.LightGray;

            fillBrush = clickableColor;

            imgpath = "../../Resources/conveyor.png";
            loadImage(imgpath, tileWidth, tileHeight);

            isLastTile = false;
        }

        public override void DrawTile(PaintEventArgs e, float width, float height)
        {
            Graphics g = e.Graphics;
            Pen p = new Pen(Color.DarkSlateGray);
            RectangleF r = new RectangleF(Column * width, Row * height, width, height);

            g.FillRectangle(fillBrush, r);
            g.DrawImage(img, r);
            g.DrawRectangle(p, Column * width, Row * height, width, height);

            if (nextTile != null)
            {
                if (nextTile.Column < this.Column)
                {
                    p = new Pen(Color.Red);
                    g.DrawLine(p, (Column * width + width/2), (Row * height + height/2), Column * width, Row * height + height / 2);
                }
                else if (nextTile.Column > this.Column)
                {
                    p = new Pen(Color.Red);
                    g.DrawLine(p, (Column * width + width / 2), (Row * height + height / 2), Column * width + width, Row * height + height / 2);
                }
                else if (nextTile.Row < this.Row)
                {
                    p = new Pen(Color.Red);
                    g.DrawLine(p, (Column * width + width / 2), (Row * height + height / 2), Column * width + width / 2, Row * height);
                }
                else if (nextTile.Row > this.Row)
                {
                    p = new Pen(Color.Red);
                    g.DrawLine(p, (Column * width + width / 2), (Row * height + height / 2), Column * width + width / 2, Row * height + height);
                }
            }

            if (selected)
            {
                p = new Pen(Color.Yellow);
                g.DrawRectangle(p, Column * width, Row * height, width, height);
            }

            if (nodeInGrid != null)
            {
                Conveyor conv = (Conveyor)nodeInGrid;
                int count = conv.conveyorBelt.Length;
                for (int i = 0; i < count; i++) {
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
