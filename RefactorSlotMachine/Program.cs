using Microsoft.VisualBasic;
using RefactorSlotMachine;
using System;
using System.Security.Cryptography.X509Certificates;
using Constants = RefactorSlotMachine.Constants;

namespace Slot_Machine
{
    static class Program
    {
    

        static void Main(string[] args)
        {

            

            bool playAgain = true;

            // Player's initial balance
            decimal balance = Constants.INITIAL_BALANCE;
            UIMethods.WelcomeMessage();

            while (playAgain)
            {

                    //Ramdom Pick Generator
                    logics.BettingCheck();

                
                    //BET AMOUNT
                    logics.BettingValidity(balance, Constants.BET_AMOUNT);

                    //Check for a win on horizontal lines

                    logics.HorizontalWin(balance, Constants.FIRST_WIN, Constants.SECOND_WIN, Constants.BET_AMOUNT);

                    //Check for a win on vetical lines

                    logics.VerticalWin(balance, Constants.FIRST_WIN, Constants.SECOND_WIN, Constants.BET_AMOUNT);


                    //Check for a win on the diagoal lines.

                    logics.DiagonalWin(balance, Constants.FIRST_WIN, Constants.BET_AMOUNT);

                    ///Check for a win on the Vertical Center line 
                    logics.VerticalCenterWin(balance, Constants.FIRST_WIN, Constants.BET_AMOUNT, Constants.CENTER_WIN);


                    logics.DiagonalCenterWin(balance, Constants.FIRST_WIN, Constants.BET_AMOUNT, Constants.CENTER_WIN);

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