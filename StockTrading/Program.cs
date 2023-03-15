using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockTrading;
using PAdmin;
namespace StockTrading
{
    class Program
    {
        
        static void Main(string[] args)
        {

            
            CheckCred cc = new CheckCred();
            Console.WriteLine("Enter 1 to Login as Admin");
            Console.WriteLine("Enter 2 to Login as User");
            int n = int.Parse(Console.ReadLine());

            switch (n)
            {
                case 1:
                    cc.AdmincredInput();
                    break;
                case 2:
                    cc.UsercredInput();
                    break;
                default: Console.WriteLine("Enter correct option"); 
                    break;
            }


           

        }
    }
}
