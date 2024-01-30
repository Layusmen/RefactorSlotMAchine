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
                char betSwitch = UIMethods.ChooseBet();

                //Betting Results Removed
                UIMethods.BettingResult();

                // Check if it is gameover
                Logics.CheckGameOver(balance);


                //Check for a win on all the lines
               decimal betAmount =  Logics.MyBetProcess(betSwitch, balance);

                //Bet Calculation
                if (playAgain)
                {
                    updatedBalance = betAmount - Constants.BET_AMOUNT;
                    //updated balance
                    UIMethods.BalanceUpdatePrint(updatedBalance);
                }
                else
                {
                    updatedBalance = betAmount + Constants.INITIAL_BALANCE;
                    //updated balance
                    UIMethods.BalanceUpdatePrint(updatedBalance);
                }

                //returning updatedBalance to balance
                balance = updatedBalance;

                UIMethods.PlayAgainPrompt();

                ConsoleKeyInfo key = Console.ReadKey();

                // Check if the pressed key is 'y' or 'Y' for yes
                playAgain = key.KeyChar == Constants.SMALLYES || key.KeyChar == Constants.CAPITALYES;

                // Clear the console for the next round
                Console.Clear();
            }



        }
    }
}