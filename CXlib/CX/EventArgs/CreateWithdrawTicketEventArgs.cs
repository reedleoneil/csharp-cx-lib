using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CXlib
{
    public class CreateWithdrawTicketEventArgs : EventArgs
    {
        public int SequenceNumber { get; internal set; }
        public string Result { get; internal set; }
        public string ErrorMessage { get; internal set; }
        public int ErrorCode { get; internal set; }
    }
}
