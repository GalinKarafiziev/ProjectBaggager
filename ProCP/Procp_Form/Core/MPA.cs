using Procp_Form.CoreAbstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Procp_Form.Core
{
    public class MPA : ProcessUnit
    {
        public List<DropOff> nextNodes;
        public new int counter = 0;

        public MPA()
        {
            nextNodes = new List<DropOff>();
        }
        public void AddNextNode(DropOff node)
        {
            var nextNode = node;
            nextNodes.Add(nextNode);
        }
        public override void ProcessBaggage()
        {
            Status = BaggageStatus.Busy;
            if (baggage != null)
            {
                foreach (DropOff drop in nextNodes)
                {
                    if (drop.GateId == baggage.DestinationGateId)
                    {
                        this.NextNode = drop;
                        NextNode.PassBaggage(baggage);
                        counter--;
                        Thread.Sleep(800);
                        baggage = null;
                        Status = BaggageStatus.Free;
                        break;
                    }
                }
            }
        }
        public override void PassBaggage(Baggage Lastbaggage)
        {
            baggage = Lastbaggage;
            counter++;
            ProcessBaggage();
        }
    }
}
