﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public class DropOff : Node
    {
        public List<Baggage> baggages;

        public DropOff()
        {
            baggages = new List<Baggage>();
        }      
        public override void PassBaggage(Baggage Lastbaggage)
        {
            baggages.Add(Lastbaggage);
        }
    }
}
