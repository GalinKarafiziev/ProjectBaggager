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
    [Serializable]
    public class GridTile
    {
        protected int column;
        protected int row;
        protected int width;
        protected int height;

        public Node nodeInGrid;

        public bool selected = false;

        private bool unclickable = false;
        protected GridTile nextTile;
        [NonSerialized]
        public Brush fillBrush;
        [NonSerialized]
        public Brush clickableColor;
        [NonSerialized]
        public Brush unclickableColour;


        protected Image img;
        protected string imgpath;

        public GridTile(int column, int row, int tileWidth, int tileHeight)
        {
            this.column = column;
            this.row = row;
            width = tileWidth;
            height = tileHeight;
        }

        public int Column
        {
            get { return column; }
        }
        public int Row
        {
            get { return row; }
        }
        protected void loadImage(string path)
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
        public bool Unselectable
        {
            get { return unclickable; }
            set { unclickable = value; }
        }
        public virtual void DrawTile(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen p = new Pen(Color.Red);
            RectangleF r = new RectangleF(column * width, row * height, width, height);

            DrawBackground(p, g, r);
            DrawArrowNext(p, g);
            DrawBaggage(g);
            DrawTileInfo(g, r);
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

        protected virtual void DrawBackground(Pen p, Graphics g, RectangleF r)
        {
            g.FillRectangle(fillBrush, r);
            g.DrawImage(img, r);
            g.DrawRectangle(p, column * width, row * height, width, height);

            if (selected)
            {
                p = new Pen(Color.Yellow);
                g.DrawRectangle(p, column * width, row * height, width, height);
            }
        }

        protected virtual void DrawArrowNext(Pen p, Graphics g)
        {
            if (nextTile != null)
            {
                if (nextTile.column < this.column)
                {
                    p = new Pen(Color.Red);
                    g.DrawLine(p, (column * width + width / 2), (row * height + height / 2), column * width, row * height + height / 2);
                }
                else if (nextTile.column > this.column)
                {
                    p = new Pen(Color.Red);
                    g.DrawLine(p, (column * width + width / 2), (row * height + height / 2), column * width + width, row * height + height / 2);
                }
                else if (nextTile.row < this.row)
                {
                    p = new Pen(Color.Red);
                    g.DrawLine(p, (column * width + width / 2), (row * height + height / 2), column * width + width / 2, row * height);
                }
                else if (nextTile.row > this.row)
                {
                    p = new Pen(Color.Red);
                    g.DrawLine(p, (column * width + width / 2), (row * height + height / 2), column * width + width / 2, row * height + height);
                }
            }
        }
        // Baggage moves in different ways through the nodes
        // Therefore checking wether to draw also happens in different ways
        protected virtual void DrawBaggage(Graphics g)
        {
            if (nodeInGrid != null)
            {
                if (nodeInGrid.Status == BaggageStatus.Busy)
                {
                    g.FillRectangle(Brushes.DarkGoldenrod, column * width + 10, row * height + 10, width - 20, height - 20);
                }
            }
        }
        protected virtual void DrawTileInfo(Graphics g, RectangleF r)
        {

        }

        public virtual void SetNextTile(GridTile t)
        {
            nextTile = t;
        }
        public GridTile NextTile
        {
            get { return nextTile; }
        }
        public virtual void ClearNextTile()
        {
            nextTile = null;
        }
    }
}
