using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Procp_Form.Visuals
{
    //clickable color - cyan
    //unclickable color - dark cyan
    
    class EmptyTile : GridTile
    {
        public EmptyTile()
        {
            fillBrush = Brushes.Cyan;
        }
        public EmptyTile(int column, int row)
        {
            this.Column = column;
            this.Row = row;
            fillBrush = Brushes.Cyan;
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
                fillBrush = Brushes.DarkCyan;
            }
            else
            {
                fillBrush = Brushes.Cyan;
            }
        }
    }
}
