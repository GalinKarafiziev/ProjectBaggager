using Procp_Form.CoreAbstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Procp_Form.Core
{
    public class CheckInDispatcher: Node
    {
        List<Queue<Baggage>> checkinQueues;
        List<Timer> timers;
        List<CheckIn> checkins;

        public void SetCheckins(List<CheckIn> checkinDesks)
        {
            checkins = new List<CheckIn>();
            foreach (CheckIn desk in checkins)
            {
                checkins.Add(desk);
            }
        }

        public void SetupQueues()
        {
            checkinQueues = new List<Queue<Baggage>>();

            foreach (int index in Enumerable.Range(0, checkins.Count))
            {

            }
        }

        public override void PassBaggage(Baggage Lastbaggage)
        {
            throw new NotImplementedException();
        }
    }
}
