using System;
namespace Assigment1.Entity
{
	public class Products
	{
		public int ProductID { set; get; }
		public string ProductName { set; get; }
		public string Description { set; get; }
        public double Price { set; get; }

        public override string ToString()
        {
            return $"{ProductID}\t{ProductName}\t{Description}\t{Price}\t";
        }

    }
}

