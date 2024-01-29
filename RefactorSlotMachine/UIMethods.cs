using System;


namespace RefactorSlotMachine
{
    internal class UIMethods
    {
        /// <summary>
        /// Welcome Message
        /// </summary>
        /// <returns></returns>
        public static void WelcomeMessage()
        {

            //First messages
            Console.WriteLine("Welcome to the Amazing Slot Machine!");
            Console.WriteLine("Spin the reels and win big!");
            //Display betting options
            //Display betting options
            Console.WriteLine("To Spin, Press......");
            Console.WriteLine("- (A) Play all three horizontal lines with $2: Earn $20 for one line wins, $40 for two lines win, and $60 for three lines win");
            Console.WriteLine("- (H) Play all vertical lines with $2: Earn $20 for first line wins, $40 for two lines win, and $60 for three lines win");
            Console.WriteLine("- (V) Play horizontal center line alone with $2: Earn $30.");
            Console.WriteLine("- (C) Play vertical center line with $2: Earn $30.");
            Console.WriteLine("- (D) Play diagonals with $2: Earn $20 for any and $60 for the two winning combination.");
        }

        /// <summary>
        /// Choose Bet
        /// </summary>
        /// <param name="balance"></param>
        /// <returns></returns>
        public static char ChooseBet()
        {
            //Betting amount
            Console.Write("\nPlease choose a betting option (A, H, V, C, D): ");
            char bettingOption = char.ToUpper(Console.ReadKey().KeyChar);
            Console.WriteLine();

            ////Check if the betting option is valid
            if (bettingOption != Constants.HORIZONTAL_LINE && bettingOption != Constants.VERTICAL_LINE && bettingOption != Constants.HOR_CENTER_LINE && bettingOption != Constants.VER_CENTER_LINE && bettingOption != Constants.DIAGONAL_LINE)
            {
                Console.WriteLine("Invalid betting option. Please try again.");
            }

            return bettingOption;
        }

        /// <summary>
        /// BettingResult
        /// </summary>
        /// <returns></returns>
        public static void BettingResult()
        {
            //Display the result
            Console.WriteLine("\nSlot Machine Results: \n");

            //Ramdom Pick Generator

            for (int row = 0; row < Constants.ROW_COUNT; row++)
            {
                for (int col = 0; col < Constants.COLUMN_COUNT; col++)
                {
                    //int randomIndex = Logics.randomPickGenerator.Next(Logics.slotSymbols.Count);
                    //Logics.slots_Output[row, col] = Logics.slotSymbols[randomIndex];
                    Logics.slots_Output = new char[,] { { '1', '1', '1' }, { '1', '1', '1' }, { '1', '0', '1' } };
                    Console.Write(Logics.slots_Output[row, col] + "\t");
                }
                Console.WriteLine();

            }
            //Check if the betting option is valid


            //return Logics.slots_Output;
        }


        /// <summary>
        /// HorizontalHandleWinResults
        /// </summary>
        /// <param name="winCount"></param>
        /// <param name="balance"></param>
        /// <returns></returns>
       /*
 public static decimal HorizontalHandleWinResults(decimal winCount, decimal balance)
        {
            if (winCount == 0)
            {
                Console.WriteLine("\nNo horizontal win found.");
                balance -= Constants.BET_AMOUNT;
            }
            else
            {
                decimal winAmount = 0;

                string winType = "";

                if (winCount == 1)
                {
                    winAmount = Constants.FIRST_WIN;
                    winType = "Single";
                }
                else if (winCount == 2)
                {
                    winAmount = Constants.TWO_COMBINE_WIN;
                    winType = "Double";
                }
                else
                {
                    winAmount = Constants.THREE_COMBINE_WIN;
                    winType = "Triple";
                }

                balance += winAmount;
                Console.WriteLine($"\n{winType} win detected on Horizontal line: {winCount}.");
            }

            return balance;
        }
        */

       

        public static decimal HorizontalHandleWinResults(decimal winCount, decimal balance)
        {
            if (winCount == 0)
            {
                Console.WriteLine("\nNo horizontal win found.");
                balance -= Constants.BET_AMOUNT;
            }
            else
            {
                (decimal winAmount, string winType) = Logics.CalculateWinDetails(winCount); 
                balance += winAmount;
                Console.WriteLine($"\n{winType} win detected on Horizontal line: {winCount}.");
            }

            return balance;
        }

        public static decimal VerticalHandleWinResults(decimal winCount, decimal balance)
        {
            if (winCount == 0)
            {
                Console.WriteLine("\nNo vertical win found.");
                balance -= Constants.BET_AMOUNT;
            }
            else
            {
                (decimal winAmount, string winType) = Logics.CalculateWinDetails(winCount);  // Call the new function
                balance += winAmount;
                Console.WriteLine($"\n{winType} win detected on vertical line: {winCount}. Balance: {balance}");
            }

            return balance;
        }


        /// <summary>
        /// VerticalHandleWinResults
        /// </summary>
        /// <param name="winCount"></param>
        /// <param name="balance"></param>
        /// <returns></returns>
    }

}