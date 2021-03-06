﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CXlib
{
    public class CancelOrderEventArgs : EventArgs
    {
        public int SequenceNumber { get; internal set; }
        public string Status { get; internal set; }
        public string ErrorMessage { get; internal set; }
        public string Detail { get; internal set; }
        public int ErrorCode { get; internal set; }
    }
}
