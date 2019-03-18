using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProCP.ViewModels
{
    public class DropOffPlatform
    {
        public int Capacity { get; set; }
        public int Employees { get; set; }
        public List<Baggage> BaggageOnPlatform { get; set; }
        public DropOffPlatform(int capacity, int emplyees)
        {
            this.Capacity = capacity;
            this.Employees = emplyees;
        }
        public void AddBaggage(Baggage baggage)
        {
            this.BaggageOnPlatform.Add(baggage);
        }
        public void ProcessBaggage(Baggage baggage)
        {
            this.BaggageOnPlatform.Remove(baggage);
        }

    }
}
