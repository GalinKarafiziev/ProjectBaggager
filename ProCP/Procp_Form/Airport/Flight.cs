using Procp_Form.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procp_Form.Airport
{
    public class Flight
    {
        public string FlightNumber { get; set; }

        public int DestinationGate { get; set; }

        public int BaggageDispatched { get; set; }

        public int AmountOfBaggage { get; set; }

        public DateTime DepartureTime { get; set; }

        public Flight(DateTime time, string number, int baggage, int destGate)
        {
            this.FlightNumber = number;
            this.DepartureTime = time;
            this.AmountOfBaggage = baggage;
            this.BaggageDispatched = 0;
            this.DestinationGate = destGate;
        }

        public override string ToString()
        {
            return $"[#{FlightNumber}][⌚{DepartureTime.Hour}:{DepartureTime.Minute}][💼{AmountOfBaggage}][🛬{DestinationGate}]";
        }
    }
}
