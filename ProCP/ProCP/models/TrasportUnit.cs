using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace ProCP.models
{
    public abstract class TrasportUnit : Node
    {
        public Baggage lastBag;
        public List<Baggage> conveyorBelt;
        public Timer timer;
        public TrasportUnit()
        {
            conveyorBelt = new List<Baggage>();
            timer = new Timer();
            timer.Interval = 1000;
            timer.Elapsed += Move;
            timer.Start();
        }
        public bool CanMove()
        {   
            if (NextNode.Status == BaggageStatus.Free)
            {
                return true;
            }
            return false;
        }
        public void Move(object obj, ElapsedEventArgs e)
        {
            if (CanMove())
            {
                timer.Stop();
                if (conveyorBelt.Count != 0)
                {
                    Status = BaggageStatus.Busy;
                    foreach (Baggage bag in conveyorBelt)
                    {
                        NextNode.PassBaggage(lastBag);
                        conveyorBelt.Remove(lastBag);
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
    }
}
