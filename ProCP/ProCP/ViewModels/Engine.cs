using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProCP.ViewModels
{
    public class Engine
    {
        public ConveyerLine ConveyerFromCheckin { get; set; }
        public ConveyerLine ConveyerToGateA { get; set; }
        public ConveyerLine ConveyerToGeteB { get; set; }

        public Engine()
        {
            this.ConveyerFromCheckin = new ConveyerLine(10, 600, 200);
            this.ConveyerToGateA = new ConveyerLine(10, 900, 50);
            this.ConveyerToGeteB = new ConveyerLine(10, 900, 400);
        }
    }
}
