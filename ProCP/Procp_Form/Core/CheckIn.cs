﻿using Procp_Form.CoreAbstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Procp_Form.Core
{
    public class CheckIn : ProcessUnit
    {
        public List<Baggage> queue;

        public CheckIn()
        {
            queue = new List<Baggage>();
        }

        public override void ProcessBaggage()
        {
            if (NextNode.Status == BaggageStatus.Free)
            {
                Thread.Sleep(1000);
                NextNode.PassBaggage(baggage);
                Status = BaggageStatus.Free;
                counter--;
                baggage = null;
                NextNode.OnNodeStatusChangedToFree -= ProcessBaggage;
            }
            else
            {
                NextNode.OnNodeStatusChangedToFree += ProcessBaggage;
            }
        }

        public override void PassBaggage(Baggage Lastbaggage)
        {
            Status = BaggageStatus.Busy;
            baggage = Lastbaggage;
            ProcessBaggage();
        }
    }
}
