using System;

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
                UIMethods.WelcomeMessage();

                //Select option
                char myBet = UIMethods.ChooseBet();

                //Betting Results Removed
                UIMethods.BettingResult();

                // Check if it is gameover
                UIMethods.CheckGameOver(balance);


                //Check for a win on all the lines
                Logics.MyBetProcess(myBet, balance);

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

                UIMethods.PlayAgainKey();

                ConsoleKeyInfo key = Console.ReadKey();

                // Check if the pressed key is 'y' or 'Y' for yes
                playAgain = key.KeyChar == 'y' || key.KeyChar == 'Y';

                // Clear the console for the next round
                Console.Clear();
            }



        }
    }
}