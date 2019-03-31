using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace ProCP.viewModels
{
    public abstract class ProcessUnit: Node
    {
        public abstract Baggage ProcessBaggage(Baggage baggage);
    }
}
