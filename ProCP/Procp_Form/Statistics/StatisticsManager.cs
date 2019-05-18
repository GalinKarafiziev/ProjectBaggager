using Procp_Form.Core;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procp_Form.Statistics
{
    public class StatisticsManager
    {
        public List<int> baggageInCheckIn;
        public Engine engine;
        Stopwatch stopwatch;
        Baggage baggage;

        public StatisticsManager()
        {
            baggageInCheckIn = new List<int>();
            engine = new Engine();
            stopwatch = new Stopwatch();
        }

        public List<int> GetCheckInCounter()
        {
            engine.checkIns.ForEach(x => baggageInCheckIn.Add(x.bagageInCheckIn));
            return baggageInCheckIn;
        }

        public void StartStopwatch()
        {
            
        }

        public void StopStopwatch()
        {

        }
    }
}
