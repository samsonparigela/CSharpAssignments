using System;
using Assigment1.Entity;
using Assigment1.Exceptions;
using Microsoft.Data.SqlClient;

namespace Assigment1.DAO
{
	public class CustomerService
	{

        #region UpdateCustomer
        public bool UpdateCustomer(SqlConnection conn, Customers customers)
        {
            SqlCommand cmd;
            int t;
            string query;
            do
            {
                Console.WriteLine("Enter what you want to update\n1. First Name\n" +
                    "2. Last Name\n3. Email\n4. Phone\n5. Address\n");
                int choice = int.Parse(Console.ReadLine()), n;

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Enter new First Name");
                        string firstName = Console.ReadLine();
                        query = $"UPDATE CUSTOMERS SET firstName={firstName} WHERE CID={customers.Customer_id}";
                        customers.FirstName = firstName;
                        cmd = new SqlCommand(query, conn);
                        n = cmd.ExecuteNonQuery();
                        break;
                    case 2:
                        Console.WriteLine("Enter new Last Name");
                        string LastName = Console.ReadLine();
                        query = $"UPDATE CUSTOMERS SET lastName={LastName} WHERE CID={customers.Customer_id}";
                        customers.LastName = LastName;
                        cmd = new SqlCommand(query, conn);
                        n = cmd.ExecuteNonQuery();
                        break;
                    case 3:
                        Console.WriteLine("Enter new Email");
                        string Email = Console.ReadLine();
                        query = $"UPDATE CUSTOMERS SET Email={Email} WHERE CID={customers.Customer_id}";
                        customers.Email = Email;
                        cmd = new SqlCommand(query, conn);
                        n = cmd.ExecuteNonQuery();
                        break;

                    case 4:
                        Console.WriteLine("Enter new Phone Number");
                        string Phone = Console.ReadLine();
                        query = $"UPDATE CUSTOMERS SET Phone={Phone} WHERE CID={customers.Customer_id}";
                        customers.Phone=Phone;
                        cmd = new SqlCommand(query, conn);
                        n = cmd.ExecuteNonQuery();
                        break;

                    case 5:
                        Console.WriteLine("Enter new Address");
                        string Address = Console.ReadLine();
                        query = $"UPDATE CUSTOMERS SET Address={Address} WHERE CID={customers.Customer_id}";
                        customers.Address=Address;
                        cmd = new SqlCommand(query, conn);
                        n = cmd.ExecuteNonQuery();
                        break;
                    default:
                        n = 0;
                        Console.WriteLine("Wrong Option! Try Again");
                        break;

                }
                if (n == 1)
                    Console.WriteLine("Successfully Changed");

                Console.WriteLine("Update other attributes ? -1 ;Exit? - 0");
                t = int.Parse(Console.ReadLine());
                if (t == 0)
                    break;
            } while (true);
            return true;

        }
        #endregion

        #region TotalAmount

        public double TotalAmount(SqlConnection conn,Customers customers)
        {

            string query = $"SELECT SUM(TotalAmount) AS SUM FROM ORDERS GROUP BY " +
                $"CID HAVING CID={customers.Customer_id}";
            SqlCommand cmd = new SqlCommand(query,conn);
            SqlDataReader rd = cmd.ExecuteReader();
            if(!rd.HasRows)
            {
                Console.WriteLine("No orders placed");
                return 0;
            }
            rd.Read();
            double sum= (double)rd["SUM"];
            rd.Close();
            return sum;
        }

        #endregion

        #region Update Status
        public bool UpdateStatus(SqlConnection conn,Customers customers)
        {

            string query = $"SELECT OrderID,STATUS FROM ORDERS WHERE CID={customers.Customer_id}";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader rd = cmd.ExecuteReader();
            if (!rd.HasRows)
            {
                Console.WriteLine("No orders placed");
                return false;
            }
            
            while(rd.Read())
            {
                Console.WriteLine($"Your Order Status for OrderID {rd["OrderID"]} is {rd["Status"]}");
            }
            rd.Close();
            do
            {
                Console.WriteLine("Enter the OrderID for which you want to change Status\n");
                int orderID = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter the new Status");
                string status = Console.ReadLine();
                query = $"UPDATE ORDERS SET STATUS={status} WHERE ORDERID={orderID}";
                SqlCommand cmd2 = new SqlCommand(query, conn);
                cmd2.ExecuteNonQuery();
                Console.WriteLine("Successfully Updated status\n0- Exit\n1- Continue");
                int n = int.Parse(Console.ReadLine());
                if (n == 0)
                    break;
            } while (true);

            return true;

        }
        #endregion

