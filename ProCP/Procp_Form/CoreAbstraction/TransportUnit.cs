using Procp_Form.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procp_Form.CoreAbstraction
{
    public abstract class TransportUnit : Node
    {
        public Baggage conveyorBelt;
        public int counter;
        public TransportUnit()
        {

        }
        public bool CanMove()
        {
            if (NextNode.Status == BaggageStatus.Free)
            {
                return true;
            }
            return false;
        }
        public void Move()
        {
            counter++;
            Status = BaggageStatus.Busy;
            if (CanMove())
            {
                if (conveyorBelt != null)
                {
                    NextNode.PassBaggage(conveyorBelt);
                    conveyorBelt = null;
                    counter--;
                    NextNode.OnNodeStatusChangedToFree -= Move;
                    Status = BaggageStatus.Free;
                }
            }
            else
            {
                NextNode.OnNodeStatusChangedToFree += Move;
            }
        }
    }
}
