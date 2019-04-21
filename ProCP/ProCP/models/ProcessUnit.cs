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
        public Baggage baggage;
        public Timer timer;
        public ProcessUnit(int processTime)
        {
            timer = new Timer();
            timer.Interval = processTime;
            timer.Elapsed += ProcessBaggage;
            timer.Enabled = true;
        }
        public abstract void ProcessBaggage(Object obj, ElapsedEventArgs e);
    }
}
