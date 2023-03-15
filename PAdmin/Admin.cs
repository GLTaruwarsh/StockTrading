using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAdmin
{
   public partial class Admin
    {
        

        public void AdminService()
        {
            Console.WriteLine("Enter 1 to Add Stock");
            Console.WriteLine("Enter 2 to Delete Stock");
            Console.WriteLine("Enter 3 to Update Stock");
            Console.WriteLine("Enter 4 to View all Stock");
            Console.WriteLine("Enter 5 to Exit");
            int n = int.Parse(Console.ReadLine());
            switch (n)
            {
                case 1:
                    addStock();
                    break;
                case 2:
                    deletestock();
                    break;
                case 3:
                    updatestock();
                    break;
                case 4:
                    viewstock();
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
