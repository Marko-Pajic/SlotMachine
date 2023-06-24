using System.Runtime.CompilerServices;

namespace SlotMachine
{
    internal class Program
    {
        public const int UPPER_BOUND = 5;
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
                for (int i = 0; i < Math.Min(amountForPlaying, GRID_ROW); i++)
                {
                    if (slotMachine[i, 0] == slotMachine[i, 1] && slotMachine[i, 1] == slotMachine[i, 2])
                    {
                        Console.WriteLine("Similar numbers found in row " + (i + 1));
                    }
                }

             
                for (int j = 0; j < Math.Min(amountForPlaying, GRID_COLUMN); j++)
                {
                    if (slotMachine[0, j] == slotMachine[1, j] && slotMachine[1, j] == slotMachine[2, j])
                    {
                        Console.WriteLine("Similar numbers found in column " + (j + 1));
                    }
                }
                //for (int i = 0; i < amountForPlaying; i++)
                //{
                //    if (slotMachine[i, 0] == slotMachine[i, 1] && slotMachine[i, 1] == slotMachine[i, 2])
                //    {
                //        Console.WriteLine("YES");
                //    }
                //    for (int j = 0; j < GRID_COLUMN; j++)
                //    {
                //        if (slotMachine[0, j] == slotMachine[1, j] && slotMachine[1, j] == slotMachine[2, j])
                //        {
                //            Console.WriteLine("NO");
                //        }
                //        Console.Write(" " + slotMachine[i, j] + " ");
                //    }
                //}
            }
        }
    }
}