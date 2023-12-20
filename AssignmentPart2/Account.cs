using System;
namespace AssignmentPart2
{
	public class Account
	{
		public int AccountNumber { set; get; }
        public string AccountType { set; get; }
        public float Balance { set; get; }

        public override string ToString()
        {
            return $"{AccountNumber}\t{AccountType}\t{Balance}";
        }
        public void Deposit(float amount)
        {
            Balance += amount;
            Console.WriteLine("Amount Deposited Successfully");
            Console.WriteLine($"Current Balance is {Balance}");
        }
        public void Deposit(int amount)
        {
            Balance += amount;
            Console.WriteLine("Amount Deposited Successfully");
            Console.WriteLine($"Current Balance is {Balance}");
        }
        public void Withdraw(float amount)
        {
            if(amount>Balance)
            {
                Console.WriteLine("Insufficient Funds");
                return;
            }
            Balance -= amount;
            Console.WriteLine("Amount Withdrawn Successfully");
            Console.WriteLine($"Current Balance is {Balance}");

        }
        public virtual void Withdraw(int amount)
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
        public virtual void CalculateInterest(double numberOfYears)
        {
         
            double futureBalance = Balance * Math.Pow((1 + (4.5 / 100)), numberOfYears);

            Console.WriteLine($"With Interest of 4.5 for {numberOfYears} " +
                $"years your future balance would be {futureBalance}");
        }
    }
}

