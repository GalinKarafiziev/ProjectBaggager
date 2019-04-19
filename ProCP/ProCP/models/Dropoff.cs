using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProCP.models
{
    public class Dropoff: Node
    {
        public List<Baggage> baggages;
        public Dropoff()
        {
            baggages = new List<Baggage>();
        }
        public override void PassBaggage(Baggage Lastbaggage)
        {
            baggages.Add(Lastbaggage);
        }
    }
}
