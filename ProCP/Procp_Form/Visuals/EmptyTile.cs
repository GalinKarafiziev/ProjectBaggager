using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Procp_Form.Visuals
{

    [Serializable]
    public class EmptyTile : GridTile
    {
        public EmptyTile(int column, int row, int tileWidth, int tileHeight) : base(column, row, tileWidth, tileHeight)
        {
            this.column = column;
            this.row = row;
            width = tileWidth;
            height = tileHeight;

            clickableColor = Brushes.White;
            unclickableColour = Brushes.LightGray;

            imgpath = "../../Resources/empty.png";
            loadImage(imgpath);

            fillBrush = clickableColor;
        }
    }
}