        #region GetOrders
        public List<Orders> GetOrders(SqlConnection conn,Customers customers)
        {
            
            List<Orders> ordersList = new List<Orders>();

            string query = $"SELECT * FROM ORDERS WHERE CID={customers.Customer_id}";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader rd= cmd.ExecuteReader();

            while(rd.Read())
            {
                Orders orders = new Orders();
                orders.OrderID = (int)rd["OrderID"];
                orders.OrderDate = (DateTime)rd["OrderDate"];
                orders.TotalAmount = (double)rd["TotalAmount"];
                orders.OCustomers = customers;
                ordersList.Add(orders);
            }
            rd.Close();
            return ordersList;

        }
        #endregion

        #region GetProducts
        public List<Products> GetProducts(SqlConnection conn, Customers customers)
        {
            
            List<Products> productList = new List<Products>();

            string query = $"SELECT * FROM PRODUCTS";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader rd = cmd.ExecuteReader();

            while (rd.Read())
            {
                Products products = new Products();
                products.ProductID = (int)rd["PID"];
                products.ProductName = (string)rd["PName"];
                products.Price =(double)rd["Price"];
                products.Description = (string)rd["Catg"];

                productList.Add(products);
            }
            rd.Close();
            return productList;

        }
        #endregion

        #region CancelOrder
        public void CancelOrder(SqlConnection conn,Customers customers)
        {
            Console.WriteLine("Enter The OrderID you want to delete\n");
            int orderID=int.Parse(Console.ReadLine());

            string query = $"DELETE FROM ORDERS WHERE orderID={orderID}";
            SqlCommand cmd = new SqlCommand(query, conn);
            int n = cmd.ExecuteNonQuery();

            if (n > 0)
                Console.WriteLine("Successfully Deleted\n");

            else
                throw new OrderNotFoundException("NO Order found with the given ID");
                Console.WriteLine("Cannot Delete\n");
        }
        #endregion

        #region ProductQuantity
        public int ProductQuantity(SqlConnection conn,int productID)
        {
            string query = $"SELECT QuantityInStock from Inventory where PID={productID}";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader rd = cmd.ExecuteReader();
            if (!rd.HasRows)
                throw new ProductNotFoundException("NO Product with this ID");
            rd.Read();
            int QuantityInStock= (int)rd["QuantityInStock"];
            rd.Read();
            return QuantityInStock;

        }
        #endregion

        #region AddDiscount
        public float AddDiscount(SqlConnection conn,int orderDiscount,int orderID)
        {
            string query = $"SELECT TotalAmount from orders where orderID={orderID}";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader rd = cmd.ExecuteReader();
            int totalAmount = (int)rd["TotalAmount"];
            float discountedPrice=totalAmount+(totalAmount*orderDiscount)/ 100;
            return discountedPrice;

        }
        #endregion

        #region UpdateQuantity
        public bool UpdateQuantity(SqlConnection conn,int orderID,int quantity)
        {
            string query = $"UDPATE orderDetails SET Quantity={quantity} where OrderID={orderID}";
            SqlCommand cmd = new SqlCommand(query, conn);
            int n = cmd.ExecuteNonQuery();

            if (n <= 0)
                return false;
            return true;

        }
        #endregion

        #region GetInventoryProducts

        public List<Inventory> GetInventoryProducts(SqlConnection conn)
        {
            
            List<Inventory> InventoryList = new List<Inventory>();

            string query = $"SELECT * FROM Inventory;";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader rd = cmd.ExecuteReader();

            while (rd.Read())
            {
                Inventory inventory = new Inventory();
                inventory.InvertoryID = (int)rd["inventoryID"];
                inventory.ProductID = new Products() {ProductID= (int)rd["pid"] };
                inventory.LastStockUpdate = (DateTime)rd["LastStockUpdate"];
                inventory.QuantityInStock = (int)rd["QuantityInStock"];
                InventoryList.Add(inventory);

            }
            rd.Close();
            return InventoryList;

        }

        #endregion

        #region OutOfStockProducts

        public List<Inventory> OutOfStockProducts(SqlConnection conn)
        {
            
            List<Inventory> InventoryList = new List<Inventory>();

            string query = $"SELECT * FROM Inventory where QuantityInStock=0;";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader rd = cmd.ExecuteReader();

            while (rd.Read())
            {
                Inventory inventory = new Inventory();
                inventory.InvertoryID = (int)rd["inventoryID"];
                inventory.ProductID = new Products() { ProductID = (int)rd["productid"] };
                inventory.LastStockUpdate = (DateTime)rd["LastStockUpdate"];
                inventory.QuantityInStock = (int)rd["QuantityInStock"];
                InventoryList.Add(inventory);


            }
            rd.Close();
            return InventoryList;
           
        }

