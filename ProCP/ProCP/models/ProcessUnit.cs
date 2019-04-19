using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace ProCP.models
{
    public abstract class ProcessUnit: Node
    {
        public abstract void ProcessBaggage();
    }
}
