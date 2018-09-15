using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CXlib
{
    public class NewOrderRejectEventArgs : EventArgs
    {
        public int SequnceNumber { get; internal set; }
        public int AccountId { get; internal set; }
        public int ClientOrderId { get; internal set; }
        public string Status { get; internal set; }
        public string RejectReason { get; internal set; }
    }
}
