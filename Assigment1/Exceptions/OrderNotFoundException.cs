using System;
namespace Assigment1.Exceptions
{
	public class OrderNotFoundException:Exception
	{
		public OrderNotFoundException(string message)
			:base(message)
		{
		}
	}
}

