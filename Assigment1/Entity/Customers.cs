using System;
namespace Assigment1.Entity
{
	public class Customers
	{

		public int Customer_id { set; get; }
		public string FirstName { set; get; }
		public string LastName { set; get; }
		public string Email { set; get; }
		public string Phone { set; get; }
		public string Address { set; get; }

        public override string ToString()
        {
			return $"Customer_id::{Customer_id}\tFirstName::{FirstName}\tLastName::{LastName}\tEmail::{Email}\t" +
				$"Phone::{Phone}\tAddress::{Address}";
        }

    }
}

