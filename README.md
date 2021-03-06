# NOTICE: This repository is depricated and no longer maintained.
There have been updates to the API specifications which were not implemented in this project and not recommended for usage.

# csharp-cx-lib
C# Coins Pro API Library

## Getting Started
Do more with your trades. Download the API documentation [here](https://exchange.coins.asia/assets/docs/Coins-Pro-API.pdf).

You can create API keys directly from your Coins Pro account. Just click the API KEYS option on the side menu.
[https://pro.coins.asia/](https://pro.coins.asia/)

## Installation
Build from source and add reference to your project or use NuGet Package Manager.
```
 PM> Install-Package csharp-cx-lib -Version 1.0.0-pre 
```

## Usage
Require namespace.

```csharp
using CXlib;
```

Create an instance of CX.

```csharp
CX cx = new CX(CX.Production);
```

|Environment   |URL                                          |
|--------------|---------------------------------------------|
|CX.Production |wss://api-cx.coins.asia/ws-api/              |
|CX.Staging    |wss://api-cx.staging.coins.technology/ws-api/|


Subscribe to response or events.

```csharp
cx.OnGetProducts += (sender, e) => {
  //Do something with e.Products
}
```

Send request.


```csharp
cx.GetProducts();
```

|Response/Event          |Description                                                                                                                                                                  | 
|------------------------|-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
|OnGetProducts           |Returns a list of available **Products** from the API.                                                                                                                       |
|OnGetInstruments        |Returns a list of available **Instruments** from the API.                                                                                                                    |
|OnWebAuthenticateUer    |Returns if session is **Authenticated**, **SessionToken**, **UserId**, and **ErrorMessage**.                                                                                                   |
|OnGetUserAccounts       |Returns a list of **AccountIds** for the current user.                                                                                                                          |
|OnGetAccountTransactions|Retruns a list of recent **Transactions** from your account.                                                                                                                 |
|OnGetAccountPositions   |Returns a list of account **Positions**(Balances) on a specific account.                                                                                                      |
|OnGetAccountTrades      |Retruns a list of account **Trades** history for a specific account.                                                                                                           |
|OnSendOrder             |Retruns **Status**, **ErrorMessage**, and **OrderId**.                                                                                                                      |
|OnCancelOrder           |Returns **Status**, **ErrorMessage**, **ErrorCode**, and **Detail**.                                                                                                         |
|OnGetOrderStatus        |Reutrns the **OrderStatus**(current operating status of an order) submitted to Order Management System.                                                                      |
|OnGetOrderFee           |Returns the estimate of the **OrderFee** and **ProductId** for a specific order and order type.                                                                              |
|OnGetOrderHistory       |Returns the list of of the last 100 **Orders** placed on your account.                                                                                                       |
|OnGetOpenOrders         |Returns the list of Open **Orders** for specified account of current user.                                                                                                   |
|OnCreateWithdrawTicket  |Returns **Result**, **ErrorMessage**, and **ErrorCode**.                                                                                                                     |
|OnSubscribeLevel1       |Returns **MarketData**.                                                                                                                                                |
|OnLevel1UpdateEvent     |Returns **MarketData**.                                                                                                                                                |
|OnUnsubscribeLevel1     |Returns **Result**, **ErrorMessage**, **ErrorCode**, and **Detail**.                                                                                                         |
|OnSubscribeLevel2       |Returns list of **MarketData**.                                                                                                                                        |
|OnLevel2UpdateEvent     |Returns list of **MarketData**.                                                                                                                                        |
|OnUnsubscribeLevel2     |Returns **Result**, **ErrorMessage**, **ErrorCode**, and **Detail**.                                                                                                         |
|OnSubscribeTrades       |Returns list of the latest public **MarketTrades** for the specific instrument.                                                                                              |
|OnTradeDataUpdateEvent  |Returns list of the latest public **MarketTrades** for the specific instrument.                                                                                              |
|OnUnsubscribeTrades     |Returns **Result**, **ErrorMessage**, **ErrorCode**, and **Detail**.                                                                                                         |
|OnSubscribeAccountEvents|Returns **Result**.                                                                                                                                                          |
|PendingDepositUpdate    |Returns **AccountId**, **AssetId**, **TotalPendingDepositValue**.                                                                                                            |
|AccountPositionEvent    |Returns account **Position** any time the balance of your account changes.                                                                                                    |
|OrderStateEvent         |Returns **OrderStatus** events any time the status of an order on your account changes.                                                                                      |
|OrderTradeEvent         |Returns account **Trade** any time one of your orders results in a trade.                                                                                                     |
|NewOrderRejectEvent     |Returns **AccountId**, **ClientOrderId**, **Status**, and **RejectReason** if your order is rejected.                                                                        |
|CancelOrderRejectEvent  |Returns **AccountId**, **OrderId**,  **OrderRevision**, **OrderType**, **InstrumentId**, **Status**, and **RejectReason** if your attempt to cancel an order is unsuccessful.|
|MarketStateUpdate       |Returns **ExchangeId**, **VenueAdapterId**, **VenueInstrumentId**, **Action**, **PreviousStatus**, **NewStatus**, and **ExchangeDateTime**.                                  |


|Request(*Italic* parameters are optional.)                                                       |Details                                                                                                 | 
|-------------------------------------------------------------------------------------------------|--------------------------------------------------------------------------------------------------------|
|GetProdcuts(*sequenceNumber*)                                                                    |Sends a request to get available products from the API.                                                 |
|GetInstruments(*sequenceNumber*)                                                                 |Sends a request to get available instruments from the API.                                              |
|WebAuthenticateUser(username, password, *sequenceNumber*)                                        |Sends a request to authenticate.                                                                        |
|GetUserAccounts(*sequenceNumber*)                                                                |Sends a request to get user accounts.                                                                   |
|GetAccountTransactions(accountId, *sequenceNumber*)                                              |Sends a request to get transaction from your account.                                                   | 
|GetAccountPositions(accountId, *sequenceNumber*)                                                 |Sends a request to get account positions(balance) on a specific account.                                |
|GetAccountTrades(accountId, *sequenceNumber*)                                                    |Sends a request to get account trades for a specific account.                                           |
|SendOrder(*sequenceNumber*)                                                                      |Sends a new order into the API.                                                                         |
|CancelOrder(accountId, clientOrderId, orderId, *sequnceNumber*)                                  |Sends a request to cancel an open order.                                                                |  
|GetOrderStatus(accountId, orderId, *sequenceNumber*)                                             |Sends a request get the current operating status of an order.                                           |
|GetOrderFee(accountId, instrumentId, productId, amount, orderType, makerTaker, *sequenceNumber*) |Sends a request to get the estimate of the fee for a specific order and order type.                     |
|GetOrderHistory(accountId, *sequenceNumber*)                                                     |Sends a request to get the list of orders placed on your account.                                       |
|GetOpenOrders(accountId, *sequenceNumber*)                                                       |Sends a request to get the list of Open Orders for specified account of current user.                   |
|CreateWithdrawTicket(productId, accountId, amount *sequenceNumber*)                            |Sends a request to creates a withdrawal ticket to send funds from Coins Pro to the user’s Coins wallet. |                            |
|SubscribeLevel1(instrumentId, *sequenceNumber*)                                                  |Sends a request to subscribe to level 1 market data.                                                    |
|UnsubscribeLevel1(instrumentId, *sequenceNumber*)                                                |Sends a request to unsubscribe to level 1 market data.                                                  |
|SubscribeLevel2(instrumentId, depth, *sequenceNumber*)                                           |Sends a request to subscribe to level 2 market data.                                                    |
|UnsubscribeLevel2(instrumentId, *sequenceNumber*)                                                |Sends a request to unsubscribe to level 2 market data.                                                  |
|SubscribeTrades(instrumentId, includeLastCount, *sequenceNumber*)                                |Sends a request to subscribe to market trades.                                                          |
|UnsubscribeTrades(instrumentId, *sequenceNumber*)                                                |Sends a request to unsubscribe to market trades.                                                        |
|SubscribeAccountEvents(accountId, *sequenceNumber*)                                              |Sends request to account-level events, such as orders, trades, deposits and withdraws.                  |


## Examples

```csharp
using CXlib;

namespace ConsoleApp1
{
 	class Program
	{
		static void Main(string[] args)
		{
			CX cx = new CX(CX.Production); //Create and instance of CX
			
			//Subscribe to response
			cx.OnGetProducts += (sender, e) => {
				//Handle e.Products
			     	foreach (Product product in e.Products)
			      		Console.WriteLine(
			       			$"{product.ProductId, -2} " +
			       			$"{product.Symbol, -4} " +
			       			$"{product.ProductFullName, -20} " +
			       			$"{product.ProductType, -20} " +
			       			$"{product.DecimalPlaces, -2}"
			      		);
			};

			//Send request
			cx.GetProducts();
		}
	}
}
```
