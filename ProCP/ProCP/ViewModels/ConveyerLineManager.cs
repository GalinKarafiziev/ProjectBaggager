using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProCP.ViewModels
{
    public class ConveyerLineManager
    {
        public ConveyerLine Conveyer { get; set; }

        public ConveyerLineManager()
        {
            this.Conveyer = new ConveyerLine(10, 100, 100);
        }
    }
}
