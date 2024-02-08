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
                // decimal updatedBalance;

                //Welcome message
                UIMethods.PrintWelcome();
               
                //Select option
                char betSwitch = UIMethods.PromptChooseBet();



                static string SlotOutputBuilder()
                {
                    string output = "";
                    for (int row = 0; row < Constants.ROW_COUNT; row++)
                    {
                        for (int col = 0; col < Constants.COLUMN_COUNT; col++)
                        {
                            char[,] slots_Output = new char[Constants.ROW_COUNT, Constants.COLUMN_COUNT];

                            //int randomIndex = randomPickGenerator.Next(slotSymbols.Count);
                            //slots_Output[row, col] = slotSymbols[randomIndex];

                            slots_Output = new char[,] { { '1', '1', '1' }, { '1', '1', '1' }, { '1', '1', '1' } };

                            output += slots_Output[row, col] + "\t";
                        }
                        output += "\n";
                    }
                    return output;

                }

                //Random Generator print
                string formattedOutput = Logics.SlotOutputBuilder();

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
                UIMethods.PrintBettingResult(formattedOutput);


                //play again prompt
                UIMethods.PromptPlayAgain();

                // Clear the console for the next round
                Console.Clear();
            }

        }
    }
}