using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TryingConveyerStuff
{
    class DropOffPoint:Node
    {
        List<Baggage> baggages; 

        public DropOffPoint(int x, int y) : base(x, y)
        {
            baggages = new List<Baggage>();
        }

        public void AddBaggage(Baggage b)
        {
            baggages.Add(b);
        }

        public List<string> ShowBaggages()
        {
            List<string> baggageIDs = new List<string>();
            foreach(Baggage i in baggages)
            {
                baggageIDs.Add(i.baggageID);
            }
            return baggageIDs;
        }
    }
}
