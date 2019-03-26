using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Test
{
    public abstract class ProcessUnit : Node
    {
        public Timer timer = new Timer();
        public abstract Baggage ProcessBaggage (Baggage baggage);
    }
}
