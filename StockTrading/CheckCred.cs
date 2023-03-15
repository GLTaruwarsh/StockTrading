using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PAdmin;
namespace StockTrading
{
    
    public class CheckCred
    {
        Admin ad = new Admin();
        User ur = new User();
        public int count = 0,i;
        public int Admin;
        public int User;

        public void AdmincredInput()
        {
            Admin=1;
            Console.WriteLine("Enter Admin Name");
            string name = Console.ReadLine();
            Console.WriteLine("Ennter Admin Password");
            string password = Console.ReadLine();
            CredChek(name, password, Admin);
        }


        public void UsercredInput()
        {
            User = 2;
            Console.WriteLine("Enter User Name");
            string name = Console.ReadLine();
            Console.WriteLine("Ennter User Password");
            string password = Console.ReadLine();
            CredChek(name, password, User);
        }

        
        public void CredChek(string name,string password, int C)
        {
            SqlConnection con = new SqlConnection("server=DEL1-LHP-N70010; database=Stock; integrated security = true");
            SqlDataAdapter da = new SqlDataAdapter("select * from Credentiatls", con);
            DataSet ds = new DataSet();
            da.Fill(ds, "Credentiatls");
            int c = ds.Tables[0].Rows.Count;
            
            for (i=count; i < c; i++)
            {
                if (name == ds.Tables[0].Rows[i][0].ToString() && password == ds.Tables[0].Rows[i][1].ToString())
                {

                    Console.WriteLine("Successfully Logedd IN");
                    Console.WriteLine("------------------------------------");
                    if (C == 1)
                    {
                        ad.AdminService();
                    }
                    else
                    {
                        ur.UserService();
                    }
                }
                
                else if(count<2)
                {

                    Console.WriteLine("LogIn Failed Try Again");
                    Console.WriteLine("-------------------------------------");
                    count = count + 1;
                    if (C == 1)
                    {
                        AdmincredInput();
                    }
                    else
                    {
                        UsercredInput();
                    }
                    
                }
                else
                    {
                    Console.WriteLine("------------------------------------");
                    Console.WriteLine("Try after Sometime");
                    Console.ReadKey();
                    }
                }
            }
        
            
        }
    }

