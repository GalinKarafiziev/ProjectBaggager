using Procp_Form.CoreAbstraction;
using Procp_Form.Statistics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Xsl;

namespace Procp_Form.Core
{
    public class DropOff : Node
    {
        public List<Baggage> baggages;
        static int destinationGate = 0;
        public Stopwatch stopwatch;

        public int DestinationGate { get; set; }

        public DropOff()
        {
            destinationGate++;
            baggages = new List<Baggage>();
            DestinationGate = destinationGate;
            stopwatch = new Stopwatch();
        }

        public override void PassBaggage(Baggage Lastbaggage)
        {
            Status = BaggageStatus.Busy;
            baggages.Add(Lastbaggage);
            stopwatch.Stop();
            Status = BaggageStatus.Free;
        }

        public List<Baggage> GetBaggages()
        {
            return this.baggages;
        }
    }
}
