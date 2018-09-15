using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CXlib
{
    public class GetInstrumentsEventArgs : EventArgs
    {
        public int SequenceNumber { get; internal set; }
        public Instrument[] Instruments { get; internal set; }
    }
}
