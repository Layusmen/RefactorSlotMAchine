using System;
namespace RefactorSlotMachine
{
    internal class Program
    {
        public static char[,] slots_Output = new char[Constants.ROW_COUNT, Constants.COLUMN_COUNT];

        public static void Main(string[] args)
        {
            decimal balance = Constants.INITIAL_BALANCE;
            bool playAgain = true;
            while (playAgain)
            {
                //Welcome message
                UIMethods.PrintWelcome();
                //Select option
                char betSwitch = UIMethods.PromptChooseBet();

                //Random Generator Slot Output Builder
                char[,] formattedOutput = Logics.SlotOutputBuilder();

                // Check if it is Game Over
                if (Logics.CheckGameOver(balance))
                {
                    break;
                }
                //Check for a win on all the lines
                decimal betAmount = Logics.BetProcess(betSwitch, balance);

                //Bet Calculation
                if (playAgain)
                {
                    balance = betAmount - Constants.BET_AMOUNT;
                }
                else
                {
                    balance = betAmount + Constants.INITIAL_BALANCE;
                }

                //updated balance
                UIMethods.PrintBalanceUpdate(balance);

                //Betting Result.
                UIMethods.PrintBettingResult();

                //play again prompt
                playAgain = UIMethods.PromptPlayAgain();

                // Clear the console for the next round
                Console.Clear();
            }

        }
    }
}