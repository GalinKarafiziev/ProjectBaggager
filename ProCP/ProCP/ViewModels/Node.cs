using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProCP.viewModels
{
    public enum BaggageStatus
    {
        Free
    }
    public abstract class Node
    {
        private BaggageStatus status;

        public BaggageStatus Status
        {
            get
            {
                return status;
            }
            set
            {
                status = value;
                if (value == BaggageStatus.Free)
                {

                }
            }
        }
        public Node nextNode { get; set; }
        public Action OnStatusChangedToFree;
        public Node() { }
        public abstract void PassBaggage(Baggage Lastbaggage);
    }
}
