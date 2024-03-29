﻿using Procp_Form.Airport;
using Procp_Form.Core;
using Procp_Form.CoreAbstraction;
using Procp_Form.Statistics;
using Procp_Form.Visuals;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Procp_Form
{
    public class Engine
    {
        Settings settings = new Settings();
        public List<GridTile> tiles;
        public StatisticsManager statistics;
        public MPA mainProcessArea;
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
            tiles = new List<GridTile>();
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

        public void AddDropOff(DropOff dropOff)
        {
            dropOffs.Add(dropOff);
            settings.DropOffsCapacities.Add(dropOff.baggages.Capacity);
            settings.DropOffsEmployees.Add(dropOff.EmployeeSpeed);
            settings.DestGates.Add(dropOff.DestinationGate);
        }

        public void AddConveyorPart(Conveyor conveyor)
        {
            conveyors.Add(conveyor);
            settings.ConveyorsLength.Add(conveyor.conveyorBelt.Length);
        }

        public void ChangeConveyorSpeed(int speed)
        {
            foreach (var conv in conveyors)
            {
                conv.ConveyorSpeed = speed;
                settings.ConveyorsSpeed.Add(speed);
            }
        }

        public void AddSecurity(Security security) => this.securities.Add(security);

        public void AddMPA(MPA mpa) => this.mainProcessArea = mpa;

        public bool AddFlight(DateTime time, string number, int baggage, int destGate)
        {
            flight = new Flight(time, number, baggage, destGate);
            if (flights.Count != 0)
            {
                foreach (var f in flights)
                {
                    if (this.flight.FlightNumber == f.FlightNumber || this.flight.DestinationGate == f.DestinationGate)
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
        public void ResetCheckInDestinationGates()
        {
            foreach (var checkin in checkIns)
            {
                checkin.DestinationGate = 0;
            }
        }
        public void LinkTwoNodes(Node firstNode, Node secondNode)
        {
            firstNode.NextNode = secondNode;
            if (firstNode is Conveyor)
            {
                settings.nextNodes.Add(secondNode);
            }
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
                dropOff.unloadBaggages.Clear();
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

        public List<TimeSpan> GetTransferTime() => statistics.CalculateBaggageTransportationTime();

        public List<DateTime> GetLastBaggageTimes() => statistics.GetBaggageTimes();

        public List<DateTime> GetFlightDepartureTimes() => statistics.GetFlightDepTimes();

        public void GetGridTiles(Grid grid)
        {
            tiles = grid.gridTiles;
        }

        public void WriteToFile()
        {
            List<Object> objectsToSerialize = new List<Object>();

            objectsToSerialize.Add(checkIns);
            objectsToSerialize.Add(securities);
            objectsToSerialize.Add(settings);
            objectsToSerialize.Add(mainProcessArea);
            objectsToSerialize.Add(tiles);
            objectsToSerialize.Add(flights);


            SaveFileDialog sfd = new SaveFileDialog();
            sfd.DefaultExt = "bin";
            try
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    using (Stream stream = File.Open(sfd.FileName, FileMode.Create))
                    {
                        BinaryFormatter bin = new BinaryFormatter();
                        bin.Serialize(stream, objectsToSerialize);
                    }
                }
            }
            catch (IOException)
            {
            }
        }

        public string LoadFromFile()
        {
            OpenFileDialog ofd = new OpenFileDialog();

            try
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    using (Stream stream = File.Open(ofd.FileName, FileMode.Open))
                    {
                        if (!ofd.FileName.Contains(".bin"))
                        {
                            var message = "Only .bin files supported";
                            return message;
                        }
                        BinaryFormatter bin = new BinaryFormatter();
                        object serializedObject = bin.Deserialize(stream);
                        List<Object> objectsToDeserialize = serializedObject as List<Object>;

                        checkIns = (List<CheckIn>)objectsToDeserialize[0];
                        securities = (List<Security>)objectsToDeserialize[1];
                        settings = (Settings)objectsToDeserialize[2];
                        mainProcessArea = (MPA)objectsToDeserialize[3];
                        tiles = (List<GridTile>)objectsToDeserialize[4];
                        flights = (List<Flight>)objectsToDeserialize[5];
                        CreateDropOffsFromFile();
                        CreateConveyorsFromFile();
                    }
                }
            }
            catch (IOException)
            {
                throw;
            }
            return "";
        }

        public void CreateConveyorsFromFile()
        {
            conveyors.Clear();
            var number = 0;
            foreach (var index in Enumerable.Range(0, settings.ConveyorsSpeed.Count))
            {
                var speed = settings.ConveyorsSpeed[index];
                var length = settings.ConveyorsLength[index];
                var next = settings.nextNodes[index];
                var conv = new Conveyor(length, speed);
                conv.NextNode = next;
                if (next is DropOff)
                {
                    var gate = settings.DestGates[number];
                    conv.DestinationGate = gate;
                    number++;
                }
                conveyors.Add(conv);
            }
        }

        public void CreateDropOffsFromFile()
        {
            dropOffs.Clear();

            foreach (var index in Enumerable.Range(0, settings.DestGates.Count))
            {
                var gate = settings.DestGates[index];
                var nrEmp = settings.DropOffsEmployees[index];
                var capacity = settings.DropOffsCapacities[index];
                var drop = new DropOff();
                dropOffs.Add(drop);
            }
        }
    }
}
