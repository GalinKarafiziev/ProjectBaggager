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
    abstract class GridTile
    {
        private int column;
        private int row;

        public Node nodeInGrid;

        private bool unclickable = false;
        public Brush fillBrush;

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
        public bool Unclickable
        {
            get { return unclickable; }
            set { unclickable = value; }
        }
        public abstract void DrawTile(PaintEventArgs e, float width, float height);
        public abstract void SetTileUncklicableColor();
    }
}
