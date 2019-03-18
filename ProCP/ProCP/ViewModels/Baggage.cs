using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProCP.ViewModels
{
    public class Baggage
    {
        public int DestinationGate { get; private set; }

        public Baggage(int destinationGate)
        {
            this.DestinationGate = destinationGate;
        }

    }
}
