using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CXlib
{
    public static class MessageType
    {
        public const int Request = 0;
        public const int Reply = 1;
        public const int Subscribe = 2;
        public const int Event = 3;
        public const int Unsubscribe = 4;
        public const int Error = 5;
    }
}
