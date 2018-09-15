using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CXlib
{
    public class GetOrderFeeEventArgs : EventArgs
    {
        public int SequenceNumber { get; internal set; }
        public decimal OrderFee { get; internal set; }
        public int ProductId { get; internal set; }
    }
}
