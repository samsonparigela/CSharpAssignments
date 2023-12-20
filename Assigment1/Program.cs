using Assigment1.Util;
using Assigment1.DAO;
using Microsoft.Data.SqlClient;

namespace Assigment1
{
    public class Program
    {
        private static void Main(string[] args)
        {

            SqlConnection conn = DBConnection.Connect();
            CustomerService cs = new CustomerService();

            #region Menu
            try
            {
                do
                {
                    Console.WriteLine("-----Tech Shop-----");
                    Console.WriteLine("1. Customer Login\n2. Products\n");
                    int choice = int.Parse(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            cs.CustomerLogin(conn);
                            Console.WriteLine("Logged Out Successfully");
                            break;
                        case 2:
                            cs.AdminLogin(conn);
                            Console.WriteLine("Logged Out Successfully");
                            break;
                        case 3:
                        default:
                            break;
                    }
                } while (true);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            #endregion
        }
    }
}