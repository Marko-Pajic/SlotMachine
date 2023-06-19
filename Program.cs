﻿namespace SlotMachine
{
    internal class Program
    {
        public const int UPPER_BOUND = 5;
        public const int MINIMUM_WAGER = 1;
        public static readonly Random rng = new Random();
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to SlotMachine");
            Console.WriteLine("To play this game you are going to need to deposit certain amount of money");
            Console.WriteLine("Further you will be asked how much are you willing to play for after every spin");
            Console.WriteLine($"Minimun deposit and wager is {MINIMUM_WAGER} dollar");
            Console.WriteLine($"{MINIMUM_WAGER} dollar will give you opportunity to play one line");
            Console.WriteLine("As you increase the wager more lines will open continuing downwords horisontally,vertically and diagonally");
            Console.WriteLine("Spining time!");

            Console.WriteLine("Insert the deposit:");
            int cashDeposit = Convert.ToInt32(Console.ReadLine());
            while (cashDeposit >= MINIMUM_WAGER)
            {
                int[,] slotMachine = new int[3, 3];

                for (int i = 0; i < slotMachine.GetLength(0); i++) 
                {
                    for (int j = 0; j < slotMachine.GetLength(1); j++)
                    {
                        slotMachine[i, j] = rng.Next(1, 6);
                        Console.Write(" " + slotMachine[i, j] + " ");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine("How much is your wager:");
                int amountForPlaying = Convert.ToInt32(Console.ReadLine());
            }
        }
    }
}