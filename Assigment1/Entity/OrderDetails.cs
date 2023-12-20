using System;
namespace Assigment1.Entity
{
	public class OrderDetails
	{
		public int OrderDetailID { set; get; }
        public Orders OOrders { set; get; }
        public Products OProducts { set; get; }
        public int Quantity { set; get; }
    }
}

