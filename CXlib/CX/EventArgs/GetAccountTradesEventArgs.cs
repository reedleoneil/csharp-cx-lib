using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CXlib
{
    public class GetAccountTradesEventArgs : EventArgs
    {
        public int SequenceNumber { get; internal set; }
        public AccountTrade[] Trades { get; internal set; }
    }
}
