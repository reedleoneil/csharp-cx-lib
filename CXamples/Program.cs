using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CXlib;

namespace CXamples
{
    class Program
    {
        static void Main(string[] args)
        {
            CX cx = new CX(CX.Production); //Create CX instance.

            //Subscribe to GetProducts response.
            cx.OnGetProducts += (sender, e) => {
                foreach (Product product in e.Products)
                    Console.WriteLine(
                        $"{product.ProductId, -2} " +
                        $"{product.Symbol, -4} " +
                        $"{product.ProductFullName, -20} " +
                        $"{product.ProductType, -20} " +
                        $"{product.DecimalPlaces, -2}"
                    );
            };

            //Subscribe to GetInstruments response.
            cx.OnGetInstruments += (sender, e) =>
            {
                foreach (Instrument instrument in e.Instruments)
                    Console.WriteLine(
                        $"{instrument.InstrumentId, -2} " +
                        $"{instrument.Symbol, -4} " +
                        $"{instrument.Product1, -2} " +
                        $"{instrument.Product1Symbol, -4} " +
                        $"{instrument.Product2, -2} " +
                        $"{instrument.Product2Symbol, -4} " +
                        $"{instrument.InstrumentType, -10}"
                    );
            };

            //Subscribe to WebAuthenticateuser response.
            cx.OnWebAuthenticateUser += (sender, e) =>
            {
                Console.WriteLine(e.Authenticated);
                Console.WriteLine(e.SessionToken);
                Console.WriteLine(e.UserId);
                Console.WriteLine(e.ErrorMessage);
            };

            //Subscribe to GetUserAccounts response.
            cx.OnGetUserAccounts += (sender, e) =>
            {
                foreach (var account in e.AccountIds)
                    Console.WriteLine(account);
            };

            //Subscribe to GetAccountTransaction response.
            cx.OnGetAccountTransactions += (sender, e) =>
            {
                foreach (AccountTransaction transaction in e.Transactions)
                    Console.WriteLine(
                        $"{transaction.TransactionId, -4} " +
                        $"{transaction.AccountId, -2} " +
                        $"{transaction.Cr, -5} " +
                        $"{transaction.Dr, -5} " +
                        $"{transaction.TransactionType, -6}" +
                        $" {transaction.ReferenceId, -4} " +
                        $"{transaction.ProductId, -2} " +
                        $"{transaction.Balance, -7} " +
                        $"{transaction.ReferenceType, -14} " +
                        $"{transaction.TimeStamp, -15}"
                    );
            };

            //Subscribe to GetAccountPosition response.
            cx.OnGetAccountPositions += (sender, e) =>
            {
                foreach (AccountPosition position in e.Positions)
                    Console.WriteLine(
                        $"{position.AccountId, -2} " +
                        $"{position.ProductId, -2} " +
                        $"{position.ProductSymbol, -4} " +
                        $"{position.Amount, -10} " +
                        $"{position.Hold, -10} " +
                        $"{position.PendingDeposits, -10} " +
                        $"{position.PendingWithdraws, -10}"
                    );
            };

            //Subscribe to GetAccountTrades response.
            cx.OnGetAccountTrades += (sender, e) =>
            {
                foreach (AccountTrade trade in e.Trades)
                    Console.WriteLine(
                        $"{trade.TradeId, -4} " +
                        $"{trade.OrderId, -5} " +
                        $"{trade.AccountId, -2} " +
                        $"{trade.ClientOrderId, -4} " +
                        $"{trade.InstrumentId, -2} " +
                        $"{trade.Side, -5} " +
                        $"{trade.Quantity, -7} " +
                        $"{trade.Price, -7} " +
                        $"{trade.Value, -7} " +
                        $"{trade.TradeTime, -15}"
                    );
            };

            //Subscribe to SendOrder response.
            cx.OnSendOrder += (sender, e) =>
            {
                Console.WriteLine(e.Status);
                Console.WriteLine(e.ErrorMessage);
                Console.WriteLine(e.OrderId);
            };

            //Send SendOrder request.
            cx.SendOrder(new Order {
                AccountId = 4,
                ClientOrderId = 99,
                OMSId = 1,
                UseDisplayQuantity = true,
                Quantity = 1,
                DisplayQuantity = 0,
                LimitPrice = 95,
                OrderIdOCO = 0,
                OrderType = 2,                  // 1 (Market), 2 (Limit), 3 (StopMarket), 4 (StopLimit), 5 (TrailingStopMarket), 6 (TrailingStopLimit)
                PegPriceType = 1,               // 1 (Last), 2 (Bid), 3 (Ask)
                InstrumentId = 1,
                TrailingAmount = 1,
                LimitOffset = 2,
                Side = 0,                       // 0 (Buy) or 1 (Sell)
                StopPrice = 96, 
                TimeInForce = 1,                // 1 (Good 'til Canceled), 3 (Immediate or Cancel), 4 (Fill or Kill)
            });

            //Subscribe to CancelOrder response.
            cx.OnCancelOrder += (sender, e) =>
            {
                Console.WriteLine(e.Status);
                Console.WriteLine(e.ErrorMessage);
                Console.WriteLine(e.Detail);
                Console.WriteLine(e.ErrorCode);
            };

            //Subscribe to GetOrderStatus response.
            cx.OnGetOrderStatus += (sender, e) =>
            {
                OrderStatus orderStatus = e.OrderStatus;
                Console.WriteLine(orderStatus.Account);
                Console.WriteLine(orderStatus.Quantity);
                Console.WriteLine(orderStatus.OrderType);
                Console.WriteLine(orderStatus.Instrument); // 1 (Market), 2 (Limit), 3 (StopMarket), 4 (StopLimit), 5 (TrailingStopMarket), 6 (TrailingStopLimit)
                Console.WriteLine(orderStatus.Side);
                Console.WriteLine(orderStatus.OrderId);
                Console.WriteLine(orderStatus.Price);
                Console.WriteLine(orderStatus.OrderState);
                Console.WriteLine(orderStatus.OrigQuantity);
                Console.WriteLine(orderStatus.QuantityExecuted);
                Console.WriteLine(orderStatus.RejectReason);
                Console.WriteLine(orderStatus.OrigOrderId);
                Console.WriteLine(orderStatus.OrigClOrdId);
                Console.WriteLine(orderStatus.ReceiveTime);
            };

            //Subscribe to GetOrderFee
            cx.OnGetOrderFee += (sender, e) =>
            {
                Console.WriteLine(e.OrderFee);
                Console.WriteLine(e.ProductId);
            };

            //Subscribe to GetOrderHistory
            cx.OnGetOrderHistory += (sender, e) =>
            {
                foreach (OrderStatus order in e.Orders)
                    Console.WriteLine(
                        $"{order.Account, -5} " +
                        $"{order.ClientOrderId, -3} " +
                        $"{order.Quantity, -2} " +
                        $"{order.OrderType, -2} " +
                        $"{order.Instrument, -2} " +
                        $"{order.Side, -5}" +
                        $"{order.OrderId, -4} " +
                        $"{order.Price, -5} " +
                        $"{order.OrderState, -15} " +
                        $"{order.Quantity, -3} " +
                        $"{order.QuantityExecuted, -3}" +
                        $"{order.RejectReason, -10} " +
                        $"{order.OrigOrderId, -5} " +
                        $"{order.OrigClOrdId, -2} " +
                        $"{order.ReceiveTime, -15}"
                    );
            };

            //Subscribe to GetOpenOrders response.
            cx.OnGetOpenOrders += (sender, e) =>
            {
                foreach (OrderStatus order in e.Orders)
                    Console.WriteLine(
                        $"{order.Account, -5} " +
                        $"{order.ClientOrderId, -3} " +
                        $"{order.Quantity, -2} " +
                        $"{order.OrderType, -2} " +
                        $"{order.Instrument, -2} " +
                        $"{order.Side, -5}" +
                        $"{order.OrderId, -4} " +
                        $"{order.Price, -5} " +
                        $"{order.OrderState, -15} " +
                        $"{order.Quantity, -3} " +
                        $"{order.QuantityExecuted, -3}" +
                        $"{order.RejectReason, -10} " +
                        $"{order.OrigOrderId, -5} " +
                        $"{order.OrigClOrdId, -2} " +
                        $"{order.ReceiveTime, -15}"
                    );
            };

            //Subscribe to CreateWithdrawTicket response.
            cx.OnCreateWithdrawTicket += (sender, e) =>
            {
                Console.WriteLine(e.Result);
                Console.WriteLine(e.ErrorMessage);
                Console.WriteLine(e.ErrorCode);
            };

            //Subscribe to SubscribeLevel 1 response.
            cx.OnSubscribeLevel1 += (sender, e) =>
            {
                MarketDataLevel1 marketData = e.MarketData;
                Console.WriteLine(marketData.InstrumentId);
                Console.WriteLine(marketData.BestBid);
                Console.WriteLine(marketData.BestOffer);
                Console.WriteLine(marketData.LastTradedPx);
                Console.WriteLine(marketData.LastTradedQty);
                Console.WriteLine(marketData.LastTradeTime);
                Console.WriteLine(marketData.SessionOpen);
                Console.WriteLine(marketData.SessionHigh);
                Console.WriteLine(marketData.SessionLow);
                Console.WriteLine(marketData.SessionClose);
                Console.WriteLine(marketData.Volume);
                Console.WriteLine(marketData.CurrentDayVolume);
                Console.WriteLine(marketData.CurrentDayNumTrades);
                Console.WriteLine(marketData.CurrentDayPxChange);
                Console.WriteLine(marketData.Rolling24HrVolume);
                Console.WriteLine(marketData.Rolling24NumTrades);
                Console.WriteLine(marketData.Rolling24HrPxChange);
                Console.WriteLine(marketData.TimeStamp);
            };

            //Subscribe to Level1UpdateEvent event.
            cx.Level1UpdateEvent += (sender, e) =>
            {
                MarketDataLevel1 marketData = e.MarketData;
                Console.WriteLine(marketData.InstrumentId);
                Console.WriteLine(marketData.BestBid);
                Console.WriteLine(marketData.BestOffer);
                Console.WriteLine(marketData.LastTradedPx);
                Console.WriteLine(marketData.LastTradedQty);
                Console.WriteLine(marketData.LastTradeTime);
                Console.WriteLine(marketData.SessionOpen);
                Console.WriteLine(marketData.SessionHigh);
                Console.WriteLine(marketData.SessionLow);
                Console.WriteLine(marketData.SessionClose);
                Console.WriteLine(marketData.Volume);
                Console.WriteLine(marketData.CurrentDayVolume);
                Console.WriteLine(marketData.CurrentDayNumTrades);
                Console.WriteLine(marketData.CurrentDayPxChange);
                Console.WriteLine(marketData.Rolling24HrVolume);
                Console.WriteLine(marketData.Rolling24NumTrades);
                Console.WriteLine(marketData.Rolling24HrPxChange);
                Console.WriteLine(marketData.TimeStamp);
            };

            //Subscribe to UnsubscribeLevel1 response.
            cx.OnUnsubscribeLevel1 += (sender, e) =>
            {
                Console.WriteLine(e.Result);
                Console.WriteLine(e.ErrorMessage);
                Console.WriteLine(e.ErrorCode);
                Console.WriteLine(e.Detail);
            };

            //Subscribe to Subscribelevel2 response.
            cx.OnSubscribeLevel2 += (sender, e) =>
            {
                foreach (MarketDataLevel2 marketData in e.MarketData)
                {
                    Console.WriteLine(
                        $"{marketData.SequenceNumber,-7} " +
                        $"{marketData.NumTraders - 7} " +
                        $"{marketData.Timestamp,-15} " +
                        $"{marketData.ChangeType,-7} " + // 0 (New), 1 (Update), 2 (Delete)
                        $"{marketData.LastTradedPx,-7} " +
                        $"{marketData.NumOrders,-7} " +
                        $"{marketData.Price,-7} " +
                        $"{marketData.InstrumenId,-2} " +
                        $"{marketData.Quantity,-7} " +
                        $"{marketData.Side,-5} "  // 0 (Buy), 1 (Sell)
                    );
                }
            };

            //Subscribe to Level2UpdateEvent event.
            cx.Level2UpdateEvent += (sender, e) =>
            {
                foreach (MarketDataLevel2 marketData in e.MarketData)
                {
                    Console.WriteLine(
                        $"{marketData.SequenceNumber, -7} " +
                        $"{marketData.NumTraders -7} " +
                        $"{marketData.Timestamp, -15} " +
                        $"{marketData.ChangeType, -7} " + // 0 (New), 1 (Update), 2 (Delete)
                        $"{marketData.LastTradedPx, -7} " +
                        $"{marketData.NumOrders, -7} " +
                        $"{marketData.Price, -7} " +
                        $"{marketData.InstrumenId, -2} " +
                        $"{marketData.Quantity, -7} " +
                        $"{marketData.Side, -5} "  // 0 (Buy), 1 (Sell)
                    );
                }
            };

            //Subscribe to UnsubscribeLevel2 response.
            cx.OnUnsubscribeLevel2 += (sender, e) =>
            {
                Console.WriteLine(e.Result);
                Console.WriteLine(e.ErrorMessage);
                Console.WriteLine(e.ErrorCode);
                Console.WriteLine(e.Detail);
            };

            //Subscribe to SubscribeTrades response.
            cx.OnSubscribeTrades += (sender, e) =>
            {
                foreach (MarketTrade trade in e.MarketTrades)
                {
                    Console.WriteLine(
                        $"{trade.TradeId, -4} " +
                        $"{trade.InstrumentId, -2} " +
                        $"{trade.Quantity, -7} " +
                        $"{trade.Price, -7} " +
                        $"{trade.Timestamp, -15} " +
                        $"{trade.Direction, -10} " + //0 (NoChange), 1 (Uptick), 2 (Downtick)
                        $"{trade.TakerSide, -7} "
                    );
                }
            };

            //Subscribe to TradeDataUpdateEvent event.
            cx.TradeDataUpdateEvent += (sender, e) =>
            {
                foreach (MarketTrade trade in e.MarketTrades)
                {
                    Console.WriteLine(
                        $"{trade.TradeId,-4} " +
                        $"{trade.InstrumentId,-2} " +
                        $"{trade.Quantity,-7} " +
                        $"{trade.Price,-7} " +
                        $"{trade.Timestamp,-15} " +
                        $"{trade.Direction,-10} " + //0 (NoChange), 1 (Uptick), 2 (Downtick)
                        $"{trade.TakerSide,-7} "
                    );
                }
            };

            //Subscribe to UnsubscribeTrades response.
            cx.OnUnsubscribeTrades += (sender, e) =>
            {
                Console.WriteLine(e.Result);
                Console.WriteLine(e.ErrorMessage);
                Console.WriteLine(e.ErrorCode);
                Console.WriteLine(e.Detail);
            };

            //Subscribe to AccountPositionEvent
            cx.AccountPositionEvent += (sender, e) =>
            {
                AccountPosition position = e.Position;
                Console.WriteLine(
                    $"{position.AccountId, -2} " +
                    $"{position.ProductId, -2} " +
                    $"{position.ProductSymbol, -4} " +
                    $"{position.Amount, -7} " +
                    $"{position.Hold, -7} " +
                    $"{position.PendingDeposits, -7} " +
                    $"{position.PendingWithdraws, -7} " +
                    $"{position.TotalDayDeposits, -7} " +
                    $"{position.TotalDayWithdraws , -7} "
                );
            };

            //Subscribe to OrderStateEvent
            cx.OrderStateEvent += (sender, e) =>
            {
                OrderStatus order = e.OrderStatus;
                Console.WriteLine(
                    $"{order.Account, -2} " +
                    $"{order.ClientOrderId, -2} " +
                    $"{order.Quantity, -7} " +
                    $"{order.OrderType, -15}" +           // 1 (Market), 2 (Limit), 3 (StopMarket), 4 (StopLimit), 5 (TrailingStopMarket), 6 (TrailingStopLimit)
                    $"{order.Instrument, -2} " +
                    $"{order.Side, -5} " +
                    $"{order.OrderId, -4} " +
                    $"{order.Price, -4} " +
                    $"{order.OrderState, -14} " +
                    $"{order.QuantityExecuted, -7} " +
                    $"{order.ChangeReason, -42} " +
                    $"{order.ReceiveTime, -15} "
                );
            };

            //Subscribe OrderTradeEvent
            cx.OrderTradeEvent += (sender, e) =>
            {
                AccountTrade trade = e.Trade;
                Console.WriteLine(
                        $"{trade.TradeId, -4} " +
                        $"{trade.OrderId, -5} " +
                        $"{trade.AccountId, -2} " +
                        $"{trade.ClientOrderId, -4} " +
                        $"{trade.InstrumentId, -2} " +
                        $"{trade.Side, -5} " +
                        $"{trade.Quantity, -7} " +
                        $"{trade.Price, -7} " +
                        $"{trade.Value, -7} " +
                        $"{trade.TradeTime, -15}"
                    );
            };

            //Subscribe NewOrderRejectEvent
            cx.NewOrderRejectEvent += (sender, e) =>
            {
                Console.WriteLine(e.AccountId);
                Console.WriteLine(e.ClientOrderId);
                Console.WriteLine(e.Status);
                Console.WriteLine(e.RejectReason);
            };

            //Subscribe CancelOrderRejectEvent
            cx.CancelOrderRejectEvent += (sender, e) =>
            {
                Console.WriteLine(e.AccountId);
                Console.WriteLine(e.OrderId);
                Console.WriteLine(e.OrderRevision);
                Console.WriteLine(e.OrderType);
                Console.WriteLine(e.InstrumentId);
                Console.WriteLine(e.Status);
                Console.WriteLine(e.RejectReason);
            };

            //Subscribe MarketStateUpdate
            cx.MarketStateUpdate += (sender, e) =>
            {
                Console.WriteLine(e.EchangeId);
                Console.WriteLine(e.VenueAdapterId);
                Console.WriteLine(e.Action);
                Console.WriteLine(e.PreviousStatus);
                Console.WriteLine(e.NewStatus);
                Console.WriteLine(e.ExchangeDateTime);
            };

            //Subscribe to SubscribeAccountEvents response.
            cx.OnSubscribeAccountEvents += (sender, e) =>
            {
                Console.WriteLine(e.Result);
                Console.WriteLine(e.ErrorMessage);
                Console.WriteLine(e.ErrorCode);
                Console.WriteLine(e.Detail);
            };

            while (true)
            {
                var command = Console.ReadLine();
                switch (command)
                {
                    case "get products":
                        cx.GetProducts();            
                        break;
                    case "get instruments":
                        cx.GetInstruments();
                        break;
                    case "web authenticate user":
                        Console.Write("web authenticate user > enter username : ");
                        var username = Console.ReadLine();
                        Console.Write("web authenticate user > enter password : ");
                        var password = Console.ReadLine();
                        cx.WebAuthenticateUser(username, products);
                        break;
                    case "get user accounts":
                        cx.GetUserAccounts();
                        break;
                    case "get account transactions":
                        Console.Write("get account transactions > account id : ");
                        int accountId = int.Parse(Console.ReadLine());
                        cx.GetAccountTransactions(accountId, 10);
                        break;
                    case "help":
                    case "/?":
                    default:
                        Console.WriteLine("C# Coins Pro Command Line 0.0.1");
                        Console.WriteLine();
                        Console.WriteLine($"{"help",-25} {"Prints the help."}");
                        Console.WriteLine($"{"/?",-25} {"Prints the help."}");
                        Console.WriteLine($"{"get products",-25} {"Send request to get products."}");
                        Console.WriteLine($"{"get instruments",-25} {"Send request to get instruments."}");
                        Console.WriteLine($"{"web authenticate user",-25} {"Send request to log in to API."}");
                        Console.WriteLine($"{"get user accounts",-25} {"Send request to get user accounts."}");
                        break;
                }
            }
        }
    }
}
