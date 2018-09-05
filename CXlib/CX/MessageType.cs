using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CXlib
{
    public static class MessageType
    {
        public static int Request { get => 0; }
        public static int Reply { get => 1; }
        public static int Subscribe { get => 2; }
        public static int Event { get => 3; }
        public static int Unsubscribe { get => 4; }
        public static int Error { get => 5; }
    }
}
