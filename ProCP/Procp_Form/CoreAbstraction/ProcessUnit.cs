using Procp_Form.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procp_Form.CoreAbstraction
{
    [Serializable()]
    public abstract class ProcessUnit : Node
    {
        public Baggage baggage { get; set; }
        public abstract void ProcessBaggage();
    }
}
