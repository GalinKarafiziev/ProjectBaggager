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
        public List<Baggage> queue;
        public int bagageInCheckIn = 0;
        public Stopwatch stopwatch;

        public CheckIn()
        {
            queue = new List<Baggage>();
            stopwatch = new Stopwatch();
        }

        public override void ProcessBaggage()
        {
            if (NextNode.Status == BaggageStatus.Free)
            {
                NextNode.PassBaggage(baggage);
                Status = BaggageStatus.Free;
                baggage = null;
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
            bagageInCheckIn++;            
            stopwatch.Start();
            baggage = Lastbaggage;
            ProcessBaggage();
        }
    }
}
