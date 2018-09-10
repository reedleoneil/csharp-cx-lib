using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CXlib
{
    public class GetUserAccountsEventArgs : EventArgs
    {
        public int SequenceNumber { get; internal set; }
        public int[] AccountIds { get; internal set; }
    }
}
