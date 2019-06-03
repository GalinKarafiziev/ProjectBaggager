using Procp_Form.Airport;
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
    [Serializable]
    public class DropOff : Node
    {
        public List<Baggage> baggages;
        List<Flight> flights;
        DateTime endOfTransportation;
        static int destinationGate = 0;

        public int DestinationGate { get; set; }

        public DropOff()
        {
            destinationGate++;
            flights = new List<Flight>();
            baggages = new List<Baggage>();
            DestinationGate = destinationGate;
        }

        public override void PassBaggage(Baggage Lastbaggage)
        {
            Status = BaggageStatus.Busy;
            baggages.Add(Lastbaggage);
            Status = BaggageStatus.Free;
        }

        public void SetupFlights(Flight flight)
        {
            flights.Add(flight);
        }

        public Flight GetDesiredFlight()
        {
            var flight = flights.FirstOrDefault(x => x.DestinationGate == this.DestinationGate);

            return flight;
        }

        public List<Baggage> GetBaggages()
        {
            return this.baggages;
        }

        public override string ToString()
        {
            return $"Destination Gate [#{DestinationGate}]";
        }
    }
}
