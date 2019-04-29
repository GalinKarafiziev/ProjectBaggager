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
        private int randomGate;
        private int secure;
        public int Secure { get; set; }
        public int DestinationGateId { get; set; }
        public string Id { get; set; }

        public Baggage()
        {
            Id = Guid.NewGuid().ToString().Substring(0, 5);
            random = new Random();
            randomGate = random.Next(1, 3);
            secure = random.Next(1, 10);
            DestinationGateId = randomGate;
            Secure = secure;
        }
    }
}
