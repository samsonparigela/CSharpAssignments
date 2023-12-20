using System;
namespace Assignment.OOPS
{
	public class Customer
	{

        private int customerID, phoneNumber;
        private string first_name, last_name, email, address1; 
        public Customer(int cid,int phone,string fname,string lname,string address)
		{
			customerID = cid;
			phoneNumber = phone;
			first_name = fname;
			last_name = lname;
			address1 = address;
		}

		
	}
}

