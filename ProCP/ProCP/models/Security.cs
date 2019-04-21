using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace ProCP.models
{
    public class SecurityUnit : ProcessUnit
    {
        public List<Baggage> bufferNotSecure;
        public SecurityUnit(int processTime) : base(processTime)
        {
            bufferNotSecure = new List<Baggage>();
        }

        public override void ProcessBaggage(Object obj, ElapsedEventArgs e)
        {
            if (baggage != null)
            {
                Status = BaggageStatus.Busy;
                timer.Stop();
                if (NextNode.Status == BaggageStatus.Free)
                {
                    if (baggage.Secure == 5 && baggage.Secure == 7)
                    {
                        bufferNotSecure.Add(baggage);
                        Status = BaggageStatus.Free;
                    }
                    else
                    {
                        NextNode.PassBaggage(baggage);
                        Status = BaggageStatus.Free;
                    }
                }
                else
                {
                    timer.Start();
                }
            }
            else
            {
                timer.Start();
            }
        }

        public override void PassBaggage(Baggage Lastbaggage)
        {
            baggage = Lastbaggage;
        }
    }
}
