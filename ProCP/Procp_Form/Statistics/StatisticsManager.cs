using Procp_Form.Core;
using System;
using System.Collections.Generic;
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
        public Stopwatch stopwatch;
        List<TimeSpan> transferTimes;

        public StatisticsManager(List<CheckIn> checkIns)
        {
            this.checkIns = checkIns;
            baggageInCheckIn = new List<int>();
            stopwatch = new Stopwatch();
            transferTimes = new List<TimeSpan>();
        }

        public void GetStopwatch()
        {
            checkIns.ForEach(x => x.stopwatch = stopwatch);
        }

        public List<int> GetCheckInBaggageCount()
        {
            checkIns.ForEach(x => baggageInCheckIn.Add(x.bagageInCheckIn));
            return baggageInCheckIn;
        }

        public List<TimeSpan> CalculateAverageTimeNeededToTransferBaggage()
        {
            TimeSpan transferTime = stopwatch.Elapsed;
            transferTimes.Add(transferTime);
            return transferTimes;
        }

        public void SetBaggageTransferTime()
        {
            //foreach (var item in checkIns)
            //{
            //    item.baggage
            //}
        }
    }
}
