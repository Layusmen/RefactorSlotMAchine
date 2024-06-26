﻿using System;
namespace RefactorSlotMachine
{
	internal class Logics
	{
		/// <summary>
		/// Random randomPickGenerator
		/// </summary>
		public readonly static Random randomPickGenerator = new Random();

		/// <summary>
		/// slot Symbols
		/// </summary>
		public static List<char> slotSymbols = new List<char> { 'A', '1', '5', '7', '$', 'M', '8', '9', '!', '#', 'Q', '&', 'C', 'S', 'Y', 'V', 'W', 'R', 'L', 'F' };

		/// <summary>
		/// Horizontal Win Check
		/// </summary>
		/// <returns></returns>
		public static decimal HorizontalWin()
		{
			decimal balance = 0;
			UIMethods.PrintHorizontalPlay();
			// check for a win on a specific horizontal line
			// set winCount to false 
			decimal winCount = 0;
			for (int row = 0; row < Program.slots_Output.GetLength(0); row++)
			{
				int matchValue = 1;

				for (int column = 1; column < Program.slots_Output.GetLength(1); column++)
				{
					// Compare the current symbol to the first symbol in the row
					if (Program.slots_Output[row, 0] == Program.slots_Output[row, column])
					{
						matchValue++;
					}
					else
					{
						break;
					}
				}

				if (matchValue == Program.slots_Output.GetLength(0))
				{
					winCount++;

				}

			}
			return HandleWinResults(winCount, balance);
		}

		/// <summary>
		/// Handles Horizontal Wins Results
		/// </summary>
		/// <param name="winCount"></param>
		/// <param name="balance"></param>
		/// <returns></returns>
		public static decimal HandleWinResults(decimal winCount, decimal balance)
		{
			if (winCount == 0)
			{
				UIMethods.PrintNoWin();
				//balance -= Constants.BET_AMOUNT;
			}
			else
			{
				(decimal winAmount, string winType) = CalculateWinDetails(winCount);
				balance += winAmount;
				UIMethods.PrintWinDetection(winType, winCount);
			}

			return balance;
		}

		/// <summary>
		/// Calculate Win Details
		/// </summary>
		/// <param name="winCount"></param>
		/// <returns></returns>
		public static (decimal winAmount, string winType) CalculateWinDetails(decimal winCount)
		{
			if (winCount == 1)
			{
				return (Constants.FIRST_WIN, Constants.SINGLE);
			}
			if (winCount == 2)
			{
				return (Constants.TWO_COMBINE_WIN, Constants.DOUBLE);
			}
            if(winCount == 3)

            {
				return (Constants.THREE_COMBINE_WIN, Constants.TRIPPLE);
			}
			return (0, "NoWin");

        }

		/// <summary>
		/// Vertical Win Check
		/// </summary>
		/// <returns></returns>
		public static decimal VerticalWin()
		{
			decimal balance = 0;
			UIMethods.PrintVerticalPlay();
			// check for a win on a specific horizontal line
			// set winCount to false 
			int winCount = 0;

			for (int column = 0; column < Program.slots_Output.GetLength(1); column++)
			{
				int matchValue = 1;

				for (int row = 1; row < Program.slots_Output.GetLength(0); row++)
				{
					// Compare the current symbol to the first symbol in the row
					if (Program.slots_Output[0, column] == Program.slots_Output[row, column])
					{
						matchValue++;
					}
					else
					{
						break;
					}
				}
				if (matchValue == Program.slots_Output.GetLength(0))
				{
					winCount++;
				}
			}
			decimal result = HandleWinResults(winCount, balance);
			return result;
		}

		/// <summary>
		/// Diagonal Win CHeck
		/// </summary>
		/// <returns></returns>
		public static decimal DiagonalWin()

		{
			//decimal balance = 0;
			UIMethods.PrintDiagonalPlay();

			//Check the main diagonal (top-left to bottom-right)
			bool isMainDiagonalWin = true;
			for (int i = 1; i < Constants.ROW_COUNT; i++)
			{
				if (Program.slots_Output[i, i] != Program.slots_Output[0, 0])
				{
					isMainDiagonalWin = false;
					break;
				}
			}

			//Check the secondary diagonal (top-right to bottom-left)
			bool isSecondaryDiagonalWin = true;
			for (int i = 1; i < Constants.ROW_COUNT; i++)
			{
				if (Program.slots_Output[i, Constants.ROW_COUNT - 1 - i] != Program.slots_Output[0, Constants.ROW_COUNT - 1])
				{
					isSecondaryDiagonalWin = false;
					break;
				}
			}

			return CheckDiagonalWin(isSecondaryDiagonalWin, isMainDiagonalWin);
		}
		
