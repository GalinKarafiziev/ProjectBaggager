using Procp_Form.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Procp_Form.Airport;

namespace Procp_Form.Statistics
{
    public class StatisticsManager
    {
        private List<CheckIn> checkIns;
        public List<int> baggageInCheckIn;
        public Stopwatch stopwatch;
        List<TimeSpan> transferTimes;
        public List<int> failedToPassSecurity;
        public double allBaggage = 0;
        private List<DropOff> dropOffs;

        public StatisticsManager(List<CheckIn> checkIns, List<DropOff> dropOffs)
        {
            this.checkIns = checkIns;
            this.dropOffs = dropOffs;
            baggageInCheckIn = new List<int>();
            failedToPassSecurity = new List<int>();
            transferTimes = new List<TimeSpan>();
            stopwatch = new Stopwatch();            
        }


        public List<int> GetCheckInBaggageCount()
        {
            baggageInCheckIn.Clear();
            return baggageInCheckIn;
        }

        public List<TimeSpan> CalculateAverageTimeNeededToTransferBaggage()
        {
            TimeSpan transferTime = stopwatch.Elapsed;
            transferTimes.Add(transferTime);
            return transferTimes;
        }

        public List<int> GetFailedToPassBaggageThroughSecurity(List<Security> securities)
        {
            failedToPassSecurity.Clear();

            foreach (var security in securities)
            {
                failedToPassSecurity.Add(security.baggageAgainstSecurityPolicy.Count());
            }

            return failedToPassSecurity;
        }

        public void getAllBaggage(List<Flight> flights)
        {
            allBaggage = 0;
            foreach (var f in flights)
            {
                allBaggage += f.AmountOfBaggage;
            }
        }

        public double CalculateFailedBaggage()
        {
            double sum = 0;
            foreach (var item in failedToPassSecurity)
            {
                sum += item;
            }

            return sum;
        }

        public double CalculateSuccessedBaggage()
        {
            return allBaggage - CalculateFailedBaggage();
        }

        public List<DateTime> GetLastBaggageTimes()
        {
            var mostRecentTimes = this.dropOffs.Select(x => x.baggageEnteredDropOff.OrderBy(c => c).First()).ToList();
            return mostRecentTimes;
        }
    }
}
