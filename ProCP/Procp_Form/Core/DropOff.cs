using Procp_Form.Airport;
using Procp_Form.CoreAbstraction;
using Procp_Form.Statistics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Timers;
using System.Xml.Xsl;

namespace Procp_Form.Core
{
    public class DropOff : Node
    {
        public List<Baggage> baggages;
        List<Flight> flights;
        DateTime endOfTransportation;
        static int destinationGate = 0;
        public List<Baggage> unloadBaggages;
        private int employeeSpeed;
        private Timer timer;
        public List<DateTime> baggageEnteredDropOff;

        public DropOff()
        {
            destinationGate++;
            flights = new List<Flight>();
            baggages = new List<Baggage>();
            timer = new Timer();
            unloadBaggages = new List<Baggage>();
            baggageEnteredDropOff = new List<DateTime>();
            DestinationGate = destinationGate;
            baggages.Capacity = 10;
            timer.Start();
            timer.Elapsed += (sender, args) => UnloadBaggage();
        }

        public int DestinationGate { get; set; }
        
        public int EmployeeSpeed
        {
            get
            {
                return employeeSpeed;
            }
            set
            {
                switch (employeeSpeed)
                {
                    case 1:
                        timer.Interval = 500;
                        break;
                    case 2:
                        timer.Interval = 800;
                        break;
                    case 3:
                        timer.Interval = 1000;
                        break;
                    case 4:
                        timer.Interval = 1200;
                        break;
                    default:
                        timer.Interval = 700;
                        break;
                }
            }
        }

        public void SetNumberEmployees(int nrEmp)
        {
            EmployeeSpeed = nrEmp;
        }

        public void UnloadBaggage()
        {
            if (baggages.Count != 0)
            {
                unloadBaggages.Add(baggages[0]);
                baggages.Remove(baggages[0]);
                Status = BaggageStatus.Free;
                
            }

        }
        public override void PassBaggage(Baggage Lastbaggage)
        {
            DateTime time = DateTime.Now;

            if (baggages.Count >= baggages.Capacity)
            {
                Status = BaggageStatus.Busy;
            }
            else
            {
                Status = BaggageStatus.Busy;
                baggages.Add(Lastbaggage);
                baggageEnteredDropOff.Add(time);
                System.Diagnostics.Debug.WriteLine(baggages.Count());

                Status = BaggageStatus.Free;
            }
        }

        public void SetupFlights(Flight flight)
        {
            flights.Add(flight);
        }

        public List<Baggage> GetBaggages()
        {
            return this.baggages;
        }

        public override string ToString()
        {
            return $"Destination Gate [#{DestinationGate}]";
        }
    }
}
