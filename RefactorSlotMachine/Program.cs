using RefactorSlotMachine;
using System;
namespace RefactorSlotMachine
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Decimal balance = Constants.INITIAL_BALANCE;

            bool playAgain = true;


            while (playAgain)
            {
                //Welcome message
                bool success = UIMethods.WelcomeMessage();
                decimal returnValue;
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
                    winningAmount = logics.HorizontalWin(balance, Constants.FIRST_WIN, Constants.SECOND_WIN, Constants.BET_AMOUNT);
                }
                else if (myBet == Constants.VERTICAL_LINE)
                {
                    winningAmount = logics.VerticalWin(balance, Constants.FIRST_WIN, Constants.SECOND_WIN, Constants.BET_AMOUNT);
                }
                else if (myBet == Constants.DIAGONAL_LINE)
                {
                    winningAmount = logics.DiagonalWin(balance, Constants.FIRST_WIN, Constants.BET_AMOUNT, Constants.CENTER_WIN);
                }
                else if (myBet == Constants.VER_CENTER_LINE)
                {
                    winningAmount = logics.VerticalCenterWin(balance, Constants.FIRST_WIN, Constants.BET_AMOUNT, Constants.CENTER_WIN);
                }
                else if (myBet == Constants.HOR_CENTER_LINE)
                {
                    winningAmount = logics.HorizontalCenterWin(balance, Constants.FIRST_WIN, Constants.BET_AMOUNT, Constants.CENTER_WIN);
                }
                else
                {
                    logics.InvalidBetting();
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