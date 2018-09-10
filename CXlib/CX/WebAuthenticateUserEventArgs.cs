using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CXlib
{
    public class WebAuthenticateUserEventArgs : EventArgs
    {
        public int SequenceNumber { get; internal set; }
        public bool Authenticated { get; internal set; }
        public string SessionToken { get; internal set; }
        public int? UserId { get; internal set; }
        public string ErrorMessage { get; internal set; }
    }
}
