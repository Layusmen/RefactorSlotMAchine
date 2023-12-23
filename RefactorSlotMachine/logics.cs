using System;
using System.Collections.Generic;
using Microsoft.VisualBasic;
using RefactorSlotMachine;
using System;
using System.Security.Cryptography.X509Certificates;

namespace RefactorSlotMachine
{
    internal class logics
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

        //Random Value Generator
        public static List<char> slotSymbols = new List<char> { 'A', '1', '5', '7', '$', 'M', '8', '9', '!', '#', 'Q', '&', 'C', 'S', 'Y', 'V', 'W', 'R', 'L', 'F' };

        //Horizonal win  Check
        public static void HorizontalWin(decimal balance, decimal FIRST_WIN, decimal SECOND_WIN, decimal BET_AMOUNT)

        {
            //Horizonal win option

            Console.WriteLine("\nYou chose to play all three horizontal lines with $2: Earn $20 for top line wins, $5 for middle or base line wins.");

            // check for a win on a specific horizontal line
            bool horizontalWin = false; // set win to false 

            for (int row = 0; row < slots_Output.GetLength(0); row++)
            {
                for (int column = 1; column < slots_Output.GetLength(1); column++)
                {
                    // Compare the current symbol to the first symbol in the row
                    if (slots_Output[row, 0] != slots_Output[row, column])
                    {
                        // set to false
                        horizontalWin = false; // No win on this line
                        break;
                    }
                    horizontalWin = true; // Set to true 
                }

                // Check if there is a win on this row
                if (horizontalWin)
                {
                    Console.WriteLine($"\nCongratulations! You win on the {(row == 0 ? "left" : (row == 1 ? "middle" : "right"))} Horizontal line!");

                    // Update balance
                    if (row == 0)
                    {
                        balance += FIRST_WIN;
                    }
                    else
                    {
                        balance += SECOND_WIN;
                    }
                    break;
                }
            }

            // If horizontalWin is still false, there is no win on any row
            if (!horizontalWin)
            {
                Console.WriteLine($"\nYou did not win on the Horizontal lines!");

                // Subtract the bet amount from the balance
                balance -= BET_AMOUNT;
            }

            // Display the updated balance
            Console.WriteLine($"\nYour current balance: ${balance}");
        }

        //Check for a win on vertical lines
        public static void VerticalWin(decimal balance, decimal FIRST_WIN, decimal SECOND_WIN, decimal BET_AMOUNT)
        {

            Console.WriteLine("\nPlay all vertical lines with $2: Earn $20 for first line wins, $5 for second or third line wins.");


            bool verticalWin = true;

            // Function to check for a win on the specific vertical lines
            for (int column = 0; column < slots_Output.GetLength(1); column++)
            {
                for (int row = 1; row < slots_Output.GetLength(0); row++)
                {
                    // Compare the current symbol to the first symbol in the column
                    if (slots_Output[0, column] != slots_Output[row, column])
                    {
                        // If any symbol is different, set the flag to false and break
                        verticalWin = false; // No win on this line
                        break;
                    }
                }

                // If verticalWin is true, there is a win on this column
                if (verticalWin)
                {
                    Console.WriteLine($"\nCongratulations! You win on the {(column == 0 ? "top" : (column == 1 ? "middle" : "bottom"))} horizontal line!");

                    // Update balance
                    if (column == 0)
                    {
                        balance += FIRST_WIN;
                    }
                    else
                    {
                        balance += SECOND_WIN;
                    }
                }

            }

            if (!verticalWin)
            {
                Console.WriteLine("\nYou did not win on the vertical line!");

                // Subtract the bet amount from the balance
                balance -= BET_AMOUNT;
            }

            // Display the updated balance
            Console.WriteLine($"\nYour current balance: ${balance}");
        }

        //Check for a win on the Diagonal lines.
        public static void DiagonalWin(decimal balance, decimal FIRST_WIN, decimal BET_AMOUNT, decimal CENTER_WIN)

        {
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
                balance += FIRST_WIN; // Assuming $20 for a win on the first row
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
                balance += CENTER_WIN; // Assuming $20 for a win on the first row
            }
            else if (isSecondaryDiagonalWin)
            {
                Console.WriteLine("\nWin Detected on Secondary Diagonal");
                balance += FIRST_WIN; // Assuming $20 for a win on the first row
            }
            else if (!isSecondaryDiagonalWin && !isMainDiagonalWin)
            {
                Console.WriteLine("\nNo win Detected on any of the Diagonal lines");
                balance -= BET_AMOUNT;
            }

            else
            {
                Console.WriteLine("\nNo win Detected on any of the Diagonal lines");
                balance -= BET_AMOUNT; // Subtract the bet amount from the balance if no win is detected on any of the diagonal lines.
            }

            // Display the updated balance
            Console.WriteLine($"\nYour current balance: ${balance}");
        }
        
        ///Check for a win on the Vertical Center line 
        public static void VerticalCenterWin(decimal balance, decimal FIRST_WIN, decimal BET_AMOUNT, decimal CENTER_WIN)
        {

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
                balance += CENTER_WIN;
            }
            if (!verticalCenterWin)
            {
                Console.WriteLine("\nYou did not win on the Vertical Center line");

                // Subtract the bet amount from the balance
                balance -= BET_AMOUNT;

            }
            // Display the updated balance
            Console.WriteLine($"\nYour current balance: ${balance}");
        }

        //Check for a win on Horizontal Center line.
        public static void HorizontalCenterWin(decimal balance, decimal FIRST_WIN, decimal BET_AMOUNT, decimal CENTER_WIN)
        {

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

                balance += FIRST_WIN; // Assuming $20 for a win on the first row
            }


            else
            {
                Console.WriteLine("\nYou did not win on the horizontal middle line");
                balance -= BET_AMOUNT;
            }

            // Display the updated balance
            Console.WriteLine($"\nYour current balance: ${balance}");


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