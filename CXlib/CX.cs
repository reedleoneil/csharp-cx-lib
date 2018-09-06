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

        public void GetProducts(int sequenceNumber = 0)
        {
            Frame frame = new Frame {
                MessageType = MessageType.Request,
                SequenceNumber = sequenceNumber,
                FunctionName = "GetProducts",
                Payload = new { OMSId = 1 }
            };
            ws.Send(Frame.Serialize(frame));
        }

        public void GetInstruments(int sequenceNumber = 0)
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

        public void WebAuthenticateUser(string username, string password, int sequenceNumber = 0)
        {
            Frame frame = new Frame
            {
                MessageType = MessageType.Request,
                SequenceNumber = sequenceNumber,
                FunctionName = "WebAuthenticateUser",
                Payload = new { UserName = username, Password = password }
            };
            ws.Send(Frame.Serialize(frame));
        }

        public void GetUserAccounts(int sequenceNumber = 0)
        {
            Frame frame = new Frame
            {
                MessageType = MessageType.Request,
                SequenceNumber = sequenceNumber,
                FunctionName = "GetUserAccounts",
                Payload = new { }
            };
            ws.Send(Frame.Serialize(frame));
        }

        public void GetAccountTransactions(int accountId, int depth, int sequenceNumber = 0)
        {
            Frame frame = new Frame
            {
                MessageType = MessageType.Request,
                SequenceNumber = sequenceNumber,
                FunctionName = "GetAccountTransactions",
                Payload = new { OMSId = 1, AccountId = accountId, Depth = depth }
            };
            ws.Send(Frame.Serialize(frame));
        }

        public void GetAccountPositions(int accountId, int sequenceNumber = 0)
        {
            Frame frame = new Frame
            {
                MessageType = MessageType.Request,
                SequenceNumber = sequenceNumber,
                FunctionName = "GetAccountPositions",
                Payload = new { OMSId = 1, AccountId = accountId }
            };
            ws.Send(Frame.Serialize(frame));
        }

        public void GetAccountTrades(int accountId, int count, int startIndex, int sequenceNumber = 0)
        {
            Frame frame = new Frame
            {
                MessageType = MessageType.Request,
                SequenceNumber = sequenceNumber,
                FunctionName = "GetAccountTrades",
                Payload = new { OMSId = 1, AccountId = accountId, Count = count, StartIndex= startIndex }
            };
            ws.Send(Frame.Serialize(frame));
        }

        public void SendOrder(int accountId, int clientOrderId, decimal quantity, decimal displayQuantity, bool useDisplayQuantity, decimal limitPrice, int orderIdOCO, int orderType, int pegPriceType, int instrumentId, decimal TrailingAmount, decimal limitOffset, bool side, decimal stopPrice, int timeInForce, int sequenceNumber = 0)
        {
            Frame frame = new Frame
            {
                MessageType = MessageType.Request,
                SequenceNumber = sequenceNumber,
                FunctionName = "SendOrder",
                Payload = new { OMSId = 1, AccountId = accountId, ClientOrderId = clientOrderId, Quantity = quantity, DisplayQuantity = displayQuantity, UseDisplayQuantity = useDisplayQuantity, LimitPrice = limitPrice, OrderIdOCO = orderIdOCO, OrderType = orderType, PegPriceType = pegPriceType, InstrumentId = instrumentId, LimitOffset = limitOffset, Side = side, StopPrice = stopPrice, TimeInForce = timeInForce }
            };
            ws.Send(Frame.Serialize(frame));
        }

        public void CancelOrder(int accountId, int orderId, int sequenceNumber = 0)
        {
            Frame frame = new Frame
            {
                MessageType = MessageType.Request,
                SequenceNumber = sequenceNumber,
                FunctionName = "CancelOrder",
                Payload = new { OMSId = 1, AccountId = accountId, OrderId = orderId }
            };
            ws.Send(Frame.Serialize(frame));
        }

        public void GetOrderStatus(int accountId, int orderId, int sequenceNumber = 0)
        {
            Frame frame = new Frame
            {
                MessageType = MessageType.Request,
                SequenceNumber = sequenceNumber,
                FunctionName = "GetOrderStatus",
                Payload = new { OMSId = 1, AccountId = accountId, OrderId = orderId }
            };
            ws.Send(Frame.Serialize(frame));
        }

        public void GetOrderFee(int accountId, int instrumentId, int productId, decimal amount, string orderType, string makerTaker, int sequenceNumber = 0)
        {
            Frame frame = new Frame
            {
                MessageType = MessageType.Request,
                SequenceNumber = sequenceNumber,
                FunctionName = "GetOrderFee",
                Payload = new { OMSId = 1, AccountId = accountId, InstrumentId = instrumentId, ProductId = productId, Amount = amount, OrderType = orderType, MakerTaker = makerTaker }
            };
            ws.Send(Frame.Serialize(frame));
        }

        public void GetOrderHistory(int accountId, int sequenceNumber = 0)
        {
            Frame frame = new Frame
            {
                MessageType = MessageType.Request,
                SequenceNumber = sequenceNumber,
                FunctionName = "GetOrderHistory",
                Payload = new { OMSId = 1, AccountId = accountId }
            };
            ws.Send(Frame.Serialize(frame));
        }

        public void GetOpenOrders(int accountId, int sequenceNumber = 0)
        {
            Frame frame = new Frame
            {
                MessageType = MessageType.Request,
                SequenceNumber = sequenceNumber,
                FunctionName = "GetOpenOrders",
                Payload = new { OMSId = 1, AccountId = accountId }
            };
            ws.Send(Frame.Serialize(frame));
        }

        public void CreateWithdrawTicket(int productId, int accountId, decimal amount, int sequenceNumber = 0)
        {
            Frame frame = new Frame
            {
                MessageType = MessageType.Request,
                SequenceNumber = sequenceNumber,
                FunctionName = "CreateWithdrawTicket",
                Payload = new { OMSId = 1, ProductId = productId, AccountId = accountId, Amount = amount }
            };
            ws.Send(Frame.Serialize(frame));
        }

        public void SubscribeLevel1(int instrumentId, int sequenceNumber = 0)
        {
            Frame frame = new Frame
            {
                MessageType = MessageType.Request,
                SequenceNumber = sequenceNumber,
                FunctionName = "SubscribeLevel1",
                Payload = new { OMSId = 1, InstrumentId = instrumentId }
            };
            ws.Send(Frame.Serialize(frame));
        }

        public void UnsubscribeLevel1(int instrumentId, int sequenceNumber = 0)
        {
            Frame frame = new Frame
            {
                MessageType = MessageType.Request,
                SequenceNumber = sequenceNumber,
                FunctionName = "UnsubscribeLevel1",
                Payload = new { OMSId = 1, InstrumentId = instrumentId }
            };
            ws.Send(Frame.Serialize(frame));
        }

        public void SubscribeLevel2(int instrumentId, int depth, int sequenceNumber = 0)
        {
            Frame frame = new Frame
            {
                MessageType = MessageType.Request,
                SequenceNumber = sequenceNumber,
                FunctionName = "SubscribeLevel2",
                Payload = new { OMSId = 1, InstrumentId = instrumentId, Depth = depth }
            };
            ws.Send(Frame.Serialize(frame));
        }

        public void UnsubscribeLevel2(int instrumentId, int sequenceNumber = 0)
        {
            Frame frame = new Frame
            {
                MessageType = MessageType.Request,
                SequenceNumber = sequenceNumber,
                FunctionName = "UnsubscribeLevel2",
                Payload = new { OMSId = 1, InstrumentId = instrumentId }
            };
            ws.Send(Frame.Serialize(frame));
        }

        public void SubscribeTrades(int instrumentId, int includeLastCount, int sequenceNumber = 0)
        {
            Frame frame = new Frame
            {
                MessageType = MessageType.Request,
                SequenceNumber = sequenceNumber,
                FunctionName = "SubscribeTrades",
                Payload = new { OMSId = 1, InstrumentId = instrumentId, IncludeLastCount = includeLastCount }
            };
            ws.Send(Frame.Serialize(frame));
        }

        public void UnsubscribeTrades(int instrumentId, int sequenceNumber = 0)
        {
            Frame frame = new Frame
            {
                MessageType = MessageType.Request,
                SequenceNumber = sequenceNumber,
                FunctionName = "UnsubscribeTrades",
                Payload = new { OMSId = 1, InstrumentId = instrumentId }
            };
            ws.Send(Frame.Serialize(frame));
        }
    }
}
