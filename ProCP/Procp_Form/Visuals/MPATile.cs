﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procp_Form.Visuals
{
    class MPATile : GridTile
    {
        public MPATile(int column, int row, int tileWidth, int tileHeight) : base(column, row, tileWidth, tileHeight)
        {
            this.column = column;
            this.row = row;
            width = tileWidth;
            height = tileHeight;

            clickableColor = Brushes.Purple;
            unclickableColour = Brushes.MediumPurple;

            imgpath = "../../Resources/mpa.png";
            img = Image.FromFile(imgpath);

            fillBrush = Brushes.Purple;
        }
    }
}
