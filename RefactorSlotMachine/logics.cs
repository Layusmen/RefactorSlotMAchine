﻿using System;
using RefactorSlotMachine;

namespace RefactorSlotMachine
{
    internal class Logics
    {
        // Declare win flags as class-level variables
        public static bool horizontalWin;
        public static bool verticalWin;
        public static bool diagonalWin;
        public static bool verticalCenterWin;
        public static bool horizontalCenterWin;
        public static bool diagonalCenterWin;

       
        
        public static char[,] slots_Output = new char[Constants.ROW_COUNT, Constants.COLUMN_COUNT];

        
        public readonly static Random randomPickGenerator = new Random();

        
        public static List<char> slotSymbols = new List<char> { 'A', '1', '5', '7', '$', 'M', '8', '9', '!', '#', 'Q', '&', 'C', 'S', 'Y', 'V', 'W', 'R', 'L', 'F' };

        
        public static decimal HorizontalWin()

        {
            //Horizonal win option
            //int score = 0;
            decimal balance = 0;
            Console.WriteLine("\nYou chose to play all three horizontal lines with $2: Earn $20 for top line wins, $5 for middle or base line wins.");

            // Horizonal win option start


                // Check for horizontal wins and store win details
                List<string> winDescriptions = new List<string>();
            for (int row = 0; row < slots_Output.GetLength(0); row++)
            {
                bool equalElements = true;
                for (int column = 1; column < slots_Output.GetLength(1); column++)
                {
                    if (slots_Output[row, 0] != slots_Output[row, column])
                    {
                        equalElements = false;
                        break;
                    }
                }

                if (equalElements)
                {
                    string winDescription = "";
                    if (row == 0)
                    {
                        winDescription = "top row";
                    }
                    else if (row == slots_Output.GetLength(0) - 1)
                    {
                        winDescription = "bottom row";
                    }
                    else
                    {
                        winDescription = "middle row";
                    }

                    winDescriptions.Add(winDescription); // Add individual win description
                }
            }

            // Report win details
            if (winDescriptions.Count > 0)
            {
                Console.WriteLine("\nHorizontal wins found:");
                if (winDescriptions.Count == slots_Output.GetLength(0))
                {
                    balance += Constants.THREE_COMBINE_WIN;
                    Console.WriteLine("\nYou won on all rows!");
                }
                else if (winDescriptions.Count == 2)
                {
                    balance += Constants.TWO_COMBINE_WIN;
                    Console.WriteLine("\nYou won on the " + string.Join(" and ", winDescriptions) + ".");
                }
                else
                {
                    balance += Constants.FIRST_WIN;
                    Console.WriteLine("\nYou won on the " + string.Join(", ", winDescriptions) + ".");
                }
            }

            else
            {
                Console.WriteLine("\nNo horizontal wins found.");
            }

            //Horizonal win option end
            return balance;
        }

        public static decimal VerticalWin()
        {
            decimal balance = 0;
            Console.WriteLine("\nPlay all vertical lines with $2: Earn $20 for first line wins, $5 for second or third line wins.");

            // Check for horizontal wins and store win details
            List<string> winDescriptions = new List<string>();
            for (int column = 0; column < slots_Output.GetLength(0); column++)
            {
                bool equalElements = true;
                for (int row = 1; row < slots_Output.GetLength(1); row++)
                {
                    if (slots_Output[0, column] != slots_Output[row, column])
                    {
                        equalElements = false;
                        break;
                    }
                }

                if (equalElements)
                {
                    string winDescription = "";
                    if (column == 0)
                    {
                        winDescription = "first column";
                    }
                    else if (column == slots_Output.GetLength(0) - 1)
                    {
                        winDescription = "last column";
                    }
                    else
                    {
                        winDescription = "middle column";
                    }

                    winDescriptions.Add(winDescription); // Add individual win description
                }
            }

            // Report win details
            if (winDescriptions.Count > 0)
            {
                Console.WriteLine("\nVertical wins found:");
                if (winDescriptions.Count == slots_Output.GetLength(0))
                {
                    balance += Constants.THREE_COMBINE_WIN;
                    Console.WriteLine("\nYou won on all columns!");
                }
                else if (winDescriptions.Count == 2)
                {
                    balance += Constants.TWO_COMBINE_WIN;
                    Console.WriteLine("\nYou won on the " + string.Join(" and ", winDescriptions) + ".");
                }
                else
                {
                    balance += Constants.FIRST_WIN;
                    Console.WriteLine("\nYou won on the " + string.Join(", ", winDescriptions) + ".");
                }
            }

            else
            {
                Console.WriteLine("\nNo vertical wins found.");
            }


            return balance;
        }

