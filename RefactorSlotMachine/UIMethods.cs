using System;


namespace RefactorSlotMachine
{
    internal class UIMethods
    {
        public static void WelcomeMessage()
        {
            //First messages
            Console.WriteLine("Welcome to the Amazing Slot Machine!");
            Console.WriteLine("Spin the reels and win big!");

            //Display betting options
            Console.WriteLine("To Spin, Press......");
            Console.WriteLine("- (A) Play all three horizontal lines with $2: Earn $20 for top line wins, $5 for middle or base line wins.");
            Console.WriteLine("- (H) Play all vertical lines with $2: Earn $20 for first line wins, $5 for second or third line wins.");
            Console.WriteLine("- (V) Play horizontal center line alone with $2: Earn $30.");
            Console.WriteLine("- (C) Play vertical center line with $2: Earn $30.");
            Console.WriteLine("- (D) Play diagonals with $2: Earn $20 for any and $30 for the two winning combination.");
        }

        public static void ChooseBet()
        {
            Console.Write("\nPlease choose a betting option (A, H, V, C, D): ");
            //char bettingOption = char.ToUpper(Console.ReadKey().KeyChar);
            Console.WriteLine();
        }

    }
}