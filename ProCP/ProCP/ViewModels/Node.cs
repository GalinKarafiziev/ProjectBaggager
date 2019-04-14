using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProCP.viewModels
{
    public enum BaggageStatus
    {
        Free, Busy
    }
    public abstract class Node
    {
        private BaggageStatus status;
        public BaggageStatus Status { get; set; }
        public Node nextNode { get; set; }
        public Node()
        {
            Status = BaggageStatus.Free;
        }
        public abstract void PassBaggage(Baggage Lastbaggage);
        public Action OnNodeStatusChangedToFree;
    }
}
