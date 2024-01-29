﻿using System;


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
                    Logics.slots_Output = new char[,] { { '1', '0', '1' }, { '1', 'o', '1' }, { '1', '0', '1' } };
                    Console.Write(Logics.slots_Output[row, col] + "\t");
                }
                Console.WriteLine();

            }
            //Check if the betting option is valid


            //return Logics.slots_Output;
        }

       

        /// <summary>
        /// VerticalHandleWinResults
        /// </summary>
        /// <param name="winCount"></param>
        /// <param name="balance"></param>
        /// <returns></returns>


        /// <summary>
        /// CheckGameOver
        /// </summary>
        /// <param name="balance"></param>


        /// <summary>
        /// PlayAgainKey
        /// </summary>
        public static void PlayAgainKey()
        {
            Console.Write("\nDo you want to play again? (press 'y' for yes, any other key for no): ");
        }


        public static void HorizontalPlay()
        {
            Console.WriteLine("\nYou chose to play all three horizontal lines with $2: Earn $20 for top line wins, $5 for middle or base line wins.");
        }

        public static void VerticalPlay()
        {
            Console.WriteLine("\nYou chose to play all three vertical lines with $2: Earn $20 for top line wins, $5 for middle or base line wins.");
        }
        public static void DiagonalPlay()
        {

            Console.WriteLine("Play diagonals with $2: Earn $20 for any winning combination, $30 for both.");
        }

        public static void VerticalCenterPlay()
        {
            Console.WriteLine("\nYou chose to play vertical center line with $2: Earn $30.");
        }

        public static void HorizontalCenterPlay()
        {

            Console.WriteLine("\nPlay horizontal center line alone with $2: Earn $30.");
        }

        public static void MiddleHorizontalPlay()
        {
            Console.WriteLine($"\nCongratulations! You win on the horizontal middle line!");
        }

        public static void NoWinDetected()
        {
            Console.WriteLine("\nNo win Detected");
        }
        public static void WinDetected()
        {
            Console.WriteLine($"\nCongratulations! You won!");
        }

        public static void InvalidValue()
        {
            Console.WriteLine("\nInvalid value inserted, Try Again!");
        }

        public static void ValueUpdate(decimal updatedBalance)
        {
            Console.WriteLine($"\nYour current balance: ${updatedBalance}");
        }
        public static void FundInsufficient()
        {
            Console.WriteLine("\nInsufficient funds to play. Game over!");
        }

       public static void PrintWin(string winType, decimal winCount)
        {
            Console.WriteLine($"\n{winType} win detected on line: {winCount}.");
        }
    }

}