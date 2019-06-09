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


        protected string imgpath;
        protected Image img;

        protected string baggageImgPath;
        protected Image baggageImg;

        protected string arrowImgPath;
        protected Image arrowImg;
        public GridTile(int column, int row, int tileWidth, int tileHeight)
        {
            this.column = column;
            this.row = row;
            baggageImgPath = "../../Resources/baggage.png";
            baggageImg = Image.FromFile(baggageImgPath);
            arrowImgPath = "../../Resources/arrow.png";
            arrowImg = Image.FromFile(arrowImgPath);
        }

        public int Column
        {
            get { return column; }
        }
        public int Row
        {
            get { return row; }
        }
        protected Image loadImage(string path, Image imig, int tileWidth, int tileHeight)
        {
            using (var srce = new Bitmap(path))
            {
                var dest = new Bitmap(tileWidth, tileHeight, System.Drawing.Imaging.PixelFormat.Format32bppPArgb);
                using (var gr = Graphics.FromImage(dest))
                {
                    gr.DrawImage(srce, new Rectangle(Point.Empty, dest.Size));
                }
                if (imig != null) img.Dispose();
                imig = dest;
            }
            return imig;
        }
        public bool Unselectable
        {
            get { return unclickable; }
            set { unclickable = value; }
        }
        public virtual void DrawTile(PaintEventArgs e, int tileWidth, int tileHeight)
        {
            Graphics g = e.Graphics;
            Pen p = new Pen(Color.LightSteelBlue);
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
            //g.FillRectangle(fillBrush, r);

            //this rotateflip doesnt serve any purpose
            //we used it to test rotating images
            //it works in mysterious ways, for some reason it is bound to mouse movement
            //img.RotateFlip(RotateFlipType.Rotate90FlipNone);


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
                int arrowWidth = tileWidth / 4;
                int arrowHeight = tileHeight / 4;

                //what the hell
                int arrowX = column * tileWidth + tileWidth / 2 - arrowWidth/2;
                int arrowY = row * tileHeight + tileHeight / 2 - arrowHeight/2;
                if (nextTile.column < this.column)
                {
                    p = new Pen(Color.Red);
                    //g.DrawLine(p, (column * tileWidth + tileWidth / 2), (row * tileHeight + tileHeight / 2), column * tileWidth, row * tileHeight + tileHeight / 2);
                    Rectangle r = new Rectangle(arrowX, arrowY, arrowWidth, arrowHeight);
                    g.DrawImage(arrowImg, r);
                }
                else if (nextTile.column > this.column)
                {
                    p = new Pen(Color.Red);
                    Rectangle r = new Rectangle(arrowX, arrowY, arrowWidth, arrowHeight);
                    g.DrawImage(arrowImg, r);
                    // g.DrawLine(p, (column * tileWidth + tileWidth / 2), (row * tileHeight + tileHeight / 2), column * tileWidth + tileWidth, row * tileHeight + tileHeight / 2);
                }
                else if (nextTile.row < this.row)
                {
                    p = new Pen(Color.Red);
                    Rectangle r = new Rectangle(arrowX, arrowY, arrowWidth, arrowHeight);
                    g.DrawImage(arrowImg, r);
                    // g.DrawLine(p, (column * tileWidth + tileWidth / 2), (row * tileHeight + tileHeight / 2), column * tileWidth + tileWidth / 2, row * tileHeight);
                }
                else if (nextTile.row > this.row)
                {
                    p = new Pen(Color.Red);
                    Rectangle r = new Rectangle(arrowX, arrowY, arrowWidth, arrowHeight);
                    g.DrawImage(arrowImg, r);
                    // g.DrawLine(p, (column * tileWidth + tileWidth / 2), (row * tileHeight + tileHeight / 2), column * tileWidth + tileWidth / 2, row * tileHeight + tileHeight);
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
                    RectangleF baggageRec = new RectangleF(column * tileWidth + 10, row * tileHeight + 10, tileWidth - 20, tileHeight - 20);
                    g.DrawImage(baggageImg, baggageRec);
                }
            }
        }
        protected virtual void DrawTileInfo(Graphics g, RectangleF r, int tileHeight)
        {

        }

        public virtual void SetNextTile(GridTile t)
        {
            nextTile = t;
            if (nextTile.column < this.column)
            {
                arrowImg.RotateFlip(RotateFlipType.Rotate90FlipNone);
            }
            else if (nextTile.column > this.column)
            {
                arrowImg.RotateFlip(RotateFlipType.Rotate270FlipNone);
            }
            else if (nextTile.row < this.row)
            {
                arrowImg.RotateFlip(RotateFlipType.Rotate180FlipNone);
            }
            else if (nextTile.row > this.row)
            {
                
            }
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
