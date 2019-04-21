using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProCP.models
{
    public class Dropoff: Node
    {
        public int GateId { get; set; }
        public List<Baggage> baggages;
        public Dropoff(int id)
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
