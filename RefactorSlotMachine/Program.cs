using Microsoft.VisualBasic;
using RefactorSlotMachine;
using System;
using System.Security.Cryptography.X509Certificates;
using Constants = RefactorSlotMachine.Constants;


bool playAgain = true;

while (playAgain)
{
    //Welcome message
    bool success = UIMethods.WelcomeMessage();


    //Select option
    char myBet= UIMethods.ChooseBet(balance);

    //Check for a win on horizontal lines
    if (bettingOption == Constants.HORIZONTAL_LINE)
    {
        logics.HorizontalWin(balance, Constants.FIRST_WIN, Constants.SECOND_WIN, Constants.BET_AMOUNT);
    }

    //Check for a win on vetical lines

    else if (bettingOption == Constants.VERTICAL_LINE)
    {
        logics.VerticalWin(balance, Constants.FIRST_WIN, Constants.SECOND_WIN, Constants.BET_AMOUNT);
    }

    else if (bettingOption == Constants.DIAGONAL_LINE)
    {
        logics.DiagonalWin(balance, Constants.FIRST_WIN, Constants.BET_AMOUNT, Constants.CENTER_WIN);
    }

    else if (bettingOption == Constants.VER_CENTER_LINE)
    {   ///Check for a win on the Vertical Center line 
        logics.VerticalCenterWin(balance, Constants.FIRST_WIN, Constants.BET_AMOUNT, Constants.CENTER_WIN);
    }

    else if (bettingOption == Constants.HOR_CENTER_LINE)
    {

        logics.HorizontalCenterWin(balance, Constants.FIRST_WIN, Constants.BET_AMOUNT, Constants.CENTER_WIN);
    }
    else
    {
        //No Win
        logics.InvalidBetting();
    }

    Console.Write("\nDo you want to play again? (press 'y' for yes, any other key for no): ");
    ConsoleKeyInfo key = Console.ReadKey();

    // Check if the pressed key is 'y' for yes
    playAgain = key.KeyChar == 'y' || key.KeyChar == 'Y';

    // Clear the console for the next round
    Console.Clear();

    // Restore the initial balance for the next play if user chooses to play again
   balance = playAgain ? balance : balance;
}
