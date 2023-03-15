using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAdmin
{
    public partial class Admin
    {
        StockData sd = new StockData();
        SqlConnection con = new SqlConnection("server=DEL1-LHP-N70010; database=Stock; integrated security = true");
        public void addStock()
        {
            Console.WriteLine("Enter Stock Details");
            Console.WriteLine("Enter Company Name");
            sd.CompName = Console.ReadLine();
            Console.WriteLine("Enter Stock Name");
            sd.StockName = Console.ReadLine();
            Console.WriteLine("Enter Stock Quantity");
            sd.StockQuantity = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Stock Buy Price");
            sd.BuyPr = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Stock Sell Price");
            sd.SellPr = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter Trading Fees in Percentage");
            sd.TradeFees = double.Parse(Console.ReadLine());

            SqlCommand cmd = new SqlCommand("insert into stockdetails values(' " + sd.CompName + " ',' " + sd.StockName + " '," + sd.StockQuantity + ", " + sd.BuyPr + "," + sd.SellPr + "," + sd.TradeFees + ")", con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            Console.Clear();
            Console.WriteLine("New Stock Added");
            Console.WriteLine("------------------------------------");
            AdminService();
            Console.ReadLine();
        }
        public void deletestock()
        {
            Console.WriteLine("Enter Stock Name to be deleted");
            sd.StockName = Console.ReadLine();

            SqlCommand cmd = new SqlCommand("delete from stockdetails where Stock =' " + sd.StockName + " '", con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            Console.Clear();
            Console.WriteLine("The Stock is deleted");
            Console.WriteLine("------------------------------------");
            AdminService();
            Console.ReadKey();

        }

        public void updatestock()
        {
            Console.WriteLine("Enter Student  Stock name to be updated");
            string stk = Console.ReadLine();

            Console.WriteLine("Enter Company Name");
            sd.CompName = Console.ReadLine();
            Console.WriteLine("Enter Stock Name");
            sd.StockName = Console.ReadLine();
            Console.WriteLine("Enter Stock Quantity");
            sd.StockQuantity = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Stock Buy Price");
            sd.BuyPr = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Stock Sell Price");
            sd.SellPr = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter Trading Fees in Percentage");
            sd.TradeFees = double.Parse(Console.ReadLine());
            SqlCommand cmd = new SqlCommand("update stockdetails set Company=' " + sd.CompName + " ',Stock =' " + sd.StockName + " ',Quantity=" + sd.StockQuantity + ",BuyPrice= " + sd.BuyPr + ",SellPrice=" + sd.SellPr + ",TradingFee=" + sd.TradeFees + " where Stock=' " + stk + " ' ", con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            Console.Clear();
            Console.WriteLine("Stock Updated Succesfully");
            AdminService();
            Console.ReadKey();
        }

        public void viewstock()
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from stockdetails", con);
            DataTable ds = new DataTable();
            da.Fill(ds);
            Console.Clear();
            foreach (DataRow rows in ds.Rows)
            {
                foreach (var o in rows.ItemArray)
                {
                    Console.Write(o + "      \t");
                }
                Console.WriteLine();

            }
            Console.WriteLine("--------------------------------------");
            AdminService();
            Console.ReadKey();


        }

    }
}
