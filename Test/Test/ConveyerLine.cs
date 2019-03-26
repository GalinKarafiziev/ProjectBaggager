using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Test
{
    public class ConveyerLine : Node
    {
        public List<Baggage> conveyorBelt;
        Baggage lastBag;
        public ConveyerLine()
        {
            conveyorBelt = new List<Baggage>();
        }
        public void Move()
        {
            lastBag = conveyorBelt.Last();
            if (lastBag != null && nextNode != null)
            {
                nextNode.PassBaggage(lastBag);
            }
            
        }
        public override void PassBaggage(Baggage lastbaggage)
        {
            conveyorBelt.Add(lastbaggage);
            Move();
            Status = BaggageStatus.Free;
        }
    }
}
