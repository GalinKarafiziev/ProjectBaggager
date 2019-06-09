using Procp_Form.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;

namespace Procp_Form.CoreAbstraction
{
    [Serializable]
    public abstract class TransportUnit : Node
    {
        public Baggage[] conveyorBelt;
        public Baggage lastBaggage;
        [NonSerialized]
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
            if (NextNode.Status == BaggageStatus.Free)
            {
                return true;
            }

            if (lastBaggage == null)
            {
                return true;
            }
            return false;
        }
        public abstract void Move();
    }
}
