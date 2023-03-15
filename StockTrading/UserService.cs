using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTrading
{
    public partial class User
    {
        UserInput ui = new UserInput();
        SqlConnection con = new SqlConnection("server=DEL1-LHP-N70010; database=Stock; integrated security = true");

        public void AddAmount()
        {
            Console.WriteLine("Enter Amount to Treade with");
            ui.amount = double.Parse(Console.ReadLine());
            SqlCommand cmd = new SqlCommand("update Userdetails set amount=" + ui.amount + "", con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            Console.Clear();
            Console.WriteLine("Amount Added Succesfully");
            UserService();
            Console.ReadKey();
        }

        public void ListStock()
        {

            SqlDataAdapter da = new SqlDataAdapter("select * from stockdetails", con);
            DataTable ds = new DataTable();
            da.Fill(ds);
            Console.Clear();
            foreach (DataRow rows in ds.Rows)
            {
                foreach (var o in rows.ItemArray)
                {
                    Console.Write(o + "\t\t");

                }
                Console.WriteLine();
            }
            Console.WriteLine("--------------------------------------");
            UserService();
            Console.ReadKey();
        }

        public void BuyStock()
        {
            double total;
            Console.WriteLine("Enter Stock Id  to Buy");
            ui.stockid = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Quantity to Buy");
            int Buyquant = int.Parse(Console.ReadLine());
            SqlDataAdapter da = new SqlDataAdapter("select * from stockdetails", con);
            DataSet ds = new DataSet();
            da.Fill(ds, "stockdetails");

            int c = ds.Tables[0].Rows.Count;
            
            for (int i = 0; i < c; i++)
            {
                if (ui.stockid == int.Parse(ds.Tables[0].Rows[i][6].ToString()))
                {
                    ui.company = ds.Tables[0].Rows[i][0].ToString();
                    ui.stockName = ds.Tables[0].Rows[i][1].ToString();
                    ui.quantity = int.Parse(ds.Tables[0].Rows[i][2].ToString());
                    ui.price = double.Parse(ds.Tables[0].Rows[i][3].ToString());
                    ui.fees= double.Parse(ds.Tables[0].Rows[i][5].ToString());
                    if (Buyquant>ui.quantity)
                    {
                        Console.WriteLine("Required Qunatity not Available");
                        UserService();
                    }
                    else
                    {
                        total=ui.quantity * ui.price;
                        ui.amount = total * ui.fees;

                        SqlCommand cmd = new SqlCommand("update stockdetails set Quantity= " + (ui.quantity - Buyquant) + " where StockID=" + ui.stockid + "", con);
                        
                        con.Open();
                        cmd.ExecuteNonQuery();
                        
                        con.Close();
                        Console.Clear();
                        Console.WriteLine("Stock Purchased Succesfully Taotal amount :" + ui.amount);
                        UserService();
                    }
                    Console.ReadKey();
                }

            }
        }



        public void SellStock()
        {

        }

       
    }
}
    

