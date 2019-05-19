using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procp_Form.Core
{
    public class Baggage
    {
        private Random random;

        private int secure;
        public int Secure { get; set; }
        public string FlightNumber { get; set; }
        public int DestinationGate { get; set; }

        public Baggage()
        {
            random = new Random();
            secure = random.Next(1, 10);
            Secure = secure;
        }
    }
}
