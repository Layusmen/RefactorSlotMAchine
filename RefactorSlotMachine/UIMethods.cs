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
            Console.WriteLine("To Spin, Press......");
            Console.WriteLine("- (A) Play all three horizontal lines with $2: Earn $20 for one line wins, $40 for two lines win, and $60 for three lines win");
            Console.WriteLine("- (H) Play all vertical lines with $2: Earn $20 for first line wins, $40 for two lines win, and $60 for three lines win");
            Console.WriteLine("- (V) Play horizontal center line alone with $2: Earn $30.");
            Console.WriteLine("- (C) Play vertical center line with $2: Earn $30.");
            Console.WriteLine("- (D) Play diagonals with $2: Earn $20 for any and $60 for the two winning combination.");
            //Display betting options

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

                //Check if the betting option is valid		   


                if (!Constants.bettingSelect.Contains(bettingOption))
                {
                    UIMethods.InvalidValuePrint();
                }


                return bettingOption;
        }

        /// <summary>
        /// Betting Result
        /// </summary>
        /// <returns></returns>
        public static void BettingResult()
        {
            //Display the result
            Console.WriteLine("\nSlot Machine Results:\n");
        }


        /// <summary>
        /// Play Again Prompt Function
        /// </summary>
        public static bool PlayAgainPrompt()
        {
            Console.Write("\nPlay again (y/n)? ");
            return Console.ReadKey().KeyChar == Constants.SMALL_YES || Console.ReadKey().KeyChar == Constants.CAPITAL_YES;
        }


        /// <summary>
        /// Horizontal Play Message
        /// </summary>
        public static void HorizontalPlayPrint()
        {
            Console.WriteLine("\nYou chose to play all three horizontal lines with $2: Earn $20 for top line wins, $5 for middle or base line wins.");
        }

        /// <summary>
        /// Vertical Play Message
        /// </summary>
        public static void VerticalPlayPrint()
        {
            Console.WriteLine("\nYou chose to play all three vertical lines with $2: Earn $20 for top line wins, $5 for middle or base line wins.");
        }

        /// <summary>
        /// Diagonal Play Message
        /// </summary>
        public static void DiagonalPlayPrint()
        {

            Console.WriteLine("Play diagonals with $2: Earn $20 for any winning combination, $30 for both.");
        }

        /// <summary>
        /// Vertical Center Play Message
        /// </summary>
        public static void VerticalCenterPlayPrint()
        {
            Console.WriteLine("\nYou chose to play vertical center line with $2: Earn $30.");
        }

        /// <summary>
        /// Horizontal Center Play
        /// </summary>
        public static void HorizontalCenterPlayPrint()
        {

            Console.WriteLine("\nPlay horizontal center line alone with $2: Earn $30.");
        }

        /// <summary>
        /// Middle Horizontal Play Message
        /// </summary>
        public static void MiddleHorizontalPlayPrint()
        {
            Console.WriteLine($"\nCongratulations! You win on the horizontal middle line!");
        }

        /// <summary>
        /// No Win Detected Message
        /// </summary>
        public static void NoWinPrint()
        {
            Console.WriteLine("\nNo win Detected");
        }

        /// <summary>
        /// Win Detected Message
        /// </summary>
        public static void WinDetectionPrint()
        {
            Console.WriteLine($"\nCongratulations! You won!");
        }

        /// <summary>
        /// Invalid input Message
        /// </summary>
        public static void InvalidValuePrint()
        {
            Console.WriteLine("\n\nInvalid value inserted, Try Again!");

        }

        /// <summary>
        /// Current Balance Message
        /// </summary>
        /// <param name="updatedBalance"></param>
        public static void BalanceUpdatePrint(decimal updatedBalance)
        {
            Console.WriteLine($"\nYour current balance: ${updatedBalance}");
        }

        /// <summary>
        /// Fund Insufficient Message
        /// </summary>
        public static void FundInsufficientPrint()
        {
            Console.WriteLine("\nInsufficient funds to play. Game over!");
        }

        /// <summary>
        /// Win Detection Message
        /// </summary>
        /// <param name="winType"></param>
        /// <param name="winCount"></param>
        public static void WinDetectionPrint(string winType, decimal winCount)
        {
            Console.WriteLine($"\n{winType} win detected on line: {winCount}.");
        }
    }

}