﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlotMachine
{
    public static class LogicMethods
    {
        public static int CalculatePlayingCredits(int cashDeposit, int constnant)
        {
            int result = cashDeposit * constnant;
            Console.WriteLine($"\nPlaying credits = {result}\n");
            return result;
        }

        public static int[,] GenerateSlotMachineGrid(int gridRow, int gridColumn, int upperBound)
        {
            Random rng = new Random();
            int[,] slotMachine = new int[gridRow, gridColumn];

            for (int row = 0; row < gridRow; row++)
            {
                for (int col = 0; col < gridColumn; col++)
                {
                    slotMachine[row, col] = rng.Next(1, upperBound);
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

                for (int col = 0; col < Program.GRID_COLUMN; col++)
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

                for (int row = 0; row < Program.GRID_ROW; row++)
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
    }
}