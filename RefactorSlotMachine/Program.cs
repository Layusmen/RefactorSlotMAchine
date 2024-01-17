using Microsoft.VisualBasic;
using RefactorSlotMachine;
using System;
namespace RefactorSlotMachine
{
    internal class Program
    {
        public static void Main(string[] args)
        {
           
            decimal balance = Constants.INITIAL_BALANCE;

            bool playAgain = true;
            balance = Logics.HorizontalWin(winningBalance);

            while (playAgain)
            {
               
                //Welcome message
                bool success = UIMethods.WelcomeMessage();
                //Select option
                char myBet = UIMethods.ChooseBet(balance);

                if (balance < Constants.BET_AMOUNT)
                {
                    Console.WriteLine("\nInsufficient funds to play. Game over!");
                    break;
                }

                //Check for a win on all the lines
                decimal winningAmount;

                if (myBet == Constants.HORIZONTAL_LINE)
                {
                    winningAmount = Logics.HorizontalWin(balance);
                }
                else if (myBet == Constants.VERTICAL_LINE)
                {
                    winningAmount = Logics.VerticalWin(balance);
                }
                else if (myBet == Constants.DIAGONAL_LINE)
                {
                    winningAmount = Logics.DiagonalWin(balance);
                }
                else if (myBet == Constants.VER_CENTER_LINE)
                {
                    winningAmount = Logics.VerticalCenterWin(balance);
                }
                else if (myBet == Constants.HOR_CENTER_LINE)
                {
                    winningAmount = Logics.HorizontalCenterWin(balance);
                }
                else
                {
                    Logics.InvalidBetting();
                    return; // Exit early if there's no valid bet
                }

                balance = winningAmount;


                Console.Write("\nDo you want to play again? (press 'y' for yes, any other key for no): ");
                ConsoleKeyInfo key = Console.ReadKey();

                // Check if the pressed key is 'y' for yes
                playAgain = key.KeyChar == 'y' || key.KeyChar == 'Y';

                // Restore the initial balance for the next play if user chooses to play again
                //balance = playAgain ? balance : balance;
                balance = playAgain ? balance : Constants.INITIAL_BALANCE;
                // Clear the console for the next round
                Console.Clear();

            }
        }
    }
}