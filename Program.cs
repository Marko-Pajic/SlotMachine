using System.Runtime.CompilerServices;

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
                int[,] slotMachine = new int[,] { { 1, 2, 3 },
                                                  { 4, 5, 6 },
                                                  { 7, 8, 9 } };//[GRID_ROW, GRID_COLUMN];

                //for (int row = 0; row < slotMachine.GetLength(0); row++)
                //{
                //    for (int col = 0; col < slotMachine.GetLength(1); col++)
                //    {
                //        slotMachine[row, col] = rng.Next(1, UPPER_BOUND);
                //        Console.Write(" " + slotMachine[row, col] + " ");
                //    }
                //    Console.WriteLine();
                //}
                Console.WriteLine("How much is your wager:");
                int wagerAmount = Convert.ToInt32(Console.ReadLine());
                int allRowsandColsChecked = GRID_ROW + GRID_COLUMN;
                if (wagerAmount >= MINIMUM_WAGER && wagerAmount <= MAXIMUM_WAGER)
                {
                    int numberOfRowsToCheck = Math.Min(wagerAmount, GRID_ROW);
                    for (int row = 0; row < numberOfRowsToCheck; row++)
                    {
                        bool allValuesAreEqual = true;
                        int firstValueOfRLine = slotMachine[row, 0];
                        for (int col = 0; col < GRID_COLUMN; col++)
                        {
                            Console.Write(" " + slotMachine[row, col] + " ");
                            if (firstValueOfRLine != slotMachine[row, col])
                            {
                                allValuesAreEqual = false;
                                break;
                            }
                            Console.WriteLine();
                        }
                        if (allValuesAreEqual)
                        {
                            cashDeposit++;
                            Console.WriteLine("Win!");
                        }
                        else
                        {
                            cashDeposit--;
                            Console.WriteLine("Lose!");
                        }
                    }
                    Console.WriteLine(cashDeposit);
                }
                if (wagerAmount > GRID_ROW && wagerAmount <= MAXIMUM_WAGER)
                {
                    int numberOfColumnsToCheck = Math.Min(wagerAmount - GRID_ROW, GRID_ROW);
                    for (int col = 0; col < numberOfColumnsToCheck; col++)
                    {
                        int firstValueOfCLine = slotMachine[0, col];
                        bool allValuesAreEqual = true;
                        for (int row = 0; row < GRID_ROW; row++)
                        {
                            Console.Write(" " + slotMachine[row, col] + " ");
                            if (firstValueOfCLine != slotMachine[row, col])
                            {
                                allValuesAreEqual = false;
                                break;
                            }
                            Console.WriteLine();

                        }
                        if (allValuesAreEqual)
                        {
                            cashDeposit++;
                            Console.WriteLine("Win!");
                        }
                        else
                        {
                            cashDeposit--;
                            Console.WriteLine("Lose!");
                        }
                    }
                    Console.WriteLine(cashDeposit);
                }
                if (wagerAmount > allRowsandColsChecked && wagerAmount < MAXIMUM_WAGER)
                {

                    bool allValuesAreEqual = true;
                    for (int i = 0; i < GRID_ROW; i++)
                    {
                        int row = i;
                        int col = i;
                        int firstValueOfDLine = slotMachine[0, 0];
                        Console.WriteLine(slotMachine[row, col]);
                        if (firstValueOfDLine != slotMachine[row, col])
                        {
                            allValuesAreEqual = false;
                            break;
                        }
                    }
                    if (allValuesAreEqual)
                    {
                        cashDeposit++;
                        Console.WriteLine("Win!");
                    }
                    else
                    {
                        cashDeposit--;
                        Console.WriteLine("Lose!");
                    }
                    Console.WriteLine(cashDeposit);
                }
                if (wagerAmount == MAXIMUM_WAGER)
                {
                    bool allValuesAreEqual = true;
                    for (int i = 3; i > 0; i--)
                    {
                        int row = Math.Abs(i - 3);
                        int col = i - 1;
                        int firstValueOfDLine = slotMachine[0, 2];
                        Console.WriteLine(slotMachine[row, col]);
                        if (firstValueOfDLine != slotMachine[row, col])
                        {
                            allValuesAreEqual = false;
                            break;
                        }
                    }
                    if (allValuesAreEqual)
                    {
                        cashDeposit++;
                        Console.WriteLine("Win!");
                    }
                    else //Unecesary else incorporarte in above if with break statement!!!
                    {
                        cashDeposit--;
                        Console.WriteLine("Lose!");
                    }
                    Console.WriteLine(cashDeposit);
                }
            }
        }
    }
}