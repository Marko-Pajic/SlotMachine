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
        /// <summary>
        /// multiplies int and constant
        /// </summary>
        /// <param name="cashDeposit">takes a value</param>
        /// <returns>the product of int and constant</returns>
        public static int CalculatePlayingCredits(int cashDeposit)
        {
            int result = cashDeposit * Constants.CREDITS_ARTITHMETIC_VALUE;
            UIMethods.DisplayPlayingCredits(result);
            return result;
        }

        /// <summary>
        /// Creates 2d array filled with random numbers
        /// </summary>
        /// <returns>2d array</returns>
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

        /// <summary>
        /// Loops through 2d array searching for rows\lines with same numbers
        /// </summary>
        /// <param name="numberOfRowsToCheck">takes a int</param>
        /// <param name="slotMachine">takes a 2d array</param>
        /// <returns>number of rows\lines that contain same number</returns>
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

        /// <summary>
        /// Loops through 2d array searching for columns\lines with same numbers
        /// </summary>
        /// <param name="numberOfColumnsToCheck">takes an int</param>
        /// <param name="slotMachine">takes a 2d array</param>
        /// <returns>number of columns\lines that contain same number</returns>
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

        /// <summary>
        /// Loops through 2d array searching for row and column positions with same numbers
        /// </summary>
        /// <param name="slotMachine">takes a 2d array</param>
        /// <returns>number of diagonal lines made of array positions that contain same number</returns>
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

        /// <summary>
        /// Loops through 2d array searching for row and column positions with same numbers
        /// </summary>
        /// <param name="slotMachine">takes a 2d array</param>
        /// <returns>number of diagonal lines made of array positions that contain same number</returns>
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

        /// <summary>
        /// Asks user to decide to either quit or continue playing
        /// </summary>
        /// <param name="cashDeposit">displays a number</param>
        /// <param name="playingCredits">divides a number</param>
        /// <returns>boolean depending on players choice</returns>
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

        /// <summary>
        /// Groups all methods that loops through 2d array searching for winning lines depending on how much player waged
        /// </summary>
        /// <param name="wagerAmount">takes a int</param>
        /// <param name="allRowsandColsChecked">takes a int</param>
        /// <param name="slotMachine">takes a 2d array</param>
        /// <returns>overall number of lines that contain same number</returns>
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
