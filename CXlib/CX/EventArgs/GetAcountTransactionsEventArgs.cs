using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CXlib
{
    public class GetAccountTransactionsEventArgs : EventArgs
    {
        public int SequenceNumber { get; internal set; }
        public AccountTransaction[] Transactions { get; internal set; }
    }
}
