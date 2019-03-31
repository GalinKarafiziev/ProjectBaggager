using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProCP.viewModels
{
    public class ConveyorLine:Node
    {
        public List<Baggage> conveyorBelt;
        Baggage lastBag;
        public ConveyorLine()
        {
            conveyorBelt = new List<Baggage>();
        }   
        public void Move()
        {
            lastBag = conveyorBelt.Last();
            if (lastBag != null && nextNode != null)
            {
                nextNode.PassBaggage(lastBag);
                conveyorBelt.Remove(lastBag);
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