		/// <summary>
		/// Check Diagonal Win Logic
		/// </summary>
		/// <param name="isSecondaryDiagonalWin"></param>
		/// <param name="isMainDiagonalWin"></param>
		/// <returns></returns>
		public static decimal CheckDiagonalWin(bool isSecondaryDiagonalWin, bool isMainDiagonalWin)
		{
			decimal balance = 0;
			if (isSecondaryDiagonalWin && isMainDiagonalWin)
			{

				// Handle the case when there's a win on both diagonals
				UIMethods.PrintWinDetection();
				balance += Constants.CENTER_WIN; 
			}
			else if (isMainDiagonalWin)
			{
				UIMethods.PrintWinDetection();
				balance += Constants.FIRST_WIN;

			}

			else if (isSecondaryDiagonalWin)
			{
				UIMethods.PrintWinDetection();
				balance += Constants.FIRST_WIN;
			}
			else if (!isSecondaryDiagonalWin && !isMainDiagonalWin)
			{
				UIMethods.PrintNoWin();
				balance -= Constants.BET_AMOUNT;
			}

			else
			{
				UIMethods.PrintNoWin();
				balance -= Constants.BET_AMOUNT;
			}
			return balance;
		}

		/// <summary>
		/// Vertical Center Win Check
		/// </summary>
		/// <returns></returns>
		public static decimal VerticalCenterWin()
		{
			decimal balance = 0;
			UIMethods.PrintVerticalCenterPlay();

			// Check for a win on a specific vertical line
			bool verticalCenterWin = true;

			for (int row = 1; row < Program.slots_Output.GetLength(0); row++)
			{   // Compare the current symbol to the previous symbol in the specified column
				if (Program.slots_Output[row, 1] != Program.slots_Output[0, 1])
				{
					verticalCenterWin = false;
					break;
				}
			}

			if (verticalCenterWin)
			{
				UIMethods.PrintWinDetection();

				// Add win amount to the balance
				balance += Constants.CENTER_WIN;
			}
			if (!verticalCenterWin)
			{
				UIMethods.PrintNoWin();

			}

			return balance;
		}

		/// <summary>
		/// Horizontal Center Win Check
		/// </summary>
		/// <returns></returns>
		public static decimal HorizontalCenterWin()
		{
			decimal balance = 0;
			UIMethods.PrintHorizontalCenterPlay();
			bool middleHorizontalWin = true;
			// Check for a win on the second horizontal row
			for (int column = 1; column < Program.slots_Output.GetLength(1); column++)
			{
				// Compare the current symbol to the previous symbol in the specified column
				if (Program.slots_Output[1, column] != Program.slots_Output[1, 0])
				{
					middleHorizontalWin = false;
					break;
				}
			}
			if (middleHorizontalWin)
			{
				UIMethods.PrintMiddleHorizontalPlay();

				balance += Constants.FIRST_WIN; 
			}
			else
			{
				UIMethods.PrintNoWin();
				balance -= Constants.BET_AMOUNT;
			}
			return balance;
		}

		/// <summary>
		/// Check Bet Processes
		/// </summary>
		/// <param name="betSwitch"></param>
		/// <param name="balance"></param>
		public static decimal BetProcess(int betSwitch, decimal balance)
		{
				switch (betSwitch)
				{
					case Constants.HORIZONTAL_LINE:
						balance += HorizontalWin();
                        break;
					case Constants.VERTICAL_LINE:
						balance += VerticalWin();
						break;
					case Constants.DIAGONAL_LINE:
						balance += DiagonalWin();
						break;
					case Constants.VER_CENTER_LINE:
						balance += VerticalCenterWin();
						break;
					case Constants.HOR_CENTER_LINE:
						balance += HorizontalCenterWin();
						break;
				default:
						break;
				}
            return balance;
        }

        /// <summary>
        /// Check Game Over
        /// </summary>
        /// <param name="balance"></param>
        public static bool CheckGameOver(decimal balance)
        {
            if (balance < Constants.BET_AMOUNT)
            {
                UIMethods.PrintFundInsufficient();
                return true; 
            }
            return false; 
        }

        /// <summary>
		/// Slot Output Builder
		/// </summary>
		/// <returns></returns>
        public static char [,] SlotOutputBuilder()
        {
            char[,] slots_Output = new char[Constants.ROW_COUNT, Constants.COLUMN_COUNT];

            for (int row = 0; row < Constants.ROW_COUNT; row++)
            {
                for (int col = 0; col < Constants.COLUMN_COUNT; col++)
                {
					int randomIndex = randomPickGenerator.Next(slotSymbols.Count);
					Program.slots_Output[row, col] = slotSymbols[randomIndex];

					//Uncomment to text if the code runs fine without using random char generator.
					//Program.slots_Output = new char[,] { { '1', '0', '1' }, { '0', '1', '1' }, { '1', '1', '1' } };
                }
            }
            return slots_Output;
        }

		/// <summary>
		/// SlotOutPut Format
		/// </summary>
		/// <returns></returns>
        public static string FormatSlotOutput()
        {
            string output = "";
            for (int row = 0; row < Constants.ROW_COUNT; row++)
            {
                for (int col = 0; col < Constants.COLUMN_COUNT; col++)
                {
                    output += Program.slots_Output[row, col] + "\t";
                }
                output += "\n";
            }
            return output;
        }
    }
}