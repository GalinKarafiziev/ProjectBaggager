using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procp_Form.Visuals
{
    [Serializable]
    public class MPATile : GridTile
    {
        public MPATile(int column, int row, int tileWidth, int tileHeight) : base(column, row, tileWidth, tileHeight)
        {
            this.column = column;
            this.row = row;

            clickableColor = Brushes.Purple;
            unclickableColour = Brushes.MediumPurple;

            imgpath = "../../Resources/mpa.png";
            img = loadImage(imgpath, img);

            fillBrush = Brushes.Purple;
        }
    }
}
