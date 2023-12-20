using System;
namespace Assigment1.Entity
{
	public class Orders
	{
		public int OrderID { set; get; }
		public Customers OCustomers { set; get; }
        public DateTime OrderDate { set; get; }
        public double TotalAmount { set; get; }

        public override string ToString()
        {
            return $"OrderID\t{OrderID}\t Customers\t{OCustomers.Customer_id}\t OrderDate\t{OrderDate}\tTotal Amount\t{TotalAmount}\n";
        }
    }
}

