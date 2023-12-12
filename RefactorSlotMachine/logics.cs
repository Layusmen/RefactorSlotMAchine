using System;


namespace RefactorSlotMachine
{
    internal class logics
    {
        public static void BettingCheck()
        {

           

            //Check if the betting option is valid
            if (logics.bettingOption != constants.HORIZONTAL_LINE && logics.bettingOption != constants.VERTICAL_LINE && bettingOption != constants.HOR_CENTER_LINE && bettingOption != constants.VER_CENTER_LINE && bettingOption != constants.DIAGONAL_LINE)
            {
                Console.WriteLine("Invalid betting option. Please try again.");
                return;
            }

        }
    }
}
