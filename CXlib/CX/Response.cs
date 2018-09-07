using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CXlib
{
    class Response
    {
        [JsonProperty("result")]
        public bool Result { get; internal set; }
        [JsonProperty("errormessage")]
        public string ErrorMessage { get; internal set; }
        [JsonProperty("errorcode")]
        public int ErrorCode { get; internal set; }
        [JsonProperty("detail")]
        public string Detail { get; internal set; }
    }
}
