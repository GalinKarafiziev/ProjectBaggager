using Procp_Form.CoreAbstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Procp_Form.Core
{
    public class Security : ProcessUnit
    {
        public List<Baggage> bufferNotSecure;
        public Security()
        {
            bufferNotSecure = new List<Baggage>();
        }

        public override void ProcessBaggage()
        {
            Status = BaggageStatus.Busy;
            if (NextNode.Status == BaggageStatus.Free)
            {
                if (baggage.Secure == 5 || baggage.Secure == 7)
                {
                    bufferNotSecure.Add(baggage);
                    Thread.Sleep(1000);
                    NextNode.OnNodeStatusChangedToFree -= ProcessBaggage;
                    Status = BaggageStatus.Free;
                }
                else
                {
                    NextNode.PassBaggage(baggage);
                    Thread.Sleep(1000);
                    NextNode.OnNodeStatusChangedToFree -= ProcessBaggage;
                    Status = BaggageStatus.Free;
                }
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
