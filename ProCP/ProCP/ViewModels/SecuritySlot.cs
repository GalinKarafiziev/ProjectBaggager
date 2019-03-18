using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProCP.ViewModels
{
    class SecuritySlot : ConveyerSlot
    {
        public int Employees { get; set; }
        //List with baggage to be checked?

        public SecuritySlot(int size, int x, int y) : base(size, x, y)
        {

        }
        public void CheckBaggage(Baggage baggage)
        {

        }
    }
}
