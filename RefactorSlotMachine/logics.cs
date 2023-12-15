using System;


namespace RefactorSlotMachine
{
    internal class logics
    {
        public static void BettingCheck()
        {

           UIMethods.WelcomeMessage();

                //Select option
                UIMethods.ChooseBet();
                char bettingOption = char.ToUpper(Console.ReadKey().KeyChar);
                

                //Random Generator

                Random randomPickGenerator = new Random();
                List<char> slotSymbols = new List<char> { 'A', '1', '5', '7', '$', 'M', '8', '9', '!', '#', 'Q', '&', 'C', 'S', 'Y', 'V', 'W', 'R', 'L', 'F' };
                char[,] slots_Output = new char[constants.ROW_COUNT, constants.COLUMN_COUNT];


                //Display the result
                UIMethods.DisplayResult();

                //Ramdom Pick Generator
                logics.BettingCheck();
                
            
            for (int row = 0; row < constants.ROW_COUNT; row++)
            {
                for (int col = 0; col < constants.COLUMN_COUNT; col++)
                {
                    int randomIndex = randomPickGenerator.Next(slotSymbols.Count);
                    slots_Output[row, col] = slotSymbols[randomIndex];
                    Console.Write(slots_Output[row, col] + "\t");
                }
                Console.WriteLine();

            }

        }
        public static void BettingValidity(logics.)
        {

            //Check if the betting option is valid 

            if (bettingOption != constants.HORIZONTAL_LINE && bettingOption != constants.VERTICAL_LINE && bettingOption != constants.HOR_CENTER_LINE && bettingOption != constants.VER_CENTER_LINE && bettingOption != constants.DIAGONAL_LINE)
            {
                Console.WriteLine("Invalid betting option. Please try again.");
                return;
            }
            if (balance < BET_AMOUNT)
            {
                Console.WriteLine("\nInsufficient funds to play. Game over!");
                break;
            }

        }






    }
}
