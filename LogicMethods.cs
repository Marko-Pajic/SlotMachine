using SlotMachine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlotMachine
{
    public static class LogicMethods
    {
        public static int CalculatePlayingCredits(int cashDeposit)
        {
            int result = cashDeposit * Constants.CREDITS_ARTITHMETIC_VALUE;
            UIMethods.DisplayPlayingCredits(result);
            return result;
        }

        public static int[,] GenerateSlotMachineGrid()
        {
            Random rng = new Random();
            int[,] slotMachine = new int[Constants.GRID_ROW_COUNT, Constants.GRID_COLUMN_COUNT];

            for (int row = 0; row < Constants.GRID_ROW_COUNT; row++)
            {
                for (int col = 0; col < Constants.GRID_COLUMN_COUNT; col++)
                {
                    slotMachine[row, col] = rng.Next(1, Constants.MAXIMAL_GRID_VALUE + 1);
                    UIMethods.DisplayGrid(slotMachine, row, col);
                }
                UIMethods.AddEmptyLine();
            }
            return slotMachine;
        }

        public static int SearchRows(int numberOfRowsToCheck, int[,] slotMachine)
        {
            int winningLines = 0;

            for (int row = 0; row < numberOfRowsToCheck; row++)
            {
                bool allValuesAreEqual = true;
                int firstValueOfRLine = slotMachine[row, 0];

                for (int col = 0; col < Constants.GRID_COLUMN_COUNT; col++)
                {
                    if (firstValueOfRLine != slotMachine[row, col])
                    {
                        allValuesAreEqual = false;
                        break;
                    }
                    UIMethods.AddEmptyLine();
                }

                if (allValuesAreEqual)
                {
                    winningLines++;
                    UIMethods.DisplayWinningMessage();
                }
            }
            return winningLines;
        }

        public static int SearchColumns(int numberOfColumnsToCheck, int[,] slotMachine)
        {
            int winningLines = 0;

            for (int col = 0; col < numberOfColumnsToCheck; col++)
            {
                int firstValueOfCLine = slotMachine[0, col];
                bool allValuesAreEqual = true;

                for (int row = 0; row < Constants.GRID_ROW_COUNT; row++)
                {
                    if (firstValueOfCLine != slotMachine[row, col])
                    {
                        allValuesAreEqual = false;
                        break;
                    }
                    UIMethods.AddEmptyLine();
                }

                if (allValuesAreEqual)
                {
                    winningLines++;
                    UIMethods.DisplayWinningMessage();
                }
            }
            return winningLines;
        }

        public static int SearchFirstDiagonal(int[,] slotMachine)
        {
            bool allValuesAreEqual = true;
            int winningLines = 0;

            for (int i = 0; i < Constants.GRID_ROW_COUNT; i++)
            {
                int firstValueOfDLine = slotMachine[0, 0];

                if (firstValueOfDLine != slotMachine[i, i])
                {
                    allValuesAreEqual = false;
                    break;
                }
            }

            if (allValuesAreEqual)
            {
                winningLines++;
                UIMethods.DisplayWinningMessage();
            }

            return winningLines;
        }

        public static int SearchSecondDiagonal(int[,] slotMachine)
        {
            bool allValuesAreEqual = true;
            int winningLines = 0;

            for (int i = Constants.GRID_COLUMN_COUNT; i > 0; i--)
            {
                int row = Math.Abs(i - Constants.GRID_COLUMN_COUNT);
                int col = i - 1;
                int firstValueOfDLine = slotMachine[0, Constants.GRID_COLUMN_COUNT - 1];

                if (firstValueOfDLine != slotMachine[row, col])
                {
                    allValuesAreEqual = false;
                    break;
                }
            }

            if (allValuesAreEqual)
            {
                winningLines++;
                UIMethods.DisplayWinningMessage();
            }

            return winningLines;
        }

        public static bool GameEndingDecision(int cashDeposit, int playingCredits)
        {

            UIMethods.DisplayCashOutInquiry();
            string cashMeOut = Console.ReadLine().ToLower();

            if (cashMeOut == "y")
            {
                cashDeposit = playingCredits / Constants.CREDITS_ARTITHMETIC_VALUE;
                UIMethods.DisplayPaidOutAmount(cashDeposit);
                return false;
            }
            else
            {
                UIMethods.DisplayContinueMessage();
                return true;
            }
        }

        public static int SearchingWinningCombination(int wagerAmount, int allRowsandColsChecked, int[,] slotMachine)
        {
            int winningLinesCount = 0;

            if (wagerAmount >= Constants.MINIMUM_WAGER)
            {
                int numberOfRowsToCheck = Math.Min(wagerAmount, Constants.GRID_ROW_COUNT);

                winningLinesCount += LogicMethods.SearchRows(numberOfRowsToCheck, slotMachine);
            }

            if (wagerAmount > Constants.GRID_ROW_COUNT)
            {
                int numberOfColumnsToCheck = Math.Min(wagerAmount - Constants.GRID_ROW_COUNT, Constants.GRID_ROW_COUNT);

                winningLinesCount += LogicMethods.SearchColumns(numberOfColumnsToCheck, slotMachine);
            }

            if (wagerAmount > allRowsandColsChecked)
            {
                winningLinesCount += LogicMethods.SearchFirstDiagonal(slotMachine);
            }

            if (wagerAmount == Constants.MAXIMUM_WAGER)
            {
                winningLinesCount += LogicMethods.SearchSecondDiagonal(slotMachine);
            }

            return winningLinesCount;
        }
    }
}
