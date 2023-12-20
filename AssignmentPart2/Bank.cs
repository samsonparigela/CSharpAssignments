using System;
namespace AssignmentPart2
{
    public class Bank
    {
        public static void Main()
        {
            Account account = new Account { AccountNumber = 1234, AccountType = "Savings", Balance = 50000 };
            account.Withdraw(12000);
            account.Deposit(2000);
            account.CalculateInterest(5);
            Console.ReadLine();
        }
        

	}
}

