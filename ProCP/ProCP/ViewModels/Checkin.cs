using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProCP.viewModels
{
    public class Checkin : ProcessUnit
    {
        public Baggage baggage { get; set; }
        public int ProcessTime { get; set; }
        public bool IsActive { get; set; }
        public Checkin(int processingTime)
        {
            this.ProcessTime = processingTime;
            this.IsActive = true;
        }

        public override void ProcessBaggage()
        {
            Status = BaggageStatus.Busy;

            if (nextNode.Status == BaggageStatus.Free)
            {
                Thread.Sleep(ProcessTime);
                nextNode.PassBaggage(baggage);
                Status = BaggageStatus.Free;
            }
            else
            {
                Thread.Sleep(500);
                Status = BaggageStatus.Free;
            }
        }

        public override void PassBaggage(Baggage Lastbaggage)
        {
            baggage = Lastbaggage;
            Parallel.Invoke(() => ProcessBaggage());
        }
    }
}
