using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using System.Threading.Tasks;

namespace Test
{
    public abstract class TransportUnit : Node
    {
        public List<Baggage> conveyorBelt = new List<Baggage>();
        public Baggage firstBag;
        private int lastIndex;
        private Timer timer;
        public Baggage Baggage { get; set; }

        public TransportUnit()
        {
            lastIndex = conveyorBelt.Count() - 1;
            timer = new Timer();
            timer.Interval = 1500;
        }
        public bool CanMove()
        {
            if (nextNode.Status == BaggageStatus.Free)
            {
                return true;
            }
            return false;
        }
        public void Move()
        {
            Console.WriteLine("vlqzoh v transport");
            firstBag = conveyorBelt.First();
            timer.Stop();
            if (CanMove())
            {
                if (firstBag != null)
                {
                    nextNode.PassBaggage(firstBag); 
                }
                nextNode.OnStatusChangedToFree -= Move;
                Status = BaggageStatus.Free;
                timer.Start();
            }
            else
            {
                nextNode.OnStatusChangedToFree += Move;
            }
        }
    }
}
