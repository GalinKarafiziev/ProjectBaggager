using System;
using System.Collections.Generic;
using Procp_Form.Core;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Procp_Form.Statistics
{
    public class StatisticsManager
    {
        private List<CheckIn> checkIns;
        public List<int> baggageInCheckIn;

        public StatisticsManager(List<CheckIn> checkIns)
        {
            this.checkIns = checkIns;
            baggageInCheckIn = new List<int>();
        }

        public List<int> GetCheckInBaggageCount()
        {
            checkIns.ForEach(x => baggageInCheckIn.Add(x.bagageInCheckIn));
            return baggageInCheckIn;
        }

        public void CalculateAverageTimeNeededToTransferBaggage()
        {

        }

        public void SetBaggageTransferTime()
        {
            
        }
    }
}
