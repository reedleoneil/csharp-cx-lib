using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CXlib
{
    public class PendingDepositeUpdateEventArgs : EventArgs
    {
        public int SequenceNumber { get; internal set; }
        public int AccountId { get; internal set; }
        public int AssetId { get; internal set; }
        public decimal TotalPendingDepositValue { get; internal set; }
    }
}
