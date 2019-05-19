﻿using System;
using System.Collections.Generic;
using Procp_Form.Core;
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
        public List<int> failedToPassSecurity;
        public double allBaggage = 0;

        public StatisticsManager(List<CheckIn> checkIns)
        {
            this.checkIns = checkIns;
            baggageInCheckIn = new List<int>();
            failedToPassSecurity = new List<int>();
        }


        public List<int> GetCheckInBaggageCount()
        {
            baggageInCheckIn.Clear();
            checkIns.ForEach(x => baggageInCheckIn.Add(x.bagageInCheckIn));
            return baggageInCheckIn;
        }

        public void CalculateAverageTimeNeededToTransferBaggage()
        {

        }

        public void SetBaggageTransferTime()
        {
            
        }

        public List<int> GetFailedToPassBaggageThroughSecurity(List<Security> securities)
        {
            failedToPassSecurity.Clear();

            foreach (var security in securities)
            {
                failedToPassSecurity.Add(security.bufferNotSecure.Count());
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
    }
}
