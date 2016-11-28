using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrettyHairLibrary
{
    public class SendMail
    {
        public SendMail() {

        }

        public void Subscribe(OrderRepository ort)
        {
            ort.Tick += new OrderRepository.TickHandler(HeardIt);
        }

        public void HeardIt(OrderRepository m, EventArgs e)
        {
            Console.WriteLine("WE DID IT");
        }
    }
}
