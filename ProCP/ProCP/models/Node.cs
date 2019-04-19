using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProCP.models
{
    public enum BaggageStatus
    {
        Free, Busy
    }
    public abstract class Node
    {
        private BaggageStatus status;
        public BaggageStatus Status { get; set; }
        public Node NextNode { get; set; }
        public Node()
        {
            Status = BaggageStatus.Free;
        }
        public abstract void PassBaggage(Baggage Lastbaggage);
        public Action OnNodeStatusChangedToFree;
    }
}
