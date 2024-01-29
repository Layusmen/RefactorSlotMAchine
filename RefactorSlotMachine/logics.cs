using System;
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
        /// HorizontalWin
        /// </summary>
        /// <returns></returns>
        public static decimal HorizontalWin()
        {
            
            decimal balance = 0;

            UIMethods.HorizontalPlay();
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
            decimal result = UIMethods.HorizontalHandleWinResults(winCount, balance);
            return result;
        }

        public static (decimal winAmount, string winType) CalculateWinDetails(decimal winCount)
        {
            if (winCount == 1)
            {
                return (Constants.FIRST_WIN, "Single");
            }
            else if (winCount == 2)
            {
                return (Constants.TWO_COMBINE_WIN, "Double");
            }
            else
            {
                return (Constants.THREE_COMBINE_WIN, "Triple");
            }
        }
        
        
        
        /// <summary>
        /// VerticalWin
        /// </summary>
        /// <returns></returns>
        public static decimal VerticalWin()
        {
            decimal balance = 0;
            UIMethods.VerticalPlay();
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
            decimal result = UIMethods.VerticalHandleWinResults(winCount, balance);
            return result;
        }

        /// <summary>
        /// DiagonalWin
        /// </summary>
        /// <returns></returns>
        public static decimal DiagonalWin()

        {
            decimal balance = 0;
            UIMethods.DiagonalPlay();

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
                UIMethods.WinDetected();
                balance += Constants.CENTER_WIN; // Assuming $20 for a win on the first row
            }
            else if (isMainDiagonalWin)
            {
                UIMethods.WinDetected();
                balance += Constants.FIRST_WIN; // Assuming $20 for a win on the first row

            }

            else if (isSecondaryDiagonalWin)
            {
                UIMethods.WinDetected();
                balance += Constants.FIRST_WIN; // Assuming $20 for a win on the first row
            }
            else if (!isSecondaryDiagonalWin && !isMainDiagonalWin)
            {
                UIMethods.NoWinDetected();
                balance -= Constants.BET_AMOUNT;
            }

            else
            {
                UIMethods.NoWinDetected();
                balance -= Constants.BET_AMOUNT; // Subtract the bet amount from the balance if no win is detected on any of the diagonal lines.
            }
            return balance;
        }

        /// <summary>
        /// VerticalCenterWin
        /// </summary>
        /// <returns></returns>
        public static decimal VerticalCenterWin()
        {
            decimal balance = 0;
            UIMethods.VerticalCenterPlay();

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
                UIMethods.WinDetected();

                // Add win amount to the balance
                balance += Constants.CENTER_WIN;
            }
            if (!verticalCenterWin)
            {
                UIMethods.NoWinDetected();

            }
            
            return balance;
        }

        /// <summary>
        /// HorizontalCenterWins
        /// </summary>
        /// <returns></returns>
        public static decimal HorizontalCenterWin()
        {
            decimal balance = 0;
            UIMethods.HorizontalCenterPlay();

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
                UIMethods.MiddleHorizontalPlay();

                balance += Constants.FIRST_WIN; // Assuming $20 for a win on the first row
            }
            else
            {
                UIMethods.NoWinDetected();
                balance -= Constants.BET_AMOUNT;
            }
            return balance;
        }

        public static void MyBetProcess(int myBet, decimal balance)
        {
            switch (myBet)
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
                    UIMethods.InvalidValue();
                    return;
            }
        }

    }
}