using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        public string SessionToken { get; private set; }
        public int UserId { get; private set; }
        public Product[] Products { get; private set; }
        public Instrument[] Instruments { get; private set; }
        public int[] Accounts { get; private set; } = { };

        public event EventHandler<GetProductsEventArgs> OnGetProducts;
        public event EventHandler<GetInstrumentsEventArgs> OnGetInstruments;
        public event EventHandler<WebAuthenticateUserEventArgs> OnWebAuthenticateUser;
        public event EventHandler<GetUserAccountsEventArgs> OnGetUserAccounts;
        public event EventHandler<GetAccountTransactionsEventArgs> OnGetAccountTransactions;
        public event EventHandler<GetAccountPositionsEventArgs> OnGetAccountPositions;
        public event EventHandler<GetAccountTradesEventArgs> OnGetAccountTrades;
        public event EventHandler<SendOrderEventArgs> OnSendOrder;
        public event EventHandler<CancelOrderEventArgs> OnCancelOrder;
        public event EventHandler<GetOrderStatusEventArgs> OnGetOrderStatus;
        public event EventHandler<GetOrderFeeEventArgs> OnGetOrderFee;
        public event EventHandler<GetOrderHistoryEventArgs> OnGetOrderHistory;
        public event EventHandler<GetOpenOrdersEventArgs> OnGetOpenOrders;
        public event EventHandler<CreateWithdrawTicketEventArgs> OnCreateWithdrawTicket;
        public event EventHandler<SubscribeLevel1EventArgs> OnSubscribeLevel1;
        public event EventHandler<UnsubscribeLevel1EventArgs> OnUnsubscribeLevel1;
        public event EventHandler<SubscribeLevel2EventArgs> OnSubscribeLevel2;
        public event EventHandler<UnsubscribeLevel2EventArgs> OnUnsubscribeLevel2;
        public event EventHandler<SubscribeTradesEventArgs> OnSubscribeTrades;
        public event EventHandler<UnsubscribeTradesEventArgs> OnUnsubscribeTrades;
        public event EventHandler<SubscribeAcountEventsEventArgs> OnSubscribeAccountEvents;
        public event EventHandler<Level1UpdateEventArgs> Level1UpdateEvent;
        public event EventHandler<Level2UpdateEventArgs> Level2UpdateEvent;
        public event EventHandler<TradeDataUpdateEventArgs> TradeDataUpdateEvent;
        public event EventHandler<PendingDepositeUpdateEventArgs> PendingDepositUpdate;
        public event EventHandler<AccountPositionEventArgs> AccountPositionEvent;
        public event EventHandler<OrderStateEventArgs> OrderStateEvent;
        public event EventHandler<OrderTradeEventArgs> OrderTradeEvent;
        public event EventHandler<NewOrderRejectEventArgs> NewOrderRejectEvent;
        public event EventHandler<CancelOrderRejectEventArgs> CancelOrderRejectEvent;
        public event EventHandler<MarketStateUpdateEventArgs> MarketStateUpdate;

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
                Debug.WriteLine($"Websocket Open: {url}");
                IsConnected = true;
            };
            ws.OnMessage += (sender, e) =>
            {
                Debug.WriteLine($"Websocket Message {e.Data}");
                Frame frame = Frame.Deserialize(e.Data);
                switch (frame.MessageType)
                {
                    case MessageType.Reply:
                        switch (frame.FunctionName)
                        {
                            case "GetProducts":
                                Product[] products = ((JArray)frame.Payload).ToObject<Product[]>();
                                OnGetProducts(this, new GetProductsEventArgs { SequenceNumber = frame.SequenceNumber, Products = products });
                                this.Products = products;
                                break;
                            case "GetInstruments":
                                Instrument[] instruments = ((JArray)frame.Payload).ToObject<Instrument[]>();
                                OnGetInstruments(this, new GetInstrumentsEventArgs { SequenceNumber = frame.SequenceNumber, Instruments = instruments });
                                this.Instruments = instruments;
                                break;
                            case "WebAuthenticateUser":
                                JObject wau_payload = JObject.FromObject(frame.Payload);
                                OnWebAuthenticateUser(this, new WebAuthenticateUserEventArgs { SequenceNumber = frame.SequenceNumber, Authenticated = (bool)wau_payload["Authenticated"], SessionToken = (string)wau_payload["SessionToken"], UserId = (int?)wau_payload["UserId"], ErrorMessage = (string)wau_payload["errormsg"] });
                                this.IsAuthenticated = (bool)wau_payload["Authenticated"];
                                this.SessionToken = (string)wau_payload["SessionTocken"];
                                this.UserId = (int)wau_payload["UserId"];
                                break;
                            case "GetUserAccounts":
                                int[] accountIds = ((JArray)frame.Payload).ToObject<int[]>();
                                OnGetUserAccounts(this, new GetUserAccountsEventArgs { SequenceNumber = frame.SequenceNumber, AccountIds = accountIds });
                                this.Accounts = accountIds;
                                break;
                            case "GetAccountTransactions":
                                    AccountTransaction[] transactions = ((JArray)frame.Payload).ToObject<AccountTransaction[]>();
                                    OnGetAccountTransactions(this, new GetAccountTransactionsEventArgs { SequenceNumber = frame.SequenceNumber, Transactions = transactions });
                                break;
                            case "GetAccountPositions":
                                AccountPosition[] positions = ((JArray)frame.Payload).ToObject<AccountPosition[]>();
                                OnGetAccountPositions(this, new GetAccountPositionsEventArgs { SequenceNumber = frame.SequenceNumber, Positions = positions });
                                break;
                            case "GetAccountTrades":
                                AccountTrade[] trades = ((JArray)frame.Payload).ToObject<AccountTrade[]>();
                                OnGetAccountTrades(this, new GetAccountTradesEventArgs { SequenceNumber = frame.SequenceNumber, Trades = trades });
                                break;
                            case "SendOrder":
                                JObject so_payload = JObject.FromObject(frame.Payload);
                                OnSendOrder(this, new SendOrderEventArgs { SequenceNumber = frame.SequenceNumber, Status = (string)so_payload["status"], ErrorMessage = (string)so_payload["errormsg"], OrderId = (int)so_payload["OrderId"] });
                                break;
                            case "CancelOrder":
                                JObject co_payload = JObject.FromObject(frame.Payload);
                                OnCancelOrder(this, new CancelOrderEventArgs { SequenceNumber = frame.SequenceNumber, Status = (string)co_payload["status"], ErrorMessage = (string)co_payload["errormsg"], Detail = (string)co_payload["detail"], ErrorCode = (int)co_payload["errorcode"] });
                                break;
                            case "GetOrderStatus":
                                JObject gos_payload = JObject.FromObject(frame.Payload);
                                OnGetOrderStatus(this, new GetOrderStatusEventArgs { SequenceNumber = frame.SequenceNumber, OrderStatus = gos_payload.ToObject<OrderStatus>() });
                                break;
                            case "GetOrderFee":
                                JObject gof_payload = JObject.FromObject(frame.Payload);
                                OnGetOrderFee(this, new GetOrderFeeEventArgs { SequenceNumber = frame.SequenceNumber, OrderFee = (decimal)gof_payload["OrderFee"], ProductId = (int)gof_payload["ProductId"] });
                                break;
                            case "GetOrderHistory":
                                OrderStatus[] goh_orders = ((JArray)frame.Payload).ToObject<OrderStatus[]>();
                                OnGetOrderHistory(this, new GetOrderHistoryEventArgs { SequenceNumber = frame.SequenceNumber, Orders = goh_orders });
                                break;
                            case "GetOpenOrders":
                                OrderStatus[] goo_orders = ((JArray)frame.Payload).ToObject<OrderStatus[]>();
                                OnGetOpenOrders(this, new GetOpenOrdersEventArgs { SequenceNumber = frame.SequenceNumber, Orders = goo_orders });
                                break;
                            case "CreateWithdrawTicket":
                                JObject cwt_payload = JObject.FromObject(frame.Payload);
                                OnCreateWithdrawTicket(this, new CreateWithdrawTicketEventArgs { SequenceNumber = frame.SequenceNumber, Result = (string)cwt_payload["result"], ErrorMessage = (string)cwt_payload["errormsg"], ErrorCode = (int)cwt_payload["errorcode"] });
                                break;
                            case "SubscribeLevel1":
                                JObject sl1_payload = JObject.FromObject(frame.Payload);
                                OnSubscribeLevel1(this, new SubscribeLevel1EventArgs { SequenceNumber = frame.SequenceNumber, MarketData = sl1_payload.ToObject<MarketDataLevel1>() });
                                break;
                            case "UnsubscribeLevel1":
                                JObject ul1_payload = JObject.FromObject(frame.Payload);
                                OnUnsubscribeLevel1(this, new UnsubscribeLevel1EventArgs { SequenceNumber = frame.SequenceNumber, Result = (bool)ul1_payload["result"], ErrorMessage = (string)ul1_payload["errormsg"], Detail = (string)ul1_payload["detail"], ErrorCode = (int)ul1_payload["errorcode"] });
                                break;
                            case "SubscribeLevel2":
                                var sl2_payload = ((JArray)frame.Payload).ToArray();
                                List<MarketDataLevel2> marketDataLevel2 = new List<MarketDataLevel2>();
                                foreach(var marketData in sl2_payload)
                                    marketDataLevel2.Add(new MarketDataLevel2 { SequenceNumber = (int)marketData[0], NumTraders = (int)marketData[1], Timestamp = (long)marketData[2], ChangeType = (int)marketData[3], LastTradedPx = (decimal)marketData[4], NumOrders = (int)marketData[5], Price = (decimal)marketData[6], InstrumenId = (int)marketData[7], Quantity = (decimal)marketData[8], Side = (int)marketData[9] });
                                OnSubscribeLevel2(this, new SubscribeLevel2EventArgs { SequenceNumber = frame.SequenceNumber, MarketData = marketDataLevel2.ToArray() });
                                break;
                            case "UnsbuscribeLevel2":
                                JObject ul2_payload = JObject.FromObject(frame.Payload);
                                OnUnsubscribeLevel2(this, new UnsubscribeLevel2EventArgs { SequenceNumber = frame.SequenceNumber, Result = (bool)ul2_payload["result"], ErrorMessage = (string)ul2_payload["errormsg"], Detail = (string)ul2_payload["detail"], ErrorCode = (int)ul2_payload["errorcode"] });
                                break;
                            case "SubscribeTrades":
                                var st_payload = ((JArray)frame.Payload).ToArray();
                                List<MarketTrade> marketTrades = new List<MarketTrade>();
                                foreach (var marketTrade in st_payload)
                                    marketTrades.Add(new MarketTrade { TradeId = (int)marketTrade[0], InstrumentId = (int)marketTrade[1], Quantity = (decimal)marketTrade[2], Price = (decimal)marketTrade[3], Timestamp = (long)marketTrade[4], Direction = (int)marketTrade[5], TakerSide = (int)marketTrade[6] });
                                OnSubscribeTrades(this, new SubscribeTradesEventArgs { SequenceNumber = frame.SequenceNumber, MarketTrades = marketTrades.ToArray() });
                                break;
                            case "UnsubscribeTrades":
                                JObject ut_payload = JObject.FromObject(frame.Payload);
                                OnUnsubscribeTrades(this, new UnsubscribeTradesEventArgs { SequenceNumber = frame.SequenceNumber, Result = (bool)ut_payload["result"], ErrorMessage = (string)ut_payload["errormsg"], Detail = (string)ut_payload["detail"], ErrorCode = (int)ut_payload["errorcode"] });
                                break;
                            case "SubscribeAccountEvents":
                                JObject sat_payload = JObject.FromObject(frame.Payload);
                                OnSubscribeAccountEvents(this, new SubscribeAcountEventsEventArgs { SequenceNumber = frame.SequenceNumber, Result = (bool)sat_payload["result"], ErrorMessage = (string)sat_payload["errormsg"], Detail = (string)sat_payload["detail"], ErrorCode = (int)sat_payload["errorcode"] });
                                break;
                        }
                        break;
                    case MessageType.Event:
                        switch (frame.FunctionName)
                        {
                            case "Level1UpdateEvent":
                                JObject l1ue_payload = JObject.FromObject(frame.Payload);
                                Level1UpdateEvent(this, new Level1UpdateEventArgs { SequenceNumber = frame.SequenceNumber, MarketData = l1ue_payload.ToObject<MarketDataLevel1>() });
                                break;
                            case "Level2UpdateEvent":
                                var l2ue_payload = ((JArray)frame.Payload).ToArray();
                                List<MarketDataLevel2> marketDataLevel2 = new List<MarketDataLevel2>();
                                foreach (var marketData in l2ue_payload)
                                    marketDataLevel2.Add(new MarketDataLevel2 { SequenceNumber = (int)marketData[0], NumTraders = (int)marketData[1], Timestamp = (long)marketData[2], ChangeType = (int)marketData[3], LastTradedPx = (decimal)marketData[4], NumOrders = (int)marketData[5], Price = (decimal)marketData[6], InstrumenId = (int)marketData[7], Quantity = (decimal)marketData[8], Side = (int)marketData[9] });
                                Level2UpdateEvent(this, new Level2UpdateEventArgs { SequenceNumber = frame.SequenceNumber, MarketData = marketDataLevel2.ToArray() });
                                break;
                            case "TradeDataUpdateEvent":
                                var tdue_payload = ((JArray)frame.Payload).ToArray();
                                List<MarketTrade> marketTrades = new List<MarketTrade>();
                                foreach (var marketTrade in tdue_payload)
                                    marketTrades.Add(new MarketTrade { TradeId = (int)marketTrade[0], InstrumentId = (int)marketTrade[1], Quantity = (decimal)marketTrade[2], Price = (decimal)marketTrade[3], Timestamp = (long)marketTrade[4], Direction = (int)marketTrade[5], TakerSide = (int)marketTrade[6] });
                                TradeDataUpdateEvent(this, new TradeDataUpdateEventArgs { SequenceNumber = frame.SequenceNumber, MarketTrades = marketTrades.ToArray() });
                                break;
                            case "PendingDepositUpdate":
                                JObject pdu_payload = JObject.FromObject(frame.Payload);
                                PendingDepositUpdate(this, new PendingDepositeUpdateEventArgs { SequenceNumber = frame.SequenceNumber, AccountId = (int)pdu_payload["AccountId"], AssetId = (int)pdu_payload["AssetId"], TotalPendingDepositValue = (decimal)pdu_payload["TotalPendingDepositValue"] });
                                break;
                            case "AccountPositionEvent":
                                JObject ape_payload = JObject.FromObject(frame.Payload);
                                AccountPositionEvent(this, new AccountPositionEventArgs { SequenceNumber = frame.SequenceNumber, Position = ape_payload.ToObject<AccountPosition>() });
                                break;
                            case "OrderStateEvent":
                                JObject ose_payload = JObject.FromObject(frame.Payload);
                                OrderStateEvent(this, new OrderStateEventArgs { SequenceNumber = frame.SequenceNumber, OrderStatus = ose_payload.ToObject<OrderStatus>() });
                                break;
                            case "OrderTradeEvent":
                                JObject ote_payload = JObject.FromObject(frame.Payload);
                                OrderTradeEvent(this, new OrderTradeEventArgs { SequenceNumber = frame.SequenceNumber, Trade = ote_payload.ToObject<AccountTrade>() });
                                break;
                            case "NewOrderRejectEvent":
                                JObject nore_payload = JObject.FromObject(frame.Payload);
                                NewOrderRejectEvent(this, new NewOrderRejectEventArgs { SequnceNumber = frame.SequenceNumber, AccountId = (int)nore_payload["AccountId"], ClientOrderId = (int)nore_payload["ClientOrderId"], Status = (string)nore_payload["Status"], RejectReason = (string)nore_payload["RejectReason"] });
                                break;
                            case "CancelOrderRejectEvent":
                                JObject core_payload = JObject.FromObject(frame.Payload);
                                CancelOrderRejectEvent(this, new CancelOrderRejectEventArgs { SequenceNumber = frame.SequenceNumber, AccountId = (int)core_payload["AccountId"], OrderId = (int)core_payload["OrderId"], Status = (string)core_payload["Status"], RejectReason = (string)core_payload["RejectReason"] });
                                break;
                            case "MarketStateUpdate":
                                JObject msu_payload = JObject.FromObject(frame.Payload);
                                MarketStateUpdate(this, new MarketStateUpdateEventArgs { SequenceNumber = frame.SequenceNumber, EchangeId = (int)msu_payload["EchangeId"], VenueAdapterId = (int)msu_payload["VenueAdapterId"], VenueInstrumentId = (int)msu_payload["VenueInstrumentId"], Action = (string)msu_payload["Action"], PreviousStatus = (string)msu_payload["PreviousState"], NewStatus = (string)msu_payload["PreviousStatus"], ExchangeDateTime = (string)msu_payload["ExhangeDateTime"] });
                                break;
                        }
                        break;
                    case MessageType.Error:
                        break;
                }
            };
            ws.OnClose += (sender, e) =>
            {
                Debug.WriteLine($"Websocket Close: {e.Code} {e.Reason}");
                IsConnected = false;
                ConnectToAPI(url);
            };
            ws.OnError += (sender, e) =>
            {
                Debug.WriteLine($"Websocket Error: {e.Exception} {e.Message}");
                //IsConnected = false;
                //ConnectToAPI(url);
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

        public void SendOrder(Order order, int sequenceNumber = 0)
        {
            Frame frame = new Frame
            {
                MessageType = MessageType.Request,
                SequenceNumber = sequenceNumber,
                FunctionName = "SendOrder",
                Payload = order
            };
            ws.Send(Frame.Serialize(frame));
        }

        public void CancelOrder(int accountId, int clientOrderId, int orderId, int sequenceNumber = 0)
        {
            Frame frame = new Frame
            {
                MessageType = MessageType.Request,
                SequenceNumber = sequenceNumber,
                FunctionName = "CancelOrder",
                Payload = new { OMSId = 1, AccountId = accountId, ClientOrderId = clientOrderId, OrderId = orderId }
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

        public void SubscribeLevel1(int instrumentId, int sequenceNumber = 1)
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

        public void SubscribeAccountEvents(int accountId, int sequenceNumber = 0)
        {
            Frame frame = new Frame
            {
                MessageType = MessageType.Request,
                SequenceNumber = sequenceNumber,
                //FunctionName = "SubscribeAccountEvents",
                FunctionName = "SubscribeAccountEvents",
                Payload = new { OMSId = 1, AccountId = accountId }
            };
            ws.Send(Frame.Serialize(frame));
        }
    }
}
