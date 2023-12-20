
namespace AssignmentPart1;
internal class Program
{
    private static void Main(string[] args)
    {
        
        Tasks tasks = new Tasks();

        #region Task 1
        //Task 1
        int creditScore = int.Parse(Console.ReadLine());
        int annualIncome = int.Parse(Console.ReadLine());
        bool x = tasks.checkLoanEligibility(creditScore, annualIncome);
        if (x == true)
        {
            Console.WriteLine("Great ! You are eligible for loan");
        }
        else
        {
            Console.WriteLine("Sorry, You are not eligible for loan");
        }
        Console.ReadLine();
        #endregion

        #region Task 2
        // Task 2
        tasks.ATMSimulation();
        #endregion

        #region Task 3
        //Task 3
        tasks.calculateInterest();
        #endregion

        #region Task 4
        tasks.checkBalance();
        #endregion

        #region Task 5
        tasks.passwordValidation();
        #endregion

        #region Task 6
        tasks.transactionsList();
        tasks.transactionsList();
        #endregion


    }
}