using System;
using Microsoft.Data.SqlClient;

namespace Assigment1.Util
{

	public class DBConnection
	{
		public static SqlConnection Connect()
		{

			string connectionString = @"Server=localhost;Database=TechShop;User ID=sa;Password=reallyStrongPwd123;TrustServerCertificate=True;";
			SqlConnection conn = new SqlConnection(connectionString);
			conn.Open();
			return conn;

		}
	}
}
