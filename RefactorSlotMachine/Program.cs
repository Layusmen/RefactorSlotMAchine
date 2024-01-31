﻿using System;

namespace RefactorSlotMachine
{
    internal class Program
    {
        public static void Main(string[] args)
        {

            decimal balance = Constants.INITIAL_BALANCE;


            bool playAgain = true;
            while (playAgain)
            {
               // decimal updatedBalance;

                //Welcome message
                UIMethods.WelcomeMessage();

                //Select option
                char betSwitch = UIMethods.ChooseBet();

                //Betting Results Removed
                UIMethods.BettingResult();

                // Check if it is gameover
                Logics.CheckGameOver(balance);

                Logics.RandomGeneratorPrint();
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
                UIMethods.BalanceUpdatePrint(balance);
                //returning updatedBalance to balance
              
                //play again prompt
                UIMethods.PlayAgainPrompt();

                // Clear the console for the next round
                Console.Clear();
            }



        }
    }
}