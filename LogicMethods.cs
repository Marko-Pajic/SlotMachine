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
            Console.WriteLine($"\nPlaying credits = {result}\n");
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
                    Console.Write("\t " + slotMachine[row, col] + " ");
                }
                Console.WriteLine();
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
                    Console.WriteLine();
                }

                if (allValuesAreEqual)
                {
                    winningLines++;
                    Console.WriteLine("Win!\n");
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
                    Console.WriteLine();
                }

                if (allValuesAreEqual)
                {
                    winningLines++;
                    Console.WriteLine("Win!\n");
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
                Console.WriteLine("Win!\n");
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
                Console.WriteLine("Win!\n");
            }

            return winningLines;
        }

        public static bool SearchTruth(int cashDeposit, int playingCredits)
        {

            Console.WriteLine("Do you want to cash out?");
            string cashMeOut = Console.ReadLine().ToLower();

            if (cashMeOut == "y")
            {
                cashDeposit = playingCredits / Program.CREDITS_ARTITHMETIC_VALUE;
                Console.WriteLine($"Your money total {cashDeposit}$ will be paid out now.\n");
                Console.WriteLine("Thank you for playing!\n");
                return true;
            } 
            else
            {
                Console.WriteLine("Lets continue!\n");
                return false;
            }
        }
    }
}
