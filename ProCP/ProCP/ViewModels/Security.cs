using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProCP.viewModels
{
    public class Security: ProcessUnit
    {
        public Baggage baggage;

        public List<Baggage> bufferNotSecure;
        public int ProcessingTime { get; set; }

        public Security(double processingTime)
        {
            //timer.Interval = processingTime;
            bufferNotSecure = new List<Baggage>();
        }

        public override Baggage ProcessBaggage(Baggage baggage)
        {
            this.baggage = baggage;
            if (baggage.Secure == 5 && baggage.Secure == 7)
            {
                Thread.Sleep(2000);
                bufferNotSecure.Add(baggage);
            }
            else
            {
                Thread.Sleep(2000);
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
