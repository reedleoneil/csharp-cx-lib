using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CXlib
{
    public class OrderStateEventArgs : EventArgs
    {
        public int SequenceNumber { get; internal set; }
        public OrderStatus OrderStatus { get; internal set; }
    }
}
