using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CXlib
{
    public class GetAccountPositionsEventArgs : EventArgs
    {
        public int SequenceNumber { get; internal set; }
        public AccountPosition[] Positions { get; internal set; }
    }
}
