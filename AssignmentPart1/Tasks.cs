using System;
namespace AssignmentPart1
{
	public class Tasks
	{
		public Tasks()
		{
			Console.WriteLine("Assignment 3 Questions");
			Console.WriteLine(" ");
		}
        #region task1
        public bool checkLoanEligibility(int creditScore,int annualIncome)
		{
			if (creditScore > 700 && annualIncome >= 50000)
				return true;
			return false;
		}
		#endregion

		#region task 2
		public void ATMSimulation()
		{
            int balance = 10000;
			int choice;
			do
			{
                start:
				Console.WriteLine("Choose your choice");
				Console.WriteLine("1. Check Balance\n2. Withdraw\n3. Deposit\n4. Exit");
				choice = int.Parse(Console.ReadLine());
				switch(choice)
				{
					case 1:
						Console.WriteLine($"Your balance is {balance}");
						break;

					case 2:
						Console.WriteLine("Enter the amount you wish to withdraw");
						int withdrawalAmount= int.Parse(Console.ReadLine());
						if (balance - withdrawalAmount < 0)
						{
							Console.WriteLine("Insuffient funds to withdraw !");
							goto start;
						}
						else
						{
                            balance -= withdrawalAmount;
                            Console.WriteLine($"Amount of {withdrawalAmount} Withdrawn Successfully !");
                        }
                        break;

					case 3:
                        Console.WriteLine("Enter the amount you wish to deposit");
                        int depositAmount = int.Parse(Console.ReadLine());
						balance += depositAmount;
						Console.WriteLine($"Amount of {depositAmount} deposited Successfully !");
						break;

					case 4:
						Console.WriteLine("Thank you! See you again");
						break;

					default:
						Console.WriteLine("Wrong Choice! Choose again!");
						goto start;
                }

			} while (choice != 4);
            
            
        }
        #endregion

        #region task 3
		public void calculateInterest()
		{
			Console.WriteLine("Enter the number of Customers who wish to check the interest");
			int num= int.Parse(Console.ReadLine());
			for(int i=0;i<num;i++)
			{
				double balance, annualInterestRate,numberOfYears;
				Console.WriteLine("Enter your current bank balance");
                balance = double.Parse(Console.ReadLine());

				Console.WriteLine("Enter the annual interest Rate");
                annualInterestRate = double.Parse(Console.ReadLine());

				Console.WriteLine("Enter the number of years");
                numberOfYears = double.Parse(Console.ReadLine());
				double futureBalance = balance * Math.Pow((1 + (annualInterestRate / 100)), numberOfYears);
				Console.WriteLine($"Your future balance would be {futureBalance}");
            }
            

        }
        #endregion

        #region task 4
        public void checkBalance()
		{
			Accounts[] accounts1 =new Accounts[3];

            Accounts a1 = new Accounts();
			a1.accountNumber = 11111;
			a1.balance = 10000;
			accounts1[0] = a1;

            Accounts a2 = new Accounts();
            a2.accountNumber = 22222;
            a2.balance = 20000;
            accounts1[1] = a2;

            Accounts a3 = new Accounts();
            a3.accountNumber = 33333;
            a3.balance = 30000;
            accounts1[2] = a3;

			for(int i=0;i<3;i++)
			{
				trail:
				int flag = 0;
				Console.WriteLine("Enter Account Number");
				int accountNumber = int.Parse(Console.ReadLine());
				foreach(Accounts x in accounts1)
				{
					if(x.accountNumber==accountNumber)
					{
						Console.WriteLine($"Your Balance is {x.balance}");
						flag = 1;
					}
				}
				if(flag==0)
				{
                    Console.WriteLine("Incorrect account Number ! Try Again");
					goto trail;
                }
			}
		}
        #endregion

        #region task 5
        //task 5

        public void passwordValidation()
        {
			

			trail2:
            int c1 = 0;
            int c2 = 0;
            int c3 = 0;
            Console.WriteLine("Enter your new password");
			string password = Console.ReadLine();

            if (password.Length < 8)
            {
                c1 = 1;
            }

            for (int i=0;i<password.Length;i++)
			{
				
				if(password[i]>=65 && password[i]<=90)
				{
					c2 = 1;
				}
				if (password[i]>=48 && password[i]<=57)
				{
					c3 = 1;
				}
			}
			if(c1==0 && c2==1 && c3==1)
			{
				Console.WriteLine("Password Succesfuuly created!");
			}
			else
			{
				Console.WriteLine("Errors while cretaing passwords !");
				if(c1 == 1)
				{
					Console.WriteLine("Length of password should be atleast 8");
				}
				if(c2 == 0)
				{
					Console.WriteLine("Password should have atleast 1 capital letter");
				}
                if (c3 == 0)
                {
                    Console.WriteLine("Password should have atleast 1 number");
                }
				Console.WriteLine("Try Again!");
				goto trail2;
            }

        }
        #endregion

        #region task 6
        public void transactionsList()
		{
			int[] transactionType = new int[100];
			int[] amount = new int[100];
            int choice = 1,c,amount1;
			string s;
			int i = 0;
			do
			{
				Console.WriteLine("Deposit - Press 1\nWithdraw - Press 2");
                c = int.Parse(Console.ReadLine());
				transactionType[i] = c;


                Console.WriteLine("Enter the amount");

                amount1 = int.Parse(Console.ReadLine());
				amount[i] = amount1;

				if (c == 1)
					s = "Deposit";
				else
					s = "Withdraw";
				Console.WriteLine($"{s} Successful");

                i += 1;

                Console.WriteLine("Continue? Press - 1\nExit? - Press 0");
				choice = int.Parse(Console.ReadLine());

			} while (choice == 1);

			transactionType[i] = -1;
			i = 0;
			Console.WriteLine("------Your History------");
			while (transactionType[i]!=-1)
			{
				if (transactionType[i]==1)
					Console.WriteLine($"Deposited Amount of {amount[i]}");
                else if (transactionType[i] == 2)
                    Console.WriteLine($"Withdrawal Amount of {amount[i]}");
				i += 1;
            }
		}
        #endregion
    }
}

