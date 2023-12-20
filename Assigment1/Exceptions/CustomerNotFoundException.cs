using System;
namespace Assigment1.Exceptions
{
	public class CustomerNotFoundException:Exception
	{
		public CustomerNotFoundException(string message)
			:base(message)
		{
		}
	}
}

