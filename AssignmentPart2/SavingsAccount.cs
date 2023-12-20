using System;
namespace AssignmentPart2
{
	public class SavingsAccount:Account
	{
		
        public int InterestRate { set; get; }
        public override void CalculateInterest(double numberOfYears)
        {
            double futureBalance = Balance * Math.Pow((1 + (4.5 / 100)), numberOfYears);

            Console.WriteLine($"With Interest of 4.5 for {numberOfYears} years your future balance would be {futureBalance}");
        }

    }
}

