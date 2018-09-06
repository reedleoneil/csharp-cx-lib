using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CXlib
{
    public class GetProductsEventArgs : EventArgs
    {
        public int SequenceNumber { get; internal set; }
        public Product[] Products { get; internal set; }
    }
}
