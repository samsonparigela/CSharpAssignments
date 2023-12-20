using System;
using AssignmentPart2;

namespace AssignmentPart2_Extension.DAO
{
	public class Bank
	{
		public Bank()
		{
		}

		public void Create_Account(Customer customer,int AccountNumber,string AccountType,float Balance)
		{


            Console.WriteLine("1. Deposit\n2. Withdraw\n3. Interest Calculate");



        }
        public void Deposit(float amount)
        {
            Balance += amount;
            Console.WriteLine("Amount Deposited Successfully");
            Console.WriteLine($"Current Balance is {Balance}");
        }
        public void Withdraw(float amount)
        {
            if (amount > Balance)
            {
                Console.WriteLine("Insufficient Funds");
                return;
            }
            Balance -= amount;
            Console.WriteLine("Amount Withdrawn Successfully");
            Console.WriteLine($"Current Balance is {Balance}");

        }
    }
}

