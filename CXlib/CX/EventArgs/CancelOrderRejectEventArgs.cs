using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CXlib
{
    public class CancelOrderRejectEventArgs : EventArgs
    {
        public int SequenceNumber { get; internal set; }
        public int AccountId { get; internal set; }
        public int OrderId { get; internal set; }
        public string Status { get; internal set; }
        public string RejectReason { get; internal set; }
        public int InstrumentId { get; internal set; }
        public string OrderType { get; internal set; }
        public int OrderRevision { get; internal set; }
    }
}