        #endregion

        #region LowStockProducts

        public List<Inventory> LowStockProducts(SqlConnection conn)
        {
            
            List<Inventory> InventoryList = new List<Inventory>();
            Console.WriteLine("Enter the threshold value");
            int threshold=int.Parse(Console.ReadLine());
            string query = $"SELECT * FROM Inventory WHERE QUANTITYINSTOCK>={threshold}";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader rd = cmd.ExecuteReader();

            while (rd.Read())
            {
                Inventory inventory = new Inventory();
                inventory.InvertoryID = (int)rd["inventoryID"];
                inventory.ProductID = new Products() { ProductID = (int)rd["pid"] };
                inventory.LastStockUpdate = (DateTime)rd["LastStockUpdate"];
                inventory.QuantityInStock = (int)rd["QuantityInStock"];
                InventoryList.Add(inventory);

            }
            rd.Close();
            return InventoryList;

        }

        #endregion

        #region GetAmountforInventoryProducts

        public void TotalProductsAmount(SqlConnection conn)
        {
            Inventory inventory = new Inventory();
            List<Inventory> InventoryList = new List<Inventory>();

            string query = "SELECT i.pid, SUM(p.price* i.quantityinstock) AS total_value " +
                "FROM products p JOIN inventory i ON p.pid = i.pid group by i.pid;";

            
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader rd = cmd.ExecuteReader();

            while (rd.Read())
            {
                Console.WriteLine((int)rd["PID"]);
                Console.WriteLine((double)rd["total_value"]);
                Console.WriteLine("\n");

            }
            rd.Close();
        }

        #endregion

        #region AddtoInventory
        public bool AddtoInventory(SqlConnection conn,Inventory inventory)
        {
            string query;

            query = "INSERT INTO INVENTORY VALUES(@InventoryID,@PID,@QuantityInStock,@LastStockUpdate)";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@InventoryID", inventory.InvertoryID);
            cmd.Parameters.AddWithValue("@LastStockUpdate", inventory.LastStockUpdate);
            cmd.Parameters.AddWithValue("@QuantityInStock", inventory.QuantityInStock);
            cmd.Parameters.AddWithValue("@PID", inventory.ProductID);

            int n = cmd.ExecuteNonQuery();
            if (n == 1)
            {
                return true;
            }
            return false;

        }
        #endregion

        #region RemoveFromInventory
        public bool RemoveFromInventory(SqlConnection conn)
        {

            string query;
            Console.WriteLine("Enter The InventoryID to remove\n");
            int inventoryID=int.Parse(Console.ReadLine());
            query = $"Delete From INVENTORY Where InventoryId={inventoryID}";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd = new SqlCommand(query, conn);

            int n = cmd.ExecuteNonQuery();
            if (n == 1)
            {
                return true;
            }
            return false;


        }
        #endregion

