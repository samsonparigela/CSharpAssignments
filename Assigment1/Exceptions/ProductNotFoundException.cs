using System;
namespace Assigment1.Exceptions
{
	public class ProductNotFoundException:Exception
	{
		public ProductNotFoundException(string message)
			:base(message)
		{
		}
	}
}

