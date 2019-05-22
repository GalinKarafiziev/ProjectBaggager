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
        public Queue<Baggage> bufferNotSecure;

        public Security()
        {
            bufferNotSecure = new Queue<Baggage>();
        }

        public override void ProcessBaggage()
        {
            Status = BaggageStatus.Busy;
            if (NextNode.Status == BaggageStatus.Free)
            {
                if (baggage.Secure == 2 || baggage.Secure == 7)
                {
                    bufferNotSecure.Enqueue(baggage);
                    NextNode.OnNodeStatusChangedToFree -= ProcessBaggage;
                    Status = BaggageStatus.Free;
                }
                else
                {
                    if (bufferNotSecure.Count() != 0)
                    {
                        ReturnFromBuffer();
                    }
                    NextNode.PassBaggage(baggage);
                    NextNode.OnNodeStatusChangedToFree -= ProcessBaggage;
                    Status = BaggageStatus.Free;
                }
            }
            else
            {
                NextNode.OnNodeStatusChangedToFree += ProcessBaggage;
                if (bufferNotSecure.Count() != 0)
                {
                    NextNode.OnNodeStatusChangedToFree += ReturnFromBuffer;
                }
            }
        }
        
        public void ReturnFromBuffer()
        {
            NextNode.PassBaggage(bufferNotSecure.Dequeue());
            NextNode.OnNodeStatusChangedToFree -= ReturnFromBuffer;
        }

        public override void PassBaggage(Baggage Lastbaggage)
        {
            Status = BaggageStatus.Busy;
            baggage = Lastbaggage;
            ProcessBaggage();
        }
    }
}
