using Procp_Form.CoreAbstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;

namespace Procp_Form.Core
{
    [Serializable]
    public class MPA : ProcessUnit
    {
        public List<Conveyor> nextNodes;
        public List<Baggage> baggagesToWait;

        public MPA()
        {
            nextNodes = new List<Conveyor>();
            baggagesToWait = new List<Baggage>();
        }

        public void AddNextNode(Conveyor node)
        {
            var nextNode = node;
            if (nextNodes.Contains(nextNode))
            {
                return;
            }
            else
            {
                nextNodes.Add(nextNode);
            }
        }

        public override void ProcessBaggage()
        {
            foreach (var conv in nextNodes.ToList())
            {
                if (conv.DestinationGate == baggage.DestinationGate)
                {
                    NextNode = conv;
                    if (NextNode.Status == BaggageStatus.Free)
                    {
                        NextNode.PassBaggage(baggage);
                        baggage = null;
                        Status = BaggageStatus.Free;
                        NextNode.OnNodeStatusChangedToFree -= ProcessBaggage;
                        break;
                    }
                    else
                    {
                        NextNode.OnNodeStatusChangedToFree += ProcessBaggage;
                        break;
                    }
                }
            }
        }

        public void PassWaitingBaggage(Conveyor chosen)
        {
            var chosenConveyor = chosen;
            foreach (var bag in baggagesToWait)
            {
                if (bag.DestinationGate == chosenConveyor.DestinationGate)
                {
                    chosenConveyor.PassBaggage(bag);
                    Status = BaggageStatus.Free;
                    baggagesToWait.Remove(bag);
                    break;
                }
            }
        }

        public override void PassBaggage(Baggage Lastbaggage)
        {
            baggage = Lastbaggage;
            Status = BaggageStatus.Busy;
            ProcessBaggage();
        }
    }
}
