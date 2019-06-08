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
    [Serializable]
    public class DropOff : Node
    {
        public List<Baggage> baggages;
        List<Flight> flights;
        static int destinationGate = 0;
        public List<Baggage> unloadBaggages;
        private int employeeSpeed;
        [NonSerialized]
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
            SetNumberEmployees(1);
            timer.Elapsed += (sender, args) => UnloadBaggage();
            timer.Start();
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
                this.employeeSpeed = value;
                switch (employeeSpeed)
                {
                    case 1:
                        timer.Interval = 1200;
                        break;
                    case 2:
                        timer.Interval = 1000;
                        break;
                    case 3:
                        timer.Interval = 800;
                        break;
                    case 4:
                        timer.Interval = 500;
                        break;
                    default:
                        timer.Interval = 1200;
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
            timer.Stop();
            DateTime time = DateTime.Now;
            if (baggages.Count != 0)
            {
                unloadBaggages.Add(baggages[0]);
                System.Diagnostics.Debug.WriteLine(unloadBaggages.Count.ToString());
                baggageEnteredDropOff.Add(time);
                baggages.Remove(baggages[0]);
                Status = BaggageStatus.Free;
            }
            timer.Start();

        }
        public override void PassBaggage(Baggage Lastbaggage)
        {
            //if (!timer.Enabled)
            //{
            //    timer.Start();
            //}

            if (baggages.Count >= baggages.Capacity)
            {
                Status = BaggageStatus.Busy;
                timer.Start();
            }
            else
            {
                Status = BaggageStatus.Busy;
                baggages.Add(Lastbaggage);
                timer.Start();
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
