using System;
namespace Assigment1.Entity
{
	public class Inventory
	{
		public int InvertoryID { set; get; }
        public Products ProductID { set; get; }
        public int QuantityInStock { set; get; }
        public DateTime LastStockUpdate { set; get; }

        public override string ToString()
        {
            return $"{InvertoryID}\t{ProductID.ProductID}\t{QuantityInStock}\t{LastStockUpdate}\t";
        }
    }
}

