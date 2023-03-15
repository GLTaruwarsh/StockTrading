using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTrading
{
    public partial class User
    {
        public void UserService()
        {
            Console.WriteLine("Enter 1 to Add Amount to Trade Stocks");
            Console.WriteLine("Enter 2 to List Stock");
            Console.WriteLine("Enter 3 to Buy Stock");
            Console.WriteLine("Enter 4 to Sell Stock");
            Console.WriteLine("Enter 5 to Exit");
            int n = int.Parse(Console.ReadLine());
            switch (n)
            {
                case 1:
                    AddAmount();
                    break;
                case 2:
                    ListStock();
                    break;
                case 3:
                    BuyStock();
                    break;
                case 4:
                    SellStock();
                    break;
                case 5:
                    break;
                default:
                    Console.WriteLine("Enter correct option");
                    break;
            }
        }
    }
}
