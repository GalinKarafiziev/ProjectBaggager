using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProCP.ViewModels
{
    public class CheckInDesk
    {
        public int Employees { get; set; }
        public bool IsActive { get; set; }

        public CheckInDesk(int employees)
        {
            this.Employees = employees;
            this.IsActive = true;
        }
        public void ProcessBaggage(Baggage baggage)
        {
            //TODO
        }
    }
}
