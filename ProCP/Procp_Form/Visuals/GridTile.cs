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
        public bool selected = false;
        public GridTile nextTile;
        public Brush fillBrush;
        public Brush clickableColor;
        public Brush unclickableColour;

        protected Image img;
        protected string imgpath;

        protected void loadImage(string path, int width, int height)
        {
            using (var srce = new Bitmap(path))
            {
                var dest = new Bitmap(width,height, System.Drawing.Imaging.PixelFormat.Format32bppPArgb);
                using (var gr = Graphics.FromImage(dest))
                {
                    gr.DrawImage(srce, new Rectangle(Point.Empty, dest.Size));
                }
                if (img != null) img.Dispose();
                img = dest;
            }
        }

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
            RectangleF r = new RectangleF(Column * width, Row * height, width, height);

            g.FillRectangle(fillBrush, r);
            g.DrawImage(img, r);
            g.DrawRectangle(p, Column * width, Row * height, width, height);

            if(nextTile != null)
            {
                if (nextTile.Column < this.Column)
                {
                    p = new Pen(Color.Red);
                    g.DrawLine(p, (Column * width + width / 2), (Row * height + height / 2), Column * width, Row * height + height / 2);
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
                if (nodeInGrid.Status == BaggageStatus.Busy)
                {
                    g.FillRectangle(Brushes.DarkGoldenrod, column * width + 10, row * height + 10, width - 20, height - 20);
                }
            }
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

        public void ConnectNext(GridTile t)
        {
            nextTile = t;
        }
    }
}
