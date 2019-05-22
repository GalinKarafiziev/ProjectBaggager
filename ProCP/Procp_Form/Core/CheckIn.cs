using Procp_Form.CoreAbstraction;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Procp_Form.Core
{
    public class CheckIn : ProcessUnit
    {
        public int baggageInCheckIn = 0;
        public DateTime startOfBaggageTransfer;

        public int DestinationGate { get; set; }

        public CheckIn()
        {

        }

        public override void ProcessBaggage()
        {
            if (NextNode.Status == BaggageStatus.Free)
            {
                NextNode.PassBaggage(baggage);
                if (baggageInCheckIn == 1)
                {
                    startOfBaggageTransfer = DateTime.Now;
                }
                Status = BaggageStatus.Free;
                NextNode.OnNodeStatusChangedToFree -= ProcessBaggage;
            }
            else
            {
                NextNode.OnNodeStatusChangedToFree += ProcessBaggage;
            }
        }

        public override void PassBaggage(Baggage Lastbaggage)
        {
            Status = BaggageStatus.Busy;
            baggageInCheckIn++;
            baggage = Lastbaggage;
            ProcessBaggage();
        }
    }
}
