using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProCP.models
{
    public class ConveyorLine : Node
    {
        public List<Baggage> conveyorBelt;
        private int capacity;
        Baggage lastBag;

        public ConveyorLine(int conveyorLineCapacity)
        {
            conveyorBelt = new List<Baggage>();
            capacity = conveyorLineCapacity;
            conveyorBelt.Capacity = capacity;
        }
        public void Move()
        {
            Status = BaggageStatus.Busy;
            lastBag = conveyorBelt.Last();

            if (conveyorBelt.Count == conveyorBelt.Capacity)
            {
                foreach (Baggage b in conveyorBelt.ToList())
                {
                    if (NextNode.Status == BaggageStatus.Free)
                    {
                        Thread.Sleep(1000);
                        NextNode.PassBaggage(lastBag);
                        conveyorBelt.Remove(lastBag);
                        Status = BaggageStatus.Free;
                    }
                }
            }
            else
            {
                Thread.Sleep(1000);
                Status = BaggageStatus.Free;
            }
        }
        public override void PassBaggage(Baggage lastbaggage)
        {
            conveyorBelt.Add(lastbaggage);
            Parallel.Invoke(() => Move());
        }
    }
}
