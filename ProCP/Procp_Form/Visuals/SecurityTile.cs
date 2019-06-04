using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procp_Form.Visuals
{
    [Serializable]
    public class SecurityTile : GridTile
    {
        public SecurityTile()
        {
            clickableColor = Brushes.White;
            unclickableColour = Brushes.LightGray;

            imgpath = "../../Resources/security.png";
            img = Image.FromFile(imgpath);

            fillBrush = clickableColor;
        }
    }
}
