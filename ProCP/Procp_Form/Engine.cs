using Procp_Form.Airport;
using Procp_Form.Core;
using Procp_Form.CoreAbstraction;
using Procp_Form.Statistics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procp_Form
{
    public class Engine
    {
        public StatisticsManager statistics;
        private MPA mainProcessArea;
        public CheckInDispatcher dispatcher;
        public List<CheckIn> checkIns;
        public List<DropOff> dropOffs;
        public List<Conveyor> conveyors;
        public List<Flight> flights;
        public List<Security> securities;
        private Flight flight;
        public Stopwatch stopwatch;

        public Engine()
        {
            securities = new List<Security>();
            conveyors = new List<Conveyor>();
            checkIns = new List<CheckIn>();
            dropOffs = new List<DropOff>();
            flights = new List<Flight>();
            statistics = new StatisticsManager(checkIns, dropOffs, flights);
            stopwatch = statistics.stopwatch;
        }

        public void AddDispatcher() => dispatcher = new CheckInDispatcher();

        public void AddCheckIn(CheckIn checkin) => checkIns.Add(checkin);

        public void AddDropOff(DropOff dropOff) => dropOffs.Add(dropOff);

        public void AddConveyorPart(Conveyor conveyor) => conveyors.Add(conveyor);

        public void AddSecurity(Security security) => this.securities.Add(security);

        public void AddMPA(MPA mpa) => this.mainProcessArea = mpa;

        public bool AddFlight(DateTime time, string number, int baggage, int destGate)
        {
            flight = new Flight(time, number, baggage, destGate);
            if (flights.Count != 0)
            {
                foreach (var f in flights)
                {
                    if ((this.flight.FlightNumber == f.FlightNumber && this.flight.DestinationGate == f.DestinationGate) || (this.flight.FlightNumber != f.FlightNumber && this.flight.DestinationGate == f.DestinationGate))
                    {
                        return false;
                    }
                }
            }
            flights.Add(flight);
            getAllBaggage();
            return true;
        }
        public bool RemoveFlight(string number)
        {
            var item = flights.Find(f => f.FlightNumber == number);
            if (item == null)
            {
                return false;
            }
            else
            {
                flights.Remove(item);
                return true;
            }
        }
        public bool EditFlight(string number, string newNumber, int baggage, DateTime time, int destGate)
        {
            Flight selectedFlight = flights.Find(f => f.FlightNumber == number);
            if (selectedFlight == null)
            {
                return false;
            }
            else
            {
                foreach (var f in flights)
                {
                    if ((selectedFlight.FlightNumber == f.FlightNumber && selectedFlight.DestinationGate == f.DestinationGate) || (selectedFlight.FlightNumber != f.FlightNumber && selectedFlight.DestinationGate == f.DestinationGate))
                    {
                        return false;
                    }
                }
                selectedFlight.FlightNumber = newNumber;
                selectedFlight.DepartureTime = time;
                selectedFlight.AmountOfBaggage = baggage;
                selectedFlight.DestinationGate = destGate;
                return true;
            }
        }
        public bool CheckFlights()
        {
            return flights.Any();
        }
        public void LinkTwoNodes(Node firstNode, Node secondNode)
        {
            firstNode.NextNode = secondNode;
        }

        public void Run()
        {
            foreach (var conveyor in conveyors)
            {
                conveyor.Start();
            }
            dispatcher.SetupCheckins(checkIns);
            dispatcher.SetupTimers(flights);
            dispatcher.Start();
        }

        public void Resume()
        {
            foreach (var conveyor in conveyors)
            {
                conveyor.Start();
            }
            dispatcher.Start();
        }

        public void Pause()
        {
            foreach (var conveyor in conveyors)
            {
                conveyor.Stop();
            }
            dispatcher.Stop();
        }

        public void Stop()
        {

            flights.Clear();
            foreach (var conveyor in conveyors)
            {
                conveyor.Stop();
                for (int i = 0; i < conveyor.conveyorBelt.Length - 1; i++)
                {
                    if (conveyor.conveyorBelt[i] != null)
                    {
                        conveyor.conveyorBelt[i] = null;
                    }
                }
                conveyor.Status = BaggageStatus.Free;
            }

            foreach (var dropOff in dropOffs)
            {
                dropOff.baggages.Clear();
                dropOff.Status = BaggageStatus.Free;
            }

            foreach (var checkin in checkIns)
            {
                checkin.baggage = null;
                checkin.Status = BaggageStatus.Free;
            }
            if (mainProcessArea != null)
            {
                mainProcessArea.baggage = null;
                mainProcessArea.Status = BaggageStatus.Free;
            }

            if (dispatcher == null)
            {
                return;
            }
            dispatcher.Stop();
            dispatcher = null;
        }

        public void Remove(Node rem)
        {
            if (rem is Conveyor)
            {
                conveyors.Remove((Conveyor)rem);
            }
            else if (rem is CheckIn)
            {
                checkIns.Remove((CheckIn)rem);
            }
            else if (rem is DropOff)
            {
                dropOffs.Remove((DropOff)rem);
            }
            else if (rem is Security)
            {
                securities.Remove((Security)rem);
            }
            rem = null;
        }

        public List<int> GetCheckInStats() => statistics.GetCheckInBaggageCount();

        public List<int> GetSecurityStats()
        {
            return statistics.GetFailedToPassBaggageThroughSecurity(securities);
        }

        public void getAllBaggage()
        {
            statistics.getAllBaggage(flights);
        }

        public double GetCalculatePercentageFailedBaggage()
        {
            return statistics.CalculateFailedBaggage();
        }

        public double GetCalculateSuccessedBaggage()
        {
            return statistics.CalculateSuccessedBaggage();
        }

        //public DateTime GetLastBaggageTime() => statistics.GetLastBaggageTime();

        public List<TimeSpan> GetTransferTime() => statistics.CalculateBaggageTransportationTime();
    }
}
