using Procp_Form.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;

namespace Procp_Form.CoreAbstraction
{
    public abstract class TransportUnit : Node
    {
        public int Capacity { get; set; }
        public Baggage[] conveyorBelt;
        public Baggage lastBaggage;
        public Timer timer;


        public TransportUnit()
        {

            timer = new Timer();
            timer.Elapsed += (sender, args) => Move();
        }
        public void Start()
        {
            timer.Start();
        }
        public void Stop()
        {
            timer.Stop();
        }

        public bool CanMove()
        {
            lastBaggage = conveyorBelt[conveyorBelt.Length - 1];
            if (lastBaggage != null)
            {
                return true;
            }
        
            if (NextNode.Status == BaggageStatus.Free)
            {
                return true;
            }
            return false;
        }
        public abstract void Move();
    }
}
