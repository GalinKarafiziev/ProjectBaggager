using Procp_Form.CoreAbstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Procp_Form.Visuals
{
    class GridTile
    {
        private int column;
        private int row;

        public Node nodeInGrid;

        private bool unclickable = false;
        public Brush fillBrush;
        public Brush clickableColor;
        public Brush unclickableColour;
        
        public int Column
        {
            get { return column; }
            set { column = value; }
        }
        public int Row
        {
            get { return row; }
            set { row = value; }
        }
        public bool Unselectable
        {
            get { return unclickable; }
            set { unclickable = value; }
        }
        public virtual void DrawTile(PaintEventArgs e, float width, float height)
        {
            Graphics g = e.Graphics;
            Pen p = new Pen(Color.Red);

            g.FillRectangle(fillBrush, Column * width, Row * height, width, height);
            g.DrawRectangle(p, Column * width, Row * height, width, height);

            //if (nodeInGrid != null)
            //{
            //    if (nodeInGrid.Status == BaggageStatus.Busy)
            //    {
            //        g.FillRectangle(Brushes.DarkGoldenrod, column * width + 10, row * height + 10, width - 20, height - 20);
            //    }
            //}
        }
        public virtual void SetTileUncklicableColor()
        {
            if (Unselectable)
            {
                fillBrush = unclickableColour;
            }
            else
            {
                fillBrush = clickableColor;
            }
        }
    }
}
