using Newtonsoft.Json;
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
        public bool IsConnected { get; private set; }
        public bool IsAuthenticated { get; private set; }

        public event EventHandler OnGetProducts;
        public event EventHandler OnGetInstruments;
        
        private WebSocket ws;

        public CX(string url)
        {
            ConnectToAPI(url);
        }
        
        private void ConnectToAPI(string url)
        {
            ws = new WebSocket(url);
            ws.OnOpen += (sender, e) =>
            {
                Console.WriteLine($"Websocket Open: {url}");
                IsConnected = true;
            };
            ws.OnMessage += (sender, e) =>
            {
                Console.WriteLine($"Websocket Message {e.Data}");
                Frame frame = Frame.Deserialize(e.Data);
            };
            ws.OnClose += (sender, e) =>
            {
                Console.WriteLine($"Websocket Close: {e.Code} {e.Reason}");
                IsConnected = false;
                ConnectToAPI(url);
            };
            ws.OnError += (sender, e) =>
            {
                Console.WriteLine($"Websocket Error: {e.Exception} {e.Message}");
                IsConnected = false;
                ConnectToAPI(url);
            };
            ws.Connect();
        }

        public void GetProducts(int sequenceNumber)
        {
            Frame frame = new Frame {
                MessageType = MessageType.Request,
                SequenceNumber = sequenceNumber,
                FunctionName = "GetProducts",
                Payload = new { OMSId = 1 }
            };
            ws.Send(Frame.Serialize(frame));
        }

        public void GetInstruments(int sequenceNumber)
        {
            Frame frame = new Frame
            {
                MessageType = MessageType.Request,
                SequenceNumber = sequenceNumber,
                FunctionName = "GetInstruments",
                Payload = new { OMSId = 1 }
            };
            ws.Send(Frame.Serialize(frame));
        }

        public void WebAuthenticateUser(string username, string password)
        {
            ws.Send("{\"m\":0,\"i\":0,\"n\":\"WebAuthenticateUser\",\"o\":\"{\\\"UserName\\\":\\\"User1\\\",\\\"Password\\\":\\\"Password\\\"}\"}");
        }

        public void GetUserAccounts()
        {
            ws.Send("{\"m\":0,\"i\":0,\"n\":\"GetUserAccounts\",\"o\":\"\"}");
        }

        public void GetAccountTransactions(int accountId, int depth)
        {
            ws.Send("{\"m\":0,\"i\":0,\"n\":\"GetAccountTransactions\",\"o\":\"{\\\"OMSId\\\":1,\\\"AccountId\\\": 1,\\\"Depth\\\": 200}\"}");
        }

        public void GetAccountPositions(int accountId)
        {
            ws.Send("{\"m\":0,\"i\":0,\"n\":\"GetAccountPositions\",\"o\":\"{\\\"OMSId\\\":1,\\\"AccountId\\\":4}\"}");
        }

        public void GetAccountTrades(int accountId, int count, int startIndex)
        {
            ws.Send("{\"m\":0,\"i\":0,\"n\":\"GetAccountTrades\",\"o\":\"{\\\"OMSId\\\":1,\\\"AccountId\\\":4,\\\"Count\\\":50,\\\"StartIndex\\\":0}\"}");
        }

        public void SendOrder(int accountId, int clientOrderId, decimal quantity, decimal displayQuantity, bool useDisplayQuantity, decimal limitPrice, int orderIdOCO, int orderType, int pegPriceType, int instrumentId, decimal TrailingAmount, decimal limitOffset, bool side, decimal stopPrice, int timeInForce)
        {
            ws.Send("{\"m\":0,\"i\":0,\"n\":\"SendOrder\",\"o\":\"{\\\"OMSId\\\": 1,\\\"AccountId\\\": 4,\\\"ClientOrderId\\\": 99,\\\"Quantity\\\": 1,\\\"DisplayQuantity\\\": 0,\\\"UseDisplayQuantity\\\": true,\\\"LimitPrice\\\": 95,\\\"OrderIdOCO\\\": 0,\\\"OrderType\\\": 2,\\\"PegPriceType\\\": 1,\\\"InstrumentId\\\": 1,\\\"TrailingAmount\\\": 1.0,\\\"LimitOffset\\\": 2.0,\\\"Side\\\": 0,\\\"StopPrice\\\": 96,\\\"TimeInForce\\\": 1}\"}");
        }

        public void GetOrderStatus()
        {
            //ws.Send("{\"m\":0,\"i\":0,\"n\":\"GetOrderStatus\",\"o\":\"{\\\"OMSId\\\":1,\\\"AccountId\\\":4,\\\"OrderId\\\":12}\"}");
        }
    }
}
