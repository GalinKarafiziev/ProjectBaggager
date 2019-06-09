﻿using Procp_Form.CoreAbstraction;
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
        }

        public int Column
        {
            get { return column; }
        }
        public int Row
        {
            get { return row; }
        }
        protected void loadImage(string path, int tileWidth, int tileHeight)
        {
            using (var srce = new Bitmap(path))
            {
                var dest = new Bitmap(tileWidth, tileHeight, System.Drawing.Imaging.PixelFormat.Format32bppPArgb);
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
        public virtual void DrawTile(PaintEventArgs e, int tileWidth, int tileHeight)
        {
            Graphics g = e.Graphics;
            Pen p = new Pen(Color.Red);
            RectangleF r = new RectangleF(column * tileWidth, row * tileHeight, tileWidth, tileHeight);

            DrawBackground(p, g, r, tileWidth, tileHeight);
            DrawArrowNext(p, g, tileWidth, tileHeight);
            DrawBaggage(g, tileWidth, tileHeight);
            DrawTileInfo(g, r, tileHeight);
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

        protected virtual void DrawBackground(Pen p, Graphics g, RectangleF r, int tileWidth, int tileHeight)
        {
            g.FillRectangle(fillBrush, r);
            g.DrawImage(img, r);
            g.DrawRectangle(p, column * tileWidth, row * tileHeight, tileWidth, tileHeight);

            if (selected)
            {
                p = new Pen(Color.Yellow);
                g.DrawRectangle(p, column * tileWidth, row * tileHeight, tileWidth, tileHeight);
            }
        }

        protected virtual void DrawArrowNext(Pen p, Graphics g, int tileWidth, int tileHeight)
        {
            if (nextTile != null)
            {
                if (nextTile.column < this.column)
                {
                    p = new Pen(Color.Red);
                    g.DrawLine(p, (column * tileWidth + tileWidth / 2), (row * tileHeight + tileHeight / 2), column * tileWidth, row * tileHeight + tileHeight / 2);
                }
                else if (nextTile.column > this.column)
                {
                    p = new Pen(Color.Red);
                    g.DrawLine(p, (column * tileWidth + tileWidth / 2), (row * tileHeight + tileHeight / 2), column * tileWidth + tileWidth, row * tileHeight + tileHeight / 2);
                }
                else if (nextTile.row < this.row)
                {
                    p = new Pen(Color.Red);
                    g.DrawLine(p, (column * tileWidth + tileWidth / 2), (row * tileHeight + tileHeight / 2), column * tileWidth + tileWidth / 2, row * tileHeight);
                }
                else if (nextTile.row > this.row)
                {
                    p = new Pen(Color.Red);
                    g.DrawLine(p, (column * tileWidth + tileWidth / 2), (row * tileHeight + tileHeight / 2), column * tileWidth + tileWidth / 2, row * tileHeight + tileHeight);
                }
            }
        }
        // Baggage moves in different ways through the nodes
        // Therefore checking wether to draw also happens in different ways
        protected virtual void DrawBaggage(Graphics g, int tileWidth, int tileHeight)
        {
            if (nodeInGrid != null)
            {
                if (nodeInGrid.Status == BaggageStatus.Busy)
                {
                    g.FillRectangle(Brushes.DarkGoldenrod, column * tileWidth + 10, row * tileHeight + 10, tileWidth - 20, tileHeight - 20);
                }
            }
        }
        protected virtual void DrawTileInfo(Graphics g, RectangleF r, int tileHeight)
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
