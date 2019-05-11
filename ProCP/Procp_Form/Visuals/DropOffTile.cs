using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Procp_Form.Visuals
{
    class DropOffTile : GridTile
    {
        public DropOffTile()
        {
            fillBrush = Brushes.SlateGray;
        }

        public override void DrawTile(PaintEventArgs e, float width, float height)
        {
            Graphics g = e.Graphics;
            Pen p = new Pen(Color.Red);

            g.FillRectangle(fillBrush, Column * width, Row * height, width, height);
            g.DrawRectangle(p, Column * width, Row * height, width, height);
        }

        public override void SetTileUncklicableColor()
        {
            if (Unclickable)
            {
                fillBrush = Brushes.DarkSlateGray;
            }
            else
            {
                fillBrush = Brushes.SlateGray;
            }
        }
    }
}
