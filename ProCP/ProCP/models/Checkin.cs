using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProCP.models
{
    public class Checkin : ProcessUnit
    {
        public Baggage Baggage { get; set; }
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

            if (NextNode.Status == BaggageStatus.Free)
            {
                Thread.Sleep(ProcessTime);
                NextNode.PassBaggage(Baggage);
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
            Baggage = Lastbaggage;
            Parallel.Invoke(() => ProcessBaggage());
        }
    }
}
