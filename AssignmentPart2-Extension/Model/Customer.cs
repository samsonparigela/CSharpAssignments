using System;
using System.Collections.Generic;
using System.Net;
using System.Numerics;
using System.Xml.Linq;

namespace AssignmentPart2
{
	public class Customer
	{
        public int CustomerID { set; get; }
        public string First_Name { set; get; }
        public string LastName { set; get; }
        public string Email { set; get; }
        public string Address { set; get; }
        public string PhoneNumber { set; get; }

        public override string ToString()
        {
            return $"{CustomerID}\t{First_Name}\t{LastName}\t{Email}\t{Address}\t{PhoneNumber}";
        }
    }
}

