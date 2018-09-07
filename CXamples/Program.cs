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

            cx.OnGetInstruments += (sender, e) =>
            {
                Console.WriteLine(e.SequenceNumber);
                foreach (Instrument instrument in e.Instruments)
                    Console.WriteLine(instrument.Symbol);
            };

            cx.OnWebAuthenticateUser += (sender, e) =>
            {
                Console.WriteLine($"{e.Authenticated} {e.SessionToken} {e.UserId} {e.ErrorMessage}");
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
                        cx.WebAuthenticateUser("username", "password");
                        break;
                    case "get user accounts":
                        cx.GetUserAccounts();
                        break;
                    case "get account transactions":
                        cx.GetAccountTransactions(int.Parse(Console.ReadLine()), 200);
                        break;
                    case "get account positions":
                        cx.GetAccountPositions(int.Parse(Console.ReadLine()));
                        break;
                    case "get account trades":
                        cx.GetAccountTrades(int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine()));
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
