﻿
using System;
namespace RefactorSlotMachine
{
    public class Constants
    {
        //Constants
        public const char HORIZONTAL_LINE = 'A';
        public const char VERTICAL_LINE = 'H';
        public const char HOR_CENTER_LINE = 'V';
        public const char VER_CENTER_LINE = 'C';
        public const char DIAGONAL_LINE = 'D';
        public const char CAPITALYES = 'Y';
        public const char SMALLYES = 'y';

        public const string SINGLE = "Single";
        public const string DOUBLE = "Double";
        public const string TRIPPLE = "Tripple";

        public const int ROW_COUNT = 3;
        public const int COLUMN_COUNT = 3;

        public const decimal BET_AMOUNT = 2.00M;
        public const decimal INITIAL_BALANCE = 10.00M;
        public const decimal FIRST_WIN = 20.00M;
        public const decimal TWO_COMBINE_WIN = 40.00M;
        public const decimal CENTER_WIN = 30.00M;
        public const decimal THREE_COMBINE_WIN = 60.00M;

        public const decimal SECOND_WIN = 10.00M;

        public List<char> bettingOptions = new List<char>()
        {
            HORIZONTAL_LINE,
            VERTICAL_LINE,
            HOR_CENTER_LINE,
            VER_CENTER_LINE,
            DIAGONAL_LINE
        };
    }
}