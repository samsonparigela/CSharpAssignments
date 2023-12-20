using System;
namespace AssignmentPart2
{
	public class CurrentAccount:Account
	{
		public CurrentAccount()
		{
		}
        public int OverDraftLimit { set; get; }
        public override void Withdraw(int amount)
        {
            if (amount > OverDraftLimit)
            {
                Console.WriteLine("Crossed Limit");
                return;
            }
            Balance -= amount;
            Console.WriteLine("Amount Withdrawn Successfully");
            Console.WriteLine($"Current Balance is {Balance}");

        }
    }
}

