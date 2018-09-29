# csharp-cx-lib
C# Coins Pro API Library

## Getting Started
You may download the Coins Pro API documentation [here](https://s3-ap-northeast-1.amazonaws.com/coins-staging-static-uploads/uploads/files/Coins+Pro+API.pdf). Access to the API is available only for customers who have a Coins Pro account.  

For the authentication credentials, please email coinspro.support@coins.ph using the email you're using for Coins Pro together with your **PGP Public Key**. This way, they can provide the API credentials in a secure manner.

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

|Response/Event      |Description                                                   | 
|----------------------|-----------------------------------------------------|
|OnGetProducts         |Returns a list of available **Products** from the API.   |
|OnGetInstruments      |Returns a list of available **Instruments** from the API.|
|OnWebAuthenticateUer  |Returns if session is **Authenticated**, **SessionToken**, and **UserId**|
|OnGetUserAccounts     |Returns a list of account IDs for the current user.|
|GetAccountTransactions|Retruns a list of recent **Transactions** from your account.|
|GetAccountPositions   |Returns a list of **Positions**(Balances) on a specific account.|
|GetAccountTrades      |Retruns a list of **AccoutTrade** history on a specific account. |

Send request.

```csharp
cx.GetProducts();
```
