using Procp_Form.CoreAbstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Procp_Form.Core
{
    public class CheckIn : ProcessUnit
    {
        public List<Baggage> queue;

        public CheckIn()
        {
            queue = new List<Baggage>();
        }

        public override void ProcessBaggage()
        {
            if (NextNode.Status == BaggageStatus.Free)
            {
                NextNode.PassBaggage(baggage);
                counter--;
                Thread.Sleep(1000);
                baggage = null;
                NextNode.OnNodeStatusChangedToFree -= ProcessBaggage;
                Status = BaggageStatus.Free;
            }
            else
            {
                NextNode.OnNodeStatusChangedToFree += ProcessBaggage;
            }
        }

        public override void PassBaggage(Baggage Lastbaggage)
        {
            Status = BaggageStatus.Busy;
            baggage = Lastbaggage;
            ProcessBaggage();
        }
    }
}
