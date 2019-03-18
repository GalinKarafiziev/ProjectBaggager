using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProCP.ViewModels
{
    public class ConveyerSlot : Figure
    {
        public Baggage Baggage { get; set; }

        public ConveyerSlot(int size, int x, int y) : base(size, x, y)
        {

        }
        public bool IsFree() {
            if(this.Baggage != null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