        public static decimal DiagonalWin()

        {
            decimal balance = 0;
            Console.WriteLine("Play diagonals with $2: Earn $20 for any winning combination, $30 for both.");

            //Check the main diagonal (top-left to bottom-right)
            bool isMainDiagonalWin = true;
            for (int i = 1; i < Constants.ROW_COUNT; i++)
            {
                if (slots_Output[i, i] != slots_Output[0, 0])
                {
                    isMainDiagonalWin = false;
                    break;
                }
            }
            if (isMainDiagonalWin)
            {
                Console.WriteLine("\nWin Detected on Main Diagonal");
                balance += Constants.FIRST_WIN; // Assuming $20 for a win on the first row
            }

            //Check the secondary diagonal (top-right to bottom-left)
            bool isSecondaryDiagonalWin = true;
            for (int i = 1; i < Constants.ROW_COUNT; i++)
            {
                if (slots_Output[i, Constants.ROW_COUNT - 1 - i] != slots_Output[0, Constants.ROW_COUNT - 1])
                {
                    isSecondaryDiagonalWin = false;
                    break;
                }
            }
            if (isSecondaryDiagonalWin && isMainDiagonalWin)
            {

                // Handle the case when there's a win on both diagonals
                Console.WriteLine("\nWin Detected on Both Diagonals");
                balance += Constants.CENTER_WIN; // Assuming $20 for a win on the first row
            }
            else if (isSecondaryDiagonalWin)
            {
                Console.WriteLine("\nWin Detected on Secondary Diagonal");
                balance += Constants.FIRST_WIN; // Assuming $20 for a win on the first row
            }
            else if (!isSecondaryDiagonalWin && !isMainDiagonalWin)
            {
                Console.WriteLine("\nNo win Detected on any of the Diagonal lines");
                balance -= Constants.BET_AMOUNT;
            }

            else
            {
                Console.WriteLine("\nNo win Detected on any of the Diagonal lines");
                balance -= Constants.BET_AMOUNT; // Subtract the bet amount from the balance if no win is detected on any of the diagonal lines.
            }

            // Display the updated balance
            Console.WriteLine($"\nYour current balance: ${balance}");
            return balance;
        }

        public static decimal VerticalCenterWin()
        {
            decimal balance = 0;
            Console.WriteLine("\nYou chose to play vertical center line with $2: Earn $30.");

            // Check for a win on a specific vertical line
            bool verticalCenterWin = true;

            for (int row = 1; row < slots_Output.GetLength(0); row++)
            {   // Compare the current symbol to the previous symbol in the specified column
                if (slots_Output[row, 1] != slots_Output[0, 1])
                {
                    verticalCenterWin = false; // No win on this line
                    break;
                }
            }

            if (verticalCenterWin)
            {
                Console.WriteLine($"\nCongratulations! You win on the center vertical line!");

                // Add win amount to the balance
                balance += Constants.CENTER_WIN;
            }
            if (!verticalCenterWin)
            {
                Console.WriteLine("\nYou did not win on the Vertical Center line");

                // Subtract the bet amount from the balance
                balance -= Constants.BET_AMOUNT;

            }
            
            return balance;
        }

        
        public static decimal HorizontalCenterWin()
        {
            decimal balance = 0;
            Console.WriteLine("\nPlay horizontal center line alone with $2: Earn $30.");

            bool middleHorizontalWin = true;

            // Check for a win on the second horizontal row
            for (int column = 1; column < slots_Output.GetLength(1); column++)
            {

                // Compare the current symbol to the previous symbol in the specified column
                if (slots_Output[1, column] != slots_Output[1, 0])
                {
                    middleHorizontalWin = false;
                    break;
                }
            }
            if (middleHorizontalWin)
            {
                Console.WriteLine($"\nCongratulations! You win on the horizontal middle line!");

                balance += Constants.FIRST_WIN; // Assuming $20 for a win on the first row
            }


            else
            {
                Console.WriteLine("\nYou did not win on the horizontal middle line");
                balance -= Constants.BET_AMOUNT;
            }

            // Display the updated balance
            Console.WriteLine($"\nYour current balance: ${balance}");
            return balance;


        }
        
        public static void InvalidBetting()
        {

            if (!horizontalWin && !verticalWin && !diagonalWin && !verticalCenterWin && !horizontalCenterWin && !diagonalCenterWin)

            {
                Console.WriteLine("\nInvalid betting option. Please try again.");
            }

        }
    }
}