        #region Login
        public bool CustomerLogin(SqlConnection conn)
		{
 
			Customers customers = new Customers();
            List<Products> productList = new List<Products>();
            List<Orders> orderList = new List<Orders>();
            bool res;

			Console.WriteLine("Enter the customer ID");
            customers.Customer_id=int.Parse(Console.ReadLine());

            Console.WriteLine("Enter your first name");
			customers.FirstName=Console.ReadLine();
                

			string query = $"SELECT * FROM CUSTOMERS WHERE CID={customers.Customer_id}";
			SqlCommand cmd = new SqlCommand(query, conn);
			SqlDataReader rd = cmd.ExecuteReader();

			if (!rd.HasRows)
				throw new CustomerNotFoundException("No Customer found with the given ID");
			Console.WriteLine("\nSuccessfully Logged in\n");
			while (rd.Read())
			{
				customers.LastName = (string)rd["LastName"];
				customers.Phone = (string)rd["phone"];
				customers.Email = (string)rd["Email"];
				customers.Address = (string)rd["Address"];
				
			}
            rd.Close();
            
            trail1:
            Console.WriteLine("\n1. Customer Details\n2. Number of Orders Placed\n3. Update Customer Info" +
                "\n4. Total Amount for all orders\n5. Get Order Details\n6. Update order Status\n7. Cancel Order" +
                "\n8. Get Products\n9. Get Product Quantity\n10. Update Order Quantity\n11. Logout\n");
            int ch = int.Parse(Console.ReadLine());
            switch (ch)
			{
				case 1:
					Console.WriteLine(customers);
                    goto trail1;
                case 2:
                    query = $"SELECT count(cid) as count FROM ORDERS group by " +
						$"cid having CID={customers.Customer_id}";
					SqlCommand cmd1 = new SqlCommand(query, conn);
					rd = cmd1.ExecuteReader();
					if(!rd.HasRows)
						Console.WriteLine("No Orders placed\n");
					while(rd.Read())
					Console.WriteLine($"\nNo of orders placed are {rd["count"]}\n");
                    rd.Close();
                    goto trail1;

                case 3:
                    res=UpdateCustomer(conn, customers);
                    if(res==true)
                        Console.WriteLine("Successfully Updated");
                    else
                        Console.WriteLine("Cannot Update");
                    goto trail1;
                case 4:
                    double price=TotalAmount(conn,customers);
                    Console.WriteLine($"Total amount for all orders placed by you is  {price} Rupees");
                    goto trail1;
                case 5:
                    orderList = GetOrders(conn,customers);
                    foreach(Orders order in orderList)
                        Console.WriteLine(order);
                    goto trail1;
                case 6:
                    res=UpdateStatus(conn, customers);
                    if (res == true)
                        Console.WriteLine("Successfully Updated");
                    else
                        Console.WriteLine("Cannot Update");
                    goto trail1;
                case 7:
                    CancelOrder(conn, customers);
                    goto trail1;
                case 8:
                    productList=GetProducts(conn, customers);
                    foreach(Products products in productList)
                        Console.WriteLine(products);
                    goto trail1;
                case 9:
                    Console.WriteLine("Enter the productID of quantiy\n");
                    int productID = int.Parse(Console.ReadLine());
                    int quantity = ProductQuantity(conn, productID);
                    Console.WriteLine($"The Quantiy of Product with ID {productID} is {quantity}\n");
                    goto trail1;
                case 10:
                    Console.WriteLine("Enter the OrderID you want to update\n");
                    int orderID = int.Parse(Console.ReadLine());

                    Console.WriteLine("Enter the new Quantity");
                    int newQuantity= int.Parse(Console.ReadLine());

                    UpdateQuantity(conn,orderID, newQuantity);

                    goto trail1;
                case 11:
                    int orderDiscount = 10;
                    Console.WriteLine("Enter OrderID");
                    int orderId = int.Parse(Console.ReadLine());
                    AddDiscount(conn, orderDiscount, orderId);
                    goto trail1;
                case 12:
                    Console.WriteLine("Logging Out..");
                    goto trail1;
                default:
                    Console.WriteLine("Wrong Choice! Try Again");
					break;
			}

			return false;
		}
        #endregion

        #region AdminLogin
        public bool AdminLogin(SqlConnection conn)
        {
            List<Inventory> inventoryList = new List<Inventory>();

            trail1:
            Console.WriteLine("1. Get Inventory Products\n2. Out of Stock Products\n" +
                "3. Low Stock Products\n4. Get Amount for Inventory Products\n5. Add to Inventory\n" +
                "6. Remove from Inventory\n7. Logout\n");

            int choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    inventoryList=GetInventoryProducts(conn);
                    foreach(Inventory inventory1 in inventoryList)
                        Console.WriteLine(inventory1);
                    goto trail1;
                case 2:
                    inventoryList=OutOfStockProducts(conn);
                    foreach (Inventory inventory1 in inventoryList)
                        Console.WriteLine(inventory1);
                    goto trail1;
                case 3:
                    inventoryList=LowStockProducts(conn);
                    foreach (Inventory inventory1 in inventoryList)
                        Console.WriteLine(inventory1);
                    goto trail1;
                case 4:
                    TotalProductsAmount(conn);
                    goto trail1;
                case 5:
                    Inventory inventory = new Inventory();

                    Console.WriteLine("Enter InventoryID\n");
                    inventory.InvertoryID = int.Parse(Console.ReadLine());

                    Console.WriteLine("Enter the productID\n");
                    inventory.ProductID = new Products { ProductID = int.Parse(Console.ReadLine()) };

                    Console.WriteLine("Quantity In Stock\n");
                    inventory.QuantityInStock= int.Parse(Console.ReadLine());

                    Console.WriteLine("Last stock update\n");
                    inventory.LastStockUpdate = new DateTime(2023, 10, 12);

                    AddtoInventory(conn,inventory);
                    goto trail1;
                case 6:
                    RemoveFromInventory(conn);
                    goto trail1;
                case 7:
                    Console.WriteLine("Logging Out\n");
                    break;
            }

            return false;
        }
        #endregion

    }
}

