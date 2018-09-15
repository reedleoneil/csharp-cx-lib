using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CXlib
{
    public class OrderTradeEventArgs : EventArgs
    {
        public int SequenceNumber { get; internal set; }
        public AccountTrade Trade { get; internal set; }
    }
}
