using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSocketSharp;

namespace CXlib
{
    public class CX
    {
        public static string Production { get => "wss://api-cx.coins.asia/ws-api/"; }
        public static string Staging { get => "wss://api-cx.staging.coins.technology/ws-api/"; }
        public List<Product> Products { get; }
        public List<Instrument> Instruments { get; }
        private WebSocket ws;

        public CX(string url)
        {
            ws = new WebSocket(url);

            ws.OnOpen += (sender, e) =>
                Console.WriteLine("open");
            ws.OnMessage += (sender, e) =>
                Console.WriteLine("message " + e.Data);
            ws.OnClose += (sender, e) =>
               Console.WriteLine("close " + e.Reason);
            ws.OnError += (sender, e) =>
                Console.WriteLine("error " + e.Message);

            ws.Connect();
        }
        
        public void GetProducts()
        {
            ws.Send("{\"m\":0,\"i\":0,\"n\":\"GetProducts\",\"o\":\"{\\\"OMSId\\\": 1}\"}");
        }
    }
}
