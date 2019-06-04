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
    [Serializable]
    public class CheckIn : ProcessUnit
    {
        public static int id;
        public int Id { get; private set; }
        public int baggageInCheckIn = 0;
        public DateTime startOfBaggageTransfer;

        public int DestinationGate { get; set; }

        public CheckIn()
        {
            id++;
            this.Id = id;
        }

        public override void ProcessBaggage()
        {
            if (NextNode.Status == BaggageStatus.Free)
            {
                NextNode.PassBaggage(baggage);
                Status = BaggageStatus.Free;
                if (baggageInCheckIn == 1)
                {
                    startOfBaggageTransfer = DateTime.Now;
                }
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
            baggage = Lastbaggage;
            baggageInCheckIn++;
            ProcessBaggage();
        }
        public override string ToString()
        {
            return $"Check-In [#{Id}]";
        }
    }
}
