using Procp_Form.CoreAbstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procp_Form.Core
{
    public class Conveyor : TransportUnit
    {
        public Conveyor() : base()
        {

        }
        public override void PassBaggage(Baggage lastbaggage)
        {
            conveyorBelt = lastbaggage;
            Move();
        }
    }
}
