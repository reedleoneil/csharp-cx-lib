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
            CX cx = new CX(CX.Production);
            cx.OnGetProducts += (sender, e) => {
                Console.WriteLine(e.SequenceNumber);
                foreach (Product product in e.Products)
                    Console.WriteLine(product.ProductFullName);
            };
            while (true)
            {

                string input = Console.ReadLine();
                switch (input)
                {
                    case "get products":
                        cx.GetProducts();
                        break;
                    case "get instruments":
                        cx.GetInstruments();
                        break;
                    case "web authenticate user":
                        cx.WebAuthenticateUser("user1", "password");
                        break;
                    case "get user accounts":
                        cx.GetUserAccounts();
                        break;
                    case "get account transactions":
                        cx.GetAccountTransactions(1, 200);
                        break;
                    case "get account positions":
                        cx.GetAccountPositions(1);
                        break;
                    case "get account trades":
                        cx.GetAccountTrades(1, 20, 0);
                        break;
                    case "send order":
                        //cx.SendOrder();
                        break;
                    default:
                        Console.WriteLine("Error: command not found.");
                        break;
                }
            }
        }

  
    }
}
