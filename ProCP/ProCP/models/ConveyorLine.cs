using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProCP.models
{
    public class ConveyorLine : TrasportUnit
    {
        public ConveyorLine(int capacity):base()
        {
            conveyorBelt.Capacity = capacity;
            lastBag = conveyorBelt.Last();
        }
        public override void PassBaggage(Baggage lastbaggage)
        {
            conveyorBelt.Add(lastbaggage);
        }
    }
}
