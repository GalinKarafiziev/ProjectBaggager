using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procp_Form.Statistics
{
    public class StatisticsManager
    {
        public List<int> baggageInCheckIn;
        public Engine engine;

        public StatisticsManager()
        {
            baggageInCheckIn = new List<int>();
            engine = new Engine();
        }
        public List<int> GetCheckInCounter()
        {
            engine.checkIns.ForEach(x => baggageInCheckIn.Add(x.bagageInCheckIn));
            return baggageInCheckIn;
        }
    }
}
