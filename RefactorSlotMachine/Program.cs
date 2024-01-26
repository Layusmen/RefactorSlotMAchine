using RefactorSlotMachine;
using System;
using System.Runtime.Intrinsics.X86;
namespace RefactorSlotMachine
{
    internal class Program
    {
        public static void Main(string[] args)
        {
           
            decimal balance = Constants.INITIAL_BALANCE;
            
           
            bool playAgain = true;            
            while (playAgain)
            {
                decimal updatedBalance;
                //Welcome message
                bool success = UIMethods.WelcomeMessage();

                //Select option
                char myBet = UIMethods.ChooseBet();
                
                char[,] betMatrix = UIMethods.BettingResult();
                
                if (balance < Constants.BET_AMOUNT)
                {
                    Console.WriteLine("\nInsufficient funds to play. Game over!");
                    break;
                }


                //Check for a win on all the lines
                
                if (myBet == Constants.HORIZONTAL_LINE)
                {
                    balance += Logics.HorizontalWin();
                }
                else if (myBet == Constants.VERTICAL_LINE)
                {
                    balance += Logics.VerticalWin();
                }
                else if (myBet == Constants.DIAGONAL_LINE)
                {
                    balance += Logics.DiagonalWin();
                }
                else if (myBet == Constants.VER_CENTER_LINE)
                {
                    balance += Logics.VerticalCenterWin();
                }
                else if (myBet == Constants.HOR_CENTER_LINE)
                {
                   balance += Logics.HorizontalCenterWin();
                }
                else
                {
                    Console.WriteLine("\nInvalid value insertered, Try Again!");
                    return;
                }
               

                //Bet Calculation
                if (playAgain)
                {
                    updatedBalance = balance - Constants.BET_AMOUNT;
                    //updated balance
                    Console.WriteLine($"\nYour current balance: ${updatedBalance}");
                }
                else
                {
                    updatedBalance = balance + Constants.INITIAL_BALANCE;
                    //updated balance
                    Console.WriteLine($"\nYour current balance: ${updatedBalance}");
                }

                //returning updatedBalance to balance
                balance = updatedBalance;

                Console.Write("\nDo you want to play again? (press 'y' for yes, any other key for no): ");
                ConsoleKeyInfo key = Console.ReadKey();

                // Check if the pressed key is 'y' or 'Y' for yes
                playAgain = key.KeyChar == 'y' || key.KeyChar == 'Y';

                // Clear the console for the next round
                Console.Clear();
            }
            


        }
    }
}