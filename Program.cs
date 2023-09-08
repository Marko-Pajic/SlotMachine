﻿namespace SlotMachine
{
    internal class Program
    {
        public const int MAXIMAL_GRID_VALUE = 5;
        public const int MINIMUM_WAGER = 1;
        public const int MAXIMUM_WAGER = 8;
        public const int GRID_ROW_COUNT = 3;
        public const int GRID_COLUMN_COUNT = 3;
        public const int CREDITS_ARTITHMETIC_VALUE = 5;
        public static readonly Random rng = new Random();
        static void Main(string[] args)
        {
            UIMethods.DisplayIntroAndRules();

            int cashDeposit = UIMethods.ConvertStringToInt();
            int playingCredits = LogicMethods.CalculatePlayingCredits(cashDeposit);

            int allRowsandColsChecked = GRID_ROW_COUNT + GRID_COLUMN_COUNT;

            while (playingCredits >= MINIMUM_WAGER)
            {
                UIMethods.DisplayWagerInquiry();
                int wagerAmount = UIMethods.ConvertStringToInt();

                if (wagerAmount > MAXIMUM_WAGER)
                {
                    UIMethods.DisplayInvalidInput();
                    break;
                }

                if (playingCredits < MAXIMUM_WAGER)
                {
                    wagerAmount = Math.Min(playingCredits, wagerAmount);
                }

                playingCredits -= wagerAmount;

                int[,] slotMachine = LogicMethods.GenerateSlotMachineGrid();

                int winningLinesCount = LogicMethods.SearchingWinningCombination(wagerAmount, allRowsandColsChecked, slotMachine);

                UIMethods.DisplayPlayingOutcome(winningLinesCount);

                winningLinesCount *= winningLinesCount;
                playingCredits += winningLinesCount;

                UIMethods.DisplayCurrentCredits(playingCredits);
                bool gameOver = false;

                if (playingCredits > 0)
                {
                   gameOver = LogicMethods.GameEndingDecision(cashDeposit, playingCredits);
                }
                if (gameOver == true)
                {
                    break;
                }
            }
            UIMethods.DisplayEndingMessage();
        }

    }

}