using Procp_Form.CoreAbstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;

namespace Procp_Form.Core
{
    /// <summary>
    /// At this moment security unit excludes the unsecure baggage and doens't return it due to security measures. 
    /// In later stage i will try to add the possibility to return it after certain time.
    /// </summary>
    [Serializable]
    public class Security : ProcessUnit
    {
        public Queue<Baggage> baggageAgainstSecurityPolicy;

        public Security()
        {
            baggageAgainstSecurityPolicy = new Queue<Baggage>();
        }

        public override void ProcessBaggage()
        {
            if (NextNode.Status == BaggageStatus.Free)
            {
                if (baggage.Secure == 2 || baggage.Secure == 7)
                {
                    baggageAgainstSecurityPolicy.Enqueue(baggage);
                    NextNode.OnNodeStatusChangedToFree -= ProcessBaggage;
                }
                else
                {
                    NextNode.PassBaggage(baggage);
                    NextNode.OnNodeStatusChangedToFree -= ProcessBaggage;
                }
            }
            else
            {
                NextNode.OnNodeStatusChangedToFree += ProcessBaggage;
            }
            Status = BaggageStatus.Free;
        }

        public override void PassBaggage(Baggage Lastbaggage)
        {
            Status = BaggageStatus.Busy;
            baggage = Lastbaggage;
            ProcessBaggage();
        }
    }
}
