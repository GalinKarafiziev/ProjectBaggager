using Procp_Form.CoreAbstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Xsl;

namespace Procp_Form.Core
{
    public class DropOff : Node
    {
        public string FlightNumber { get; set; }
        public List<Baggage> baggages;
        public DropOff()
        {
            baggages = new List<Baggage>();
        }
        public override void PassBaggage(Baggage Lastbaggage)
        {
            baggages.Add(Lastbaggage);
        }

        public List<Baggage> GetBaggages()
        {
            return this.baggages;
        }
    }
}
