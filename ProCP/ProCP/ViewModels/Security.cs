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
        public Baggage baggage { get; set; }

        public List<Baggage> bufferNotSecure;
        public int ProcessingTime { get; set; }

        public SecurityUnit(int processingTime)
        {
            ProcessingTime = processingTime;
            bufferNotSecure = new List<Baggage>();
        }

        public override void ProcessBaggage()
        {
            Status = BaggageStatus.Busy;
            this.baggage = baggage;

            if (nextNode.Status == BaggageStatus.Free)
            {
                if (baggage.Secure == 5 && baggage.Secure == 7)
                {
                    Thread.Sleep(ProcessingTime);
                    bufferNotSecure.Add(baggage);
                    this.Status = BaggageStatus.Free;
                }
                else
                {
                    Thread.Sleep(ProcessingTime);
                    nextNode.PassBaggage(baggage);
                    this.Status = BaggageStatus.Free;
                }
            }
            else
            {
                Thread.Sleep(1000);
                ProcessBaggage();
            }
        }

        public override void PassBaggage(Baggage Lastbaggage)
        {
            this.baggage = Lastbaggage;
            ProcessBaggage();
        }
    }
}
