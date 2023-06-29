﻿using System.Runtime.CompilerServices;

namespace SlotMachine
{
    internal class Program
    {
        public const int UPPER_BOUND = 6;
        public const int MINIMUM_WAGER = 1;
        public const int MAXIMUM_WAGER = 8;
        public const int GRID_ROW = 3;
        public const int GRID_COLUMN = 3;
        public static readonly Random rng = new Random();
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to SlotMachine");
            Console.WriteLine("To play this game you are going to need to deposit certain amount of money");
            Console.WriteLine("Further you will be asked how much are you willing to play for after every spin");
            Console.WriteLine($"Minimun deposit and wager is {MINIMUM_WAGER} dollar");
            Console.WriteLine($"{MINIMUM_WAGER} dollar will give you opportunity to play one line");
            Console.WriteLine("As you increase the wager more lines will open continuing downwords horisontally,vertically and diagonally");
            Console.WriteLine($"{MAXIMUM_WAGER} dollars is a maximum as it gives you oportunity to play all possible lines");
            Console.WriteLine("Spining time!");

            Console.WriteLine("Insert the deposit:");
            int cashDeposit = Convert.ToInt32(Console.ReadLine());
            while (cashDeposit >= MINIMUM_WAGER)
            {
                int[,] slotMachine = new int[GRID_ROW, GRID_COLUMN];

                for (int row = 0; row < slotMachine.GetLength(0); row++)
                {
                    for (int col = 0; col < slotMachine.GetLength(1); col++)
                    {
                        slotMachine[row, col] = rng.Next(1, UPPER_BOUND);
                        Console.Write(" " + slotMachine[row, col] + " ");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine("How much is your wager:");
                int wagerAmount = Convert.ToInt32(Console.ReadLine());
                int allRowsandColsChecked = GRID_ROW + GRID_COLUMN;
                if (wagerAmount <= allRowsandColsChecked)
                {
                    int numberOfRowsToCheck = Math.Min(wagerAmount, GRID_ROW);
                    for (int row = 0; row < numberOfRowsToCheck; row++)
                    {
                        for (int col = 0; col < GRID_COLUMN; col++)
                        {
                            Console.Write(" " + slotMachine[row, col] + " ");
                            if (slotMachine[row, col + col] == slotMachine[row, col - col] && slotMachine[row, col] == slotMachine[row, col + col])
                            {
                                cashDeposit++;
                            }
                            Console.WriteLine();
                        }
                        //            Console.WriteLine("YES");
                        //        }
                        //    }
                    }
                    if (wagerAmount > GRID_COLUMN && wagerAmount <= allRowsandColsChecked)
                    {
                        int numberOfColumnsToCheck = wagerAmount - GRID_COLUMN;
                        for (int col = 0; col < numberOfColumnsToCheck; col++)
                        {
                            for (int row = 0; row < GRID_ROW; row++)
                            {
                                Console.Write(" " + slotMachine[row, col] + " ");

                            }
                            Console.WriteLine();
                        }

                        //        if (slotMachine[0, j] == slotMachine[1, j] && slotMachine[1, j] == slotMachine[2, j])
                        //        {
                        //            Console.WriteLine("NO");
                        //        }
                        //    }
                        //}
                        //if (amountForPlaying > UPPER_BOUND && amountForPlaying <= MAXIMUM_WAGER)
                        {

                        }
                    }
                }
            }
        }
    }
}