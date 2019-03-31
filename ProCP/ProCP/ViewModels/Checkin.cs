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
        public Baggage baggage;
        public bool IsActive { get; set; }

        public int ProcessingTime { get; set; }

        public Checkin(double processingTime)
        {
            //timer.Interval = processingTime;
            this.IsActive = true;
        }

        public override Baggage ProcessBaggage(Baggage baggage)
        {
            this.baggage = baggage;
            if (baggage != null)
            {
                Thread.Sleep(1000);
                return baggage;
            }
            return null;
        }

        public override void PassBaggage(Baggage Lastbaggage)
        {
            ProcessBaggage(Lastbaggage);
            nextNode.PassBaggage(Lastbaggage);
            Status = BaggageStatus.Free;
        }
    }
}
