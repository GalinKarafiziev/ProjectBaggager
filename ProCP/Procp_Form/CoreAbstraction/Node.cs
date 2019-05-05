using Procp_Form.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procp_Form.CoreAbstraction
{
    public enum BaggageStatus
    {
        Free, Busy
    }
    public abstract class Node
    {
        private BaggageStatus status;
        public BaggageStatus Status
        {
            get
            {
                return this.status;
            }
            set
            {
                status = value;
                if (value == BaggageStatus.Free && OnNodeStatusChangedToFree != null)
                {
                    OnNodeStatusChangedToFree?.Invoke();
                }
            }
        }
        public int ColumnIndex { get; set; }
        public int RowIndex { get; set; }
        public Node NextNode { get; set; }
        public Node()
        {
            Status = BaggageStatus.Free;
        }
        public abstract void PassBaggage(Baggage Lastbaggage);
        public Action OnNodeStatusChangedToFree;
    }
}
