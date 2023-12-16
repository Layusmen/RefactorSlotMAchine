using RefactorSlotMachine;
using System;
using System.Security.Cryptography.X509Certificates;

namespace Slot_Machine
{
    static class Program
    {
        static void Main(string[] args)
        {
            //Constants


            const decimal INITIAL_BALANCE = 10.00M;
            const decimal BET_AMOUNT = 2.00M;
            const decimal FIRST_WIN = 20.00M;
            const decimal SECOND_WIN = 5.00M;
            const decimal CENTER_WIN = 30.00M;



            bool playAgain = true;

            // Player's initial balance
            decimal balance = INITIAL_BALANCE;
            UIMethods.WelcomeMessage();

            while (playAgain)
            {

                    //Ramdom Pick Generator
                    logics.BettingCheck();

                
                    //BET AMOUNT
                    logics.BettingValidity(balance, BET_AMOUNT);

                    //Check for a win on horizontal lines

                    logics.HorizontalWin(balance, FIRST_WIN, SECOND_WIN, BET_AMOUNT);

                    //Check for a win on vetical lines

                    logics.VerticalWin(balance, FIRST_WIN, SECOND_WIN, BET_AMOUNT);


                    //Check for a win on the diagoal lines.

                    logics.DiagonalWin(balance, FIRST_WIN, BET_AMOUNT);

                    ///Check for a win on the Vertical Center line 
                    logics.VerticalCenterWin(balance, FIRST_WIN, BET_AMOUNT, CENTER_WIN);


                    logics.DiagonalCenterWin(balance, FIRST_WIN, BET_AMOUNT, CENTER_WIN);

                    //No Win
                    logics.NoWin();

                Console.Write("\nDo you want to play again? (press 'y' for yes, any other key for no): ");
                ConsoleKeyInfo key = Console.ReadKey();

                // Check if the pressed key is 'y' for yes
                playAgain = key.KeyChar == 'y' || key.KeyChar == 'Y';

                // Clear the console for the next round
                Console.Clear();

                // Restore the initial balance for the next play if user chooses to play again
                balance = playAgain ? balance : balance;
            }
        }
    }
}