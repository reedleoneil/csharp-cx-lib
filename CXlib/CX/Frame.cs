using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CXlib
{
    class Frame
    {
        [JsonProperty("m")]
        public int MessageType { get; internal set; }
        [JsonProperty("i")]
        public int SequenceNumber { get; internal set; }
        [JsonProperty("n")]
        public string FunctionName { get; internal set; }
        [JsonProperty("o")]
        public object Payload { get; internal set; }

        public static string Serialize(Frame frame)
        {
            return JsonConvert.SerializeObject(new { m = frame.MessageType, i = frame.SequenceNumber, n = frame.FunctionName, o = JsonConvert.SerializeObject(frame.Payload) }); 
        }
        public static Frame Deserialize(string json)
        {
            Frame frame = JsonConvert.DeserializeObject<Frame>(json);
            try
            {
                frame.Payload = JsonConvert.DeserializeObject<dynamic>(frame.Payload.ToString());
            }
            catch (JsonReaderException ex)
            {

            }
            return frame;
        }
    }
}
