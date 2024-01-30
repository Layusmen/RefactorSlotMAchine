using System;
using System.Data.SqlTypes;
using RefactorSlotMachine;

namespace RefactorSlotMachine
{
	internal class Logics
	{

		/// <summary>
		/// slots_Output
		/// </summary>
		public static char[,] slots_Output = new char[Constants.ROW_COUNT, Constants.COLUMN_COUNT];

		/// <summary>
		/// Random randomPickGenerator
		/// </summary>
		public readonly static Random randomPickGenerator = new Random();

		/// <summary>
		/// slotSymbols
		/// </summary>
		public static List<char> slotSymbols = new List<char> { 'A', '1', '5', '7', '$', 'M', '8', '9', '!', '#', 'Q', '&', 'C', 'S', 'Y', 'V', 'W', 'R', 'L', 'F' };


		/// <summary>
		/// Horizontal Win Check
		/// </summary>
		/// <returns></returns>
		public static decimal HorizontalWin()
		{
			
			decimal balance = 0;

			UIMethods.HorizontalPlayPrint();
			// check for a win on a specific horizontal line
			// set winCount to false 
			decimal winCount = 0;
			for (int row = 0; row < slots_Output.GetLength(0); row++)
			{
				int matchValue = 1;

				for (int column = 1; column < slots_Output.GetLength(1); column++)
				{
					// Compare the current symbol to the first symbol in the row
					if (slots_Output[row, 0] == slots_Output[row, column])
					{
						matchValue++;
					}
					else
					{
						break;
					}
				}

				if (matchValue == slots_Output.GetLength(0))
				{
					winCount++;

				}

			}
			return Logics.HorizontalHandleWinResults(winCount, balance);
		}


		/// <summary>
		/// Handles Horizontal Wins Results
		/// </summary>
		/// <param name="winCount"></param>
		/// <param name="balance"></param>
		/// <returns></returns>
		public static decimal HorizontalHandleWinResults(decimal winCount, decimal balance)
		{
			if (winCount == 0)
			{
				UIMethods.NoWinPrint();
				//balance -= Constants.BET_AMOUNT;
			}
			else
			{
				(decimal winAmount, string winType) = Logics.CalculateWinDetails(winCount);
				balance += winAmount;
				UIMethods.WinDetectionPrint(winType, winCount);
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
			else if (winCount == 2)
			{
				return (Constants.TWO_COMBINE_WIN, Constants.DOUBLE);
			}
			else
			{
				return (Constants.THREE_COMBINE_WIN, Constants.TRIPPLE);
			}
		}



		/// <summary>
		/// Vertical Win Check
		/// </summary>
		/// <returns></returns>
		public static decimal VerticalWin()
		{
			decimal balance = 0;
			UIMethods.VerticalPlayPrint();
			// check for a win on a specific horizontal line
			// set winCount to false 
			int winCount = 0;

			for (int column = 0; column < slots_Output.GetLength(1); column++)
			{
				int matchValue = 1;

				for (int row = 1; row < slots_Output.GetLength(0); row++)
				{
					// Compare the current symbol to the first symbol in the row
					if (slots_Output[0, column] == slots_Output[row, column])
					{
						matchValue++;
					}
					else
					{
						break;
					}
				}

				if (matchValue == slots_Output.GetLength(0))
				{
					winCount++;

				}

			}
			decimal result = Logics.VerticalHandleWinResults(winCount, balance);
			return result;
		}

		/// <summary>
		/// Diagonal Win CHeck
		/// </summary>
		/// <returns></returns>
		public static decimal DiagonalWin()

		{
			decimal balance = 0;
			UIMethods.DiagonalPlayPrint();

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
				UIMethods.WinDetectionPrint();
				balance += Constants.CENTER_WIN; // Assuming $20 for a win on the first row
			}
			else if (isMainDiagonalWin)
			{
				UIMethods.WinDetectionPrint();
				balance += Constants.FIRST_WIN; // Assuming $20 for a win on the first row

			}

			else if (isSecondaryDiagonalWin)
			{
				UIMethods.WinDetectionPrint();
				balance += Constants.FIRST_WIN; // Assuming $20 for a win on the first row
			}
			else if (!isSecondaryDiagonalWin && !isMainDiagonalWin)
			{
				UIMethods.NoWinPrint();
				balance -= Constants.BET_AMOUNT;
			}

			else
			{
				UIMethods.NoWinPrint();
				balance -= Constants.BET_AMOUNT; // Subtract the bet amount from the balance if no win is detected on any of the diagonal lines.
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
			UIMethods.VerticalCenterPlayPrint();

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
				UIMethods.WinDetectionPrint();

				// Add win amount to the balance
				balance += Constants.CENTER_WIN;
			}
			if (!verticalCenterWin)
			{
				UIMethods.NoWinPrint();

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
			UIMethods.HorizontalCenterPlayPrint();

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
				UIMethods.MiddleHorizontalPlayPrint();

				balance += Constants.FIRST_WIN; // Assuming $20 for a win on the first row
			}
			else
			{
				UIMethods.NoWinPrint();
				balance -= Constants.BET_AMOUNT;
			}
			return balance;
		}

		/// <summary>
		/// Check Bet Processes
		/// </summary>
		/// <param name="betSwitch"></param>
		/// <param name="balance"></param>
	   
		public static decimal MyBetProcess(int betSwitch, decimal balance)
		{
			switch (betSwitch)
			{
				case Constants.HORIZONTAL_LINE:
					balance += Logics.HorizontalWin();
					break;

                case Constants.VERTICAL_LINE:
					balance += Logics.VerticalWin();
					break;
				case Constants.DIAGONAL_LINE:
					balance += Logics.DiagonalWin();
					break;
				case Constants.VER_CENTER_LINE:
					balance += Logics.VerticalCenterWin();
					break;
				case Constants.HOR_CENTER_LINE:
					balance += Logics.HorizontalCenterWin();
					break;
				default:
					UIMethods.InvalidValuePrint();
					break;
			}

			return balance;
		}


		/// <summary>
		/// Handles Horizontal Win Result
		/// </summary>
		/// <param name="winCount"></param>
		/// <param name="balance"></param>
		/// <returns></returns>
		public static decimal VerticalHandleWinResults(decimal winCount, decimal balance)
		{
			if (winCount == 0)
			{
				UIMethods.NoWinPrint ();
				balance -= Constants.BET_AMOUNT;
			}
			else
			{
				(decimal winAmount, string winType) = Logics.CalculateWinDetails(winCount);  // Call the new function
				balance += winAmount;
				UIMethods.WinDetectionPrint(winType, winCount);
			}

			return balance;
		}


		/// <summary>
		/// Check if Game Over Due to Insufficient Fund
		/// </summary>
		/// <param name="balance"></param>
		public static void CheckGameOver(decimal balance)
		{
			if (balance < Constants.BET_AMOUNT)
			{
				UIMethods.FundInsufficientPrint();
				Environment.Exit(0);
			}

		}

	}
}