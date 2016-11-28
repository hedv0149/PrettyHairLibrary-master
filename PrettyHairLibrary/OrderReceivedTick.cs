using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrettyHairLibrary
{
    public class OrderReceivedTick
    {
        public event TickHandler Tick;
        public EventArgs e = null;
        public delegate void TickHandler(OrderReceivedTick m, EventArgs e);
        public void ReceiveOrder() {
            Tick(this, e);
        }
    }
}
