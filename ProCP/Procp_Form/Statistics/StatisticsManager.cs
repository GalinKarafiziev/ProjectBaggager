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
        private List<Flight> flights;

        public StatisticsManager(List<CheckIn> checkIns, List<DropOff> dropOffs, List<Flight> flights)
        {
            this.checkIns = checkIns;
            this.dropOffs = dropOffs;
            this.flights = flights;
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

        public List<DateTime> GetBaggageTimes()
        {
            var mostRecentTimes = this.dropOffs.Select(x => x.baggageEnteredDropOff.OrderByDescending(c => c).First()).ToList();
            return mostRecentTimes;
        }

        public List<TimeSpan> CalculateBaggageTransportationTime()
        {
            List<DateTime> checkInTimes = new List<DateTime>();
            List<DateTime> dropOffTimes = new List<DateTime>();

            checkIns.ForEach(c => checkInTimes.Add(c.startOfBaggageTransfer));
            dropOffTimes = this.GetBaggageTimes();

            var transferTimes = dropOffTimes.Select(x => x.Subtract(checkInTimes.FirstOrDefault())).ToList();

            return transferTimes;
        }

        public List<DateTime> GetFlightDepTimes()
        {            
            var flightExpectedTimes = this.flights.Select(f => f.DepartureTime).ToList();
            return flightExpectedTimes;
        }

        public void CompareTransferToDepartureTime()
        {
            this.dropOffs.ForEach(x =>
            {
                this.flights.ForEach(f =>
                {
                    if (x.DestinationGate == f.DestinationGate)
                    {
                        f.DepartureTime.CompareTo(this.GetBaggageTimes().FirstOrDefault());
                    }
                });
            });
        }
    }
}
