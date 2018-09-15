using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CXlib
{
    public class MarketStateUpdateEventArgs : EventArgs
    {
        public int SequenceNumber { get; internal set; }
        public int EchangeId { get; internal set; }
        public int VenueAdapterId { get; internal set; }
        public int VenueInstrumentId { get; internal set; }
        public string Action { get; internal set; }
        public string PreviousStatus { get; internal set; }
        public string NewStatus { get; internal set; }
        public string ExchangeDateTime { get; internal set; }
    }
}
