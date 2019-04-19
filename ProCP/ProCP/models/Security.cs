using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProCP.models
{
    public class SecurityUnit: ProcessUnit
    {
        public Baggage Baggage { get; set; }

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
            this.Baggage = Baggage;

            if (NextNode.Status == BaggageStatus.Free)
            {
                if (Baggage.Secure == 5 && Baggage.Secure == 7)
                {
                    Thread.Sleep(ProcessingTime);
                    bufferNotSecure.Add(Baggage);
                    this.Status = BaggageStatus.Free;
                }
                else
                {
                    Thread.Sleep(ProcessingTime);
                    NextNode.PassBaggage(Baggage);
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
            this.Baggage = Lastbaggage;
            ProcessBaggage();
        }
    }
}
