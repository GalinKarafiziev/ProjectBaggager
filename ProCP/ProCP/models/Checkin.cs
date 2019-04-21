using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace ProCP.models
{
    public class Checkin : ProcessUnit
    {
        public Checkin(int processTime) : base(processTime)
        {

        }

        public override void ProcessBaggage(Object obj, ElapsedEventArgs e)
        {
            if (baggage != null)
            {
                Status = BaggageStatus.Busy;
                timer.Stop();
                if (NextNode.Status == BaggageStatus.Free)
                {
                    NextNode.PassBaggage(baggage);
                    Status = BaggageStatus.Free;
                }
                else
                {
                    timer.Start();
                }
            }
            else
            {
                Status = BaggageStatus.Free;
                timer.Start();
            }
        }

        public override void PassBaggage(Baggage Lastbaggage)
        {
            baggage = Lastbaggage;
        }
    }
}
