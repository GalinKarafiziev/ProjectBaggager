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
            clickableColor = Brushes.Yellow;
            unclickableColour = Brushes.Yellow;

            fillBrush = Brushes.Yellow;
        }
    }
}
