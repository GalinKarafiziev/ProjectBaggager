using Procp_Form.CoreAbstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procp_Form.Core
{
    public class DropOff : Node
    {
        public int GateId { get; set; }
        public List<Baggage> baggages;
        public DropOff(int id)
        {
            baggages = new List<Baggage>();
            GateId = id;
        }
        public override void PassBaggage(Baggage Lastbaggage)
        {
            baggages.Add(Lastbaggage);
        }
    }
}
