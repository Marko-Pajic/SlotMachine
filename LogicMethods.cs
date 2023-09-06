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
            int result = cashDeposit * Program.CREDITS_ARTITHMETIC_VALUE;
            UIMethods.DisplayPlayingCredits(result);
            return result;
        }

        public static int[,] GenerateSlotMachineGrid()
        {
            Random rng = new Random();
            int[,] slotMachine = new int[Program.GRID_ROW_COUNT, Program.GRID_COLUMN_COUNT];

            for (int row = 0; row < Program.GRID_ROW_COUNT; row++)
            {
                for (int col = 0; col < Program.GRID_COLUMN_COUNT; col++)
                {
                    slotMachine[row, col] = rng.Next(1, Program.MAXIMAL_GRID_VALUE + 1);
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

                for (int col = 0; col < Program.GRID_COLUMN_COUNT; col++)
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

                for (int row = 0; row < Program.GRID_ROW_COUNT; row++)
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

            for (int i = 0; i < Program.GRID_ROW_COUNT; i++)
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

            for (int i = Program.GRID_COLUMN_COUNT; i > 0; i--)
            {
                int row = Math.Abs(i - Program.GRID_COLUMN_COUNT);
                int col = i - 1;
                int firstValueOfDLine = slotMachine[0, Program.GRID_COLUMN_COUNT - 1];

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
                cashDeposit = playingCredits / Program.CREDITS_ARTITHMETIC_VALUE;
                UIMethods.DisplayPaidOutAmount(cashDeposit);
                return true;
            } 
            else
            {
                UIMethods.DisplayContinueMessage();
                return false;
            }
        }

        //public static int MainAlgorythm(int cashDeposit, int playingCredits)
        //{

        //}
    }
}
