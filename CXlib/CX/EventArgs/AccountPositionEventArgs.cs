using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CXlib
{
    public class AccountPositionEventArgs : EventArgs
    {
        public int SequenceNumber { get; internal set; }
        public AccountPosition Position { get; internal set; }
    }
}
