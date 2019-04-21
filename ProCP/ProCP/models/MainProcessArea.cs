using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;

namespace ProCP.models
{
    public class MainProcessArea: Node
    {
        public Baggage baggage { get; set; }
        public List<Dropoff> nextNodes;
        public Timer timer;

        public MainProcessArea()
        {
            nextNodes = new List<Dropoff>();
            timer = new Timer();
            timer.Interval = 500;
            timer.Elapsed += RedirectBaggage;
            timer.Start();
        }
        public void AddNextNode(Dropoff node)
        {
            var nextNode = node;
            nextNodes.Add(nextNode);
        }
        public void RedirectBaggage(Object obj, ElapsedEventArgs e)
        {
            Status = BaggageStatus.Busy;
            timer.Stop();
            foreach (Dropoff drop in nextNodes)
            {
                if (drop.GateId == baggage.DestinationGateId)
                {
                    this.NextNode = drop;
                    NextNode.PassBaggage(baggage);
                }
            }
            timer.Start();
        }
        public override void PassBaggage(Baggage Lastbaggage)
        {
            baggage = Lastbaggage;
        }
    }
}
