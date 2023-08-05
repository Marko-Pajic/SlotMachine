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
            Console.WriteLine("\t***Welcome to SlotMachine***\n");
            Console.WriteLine("To play this game you are going to need to deposit certain amount of money");
            Console.WriteLine("Further you will be asked how much are you willing to play for after every spin\n");
            Console.WriteLine($"Minimun deposit and wager is {MINIMUM_WAGER} dollar");
            Console.WriteLine($"{MINIMUM_WAGER} dollar will give you opportunity to play one line\n");
            Console.WriteLine("As you increase the wager more lines will open continuing downwords horisontally,vertically and diagonally");
            Console.WriteLine($"{MAXIMUM_WAGER} dollars is a maximum as it gives you oportunity to play all possible lines\n");

            Console.WriteLine("\t!!!Spining time!!!\n");
            Console.WriteLine("\t$Insert the deposit$");
            int cashDeposit = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("\t!?How much is your wager?!"); //Something is wrong with this!!!
            int wagerAmount = Convert.ToInt32(Console.ReadLine());
            int winningLinesCount = 0;

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
                            if (firstValueOfRLine != slotMachine[row, col])
                            {
                                allValuesAreEqual = false;
                                cashDeposit--;
                                break;
                            }
                            Console.WriteLine();
                        }
                        if (allValuesAreEqual)
                        {
                            cashDeposit++;
                            winningLinesCount++;
                            Console.WriteLine("Win!");
                        }
                    }
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
                            if (firstValueOfCLine != slotMachine[row, col])
                            {
                                allValuesAreEqual = false;
                                cashDeposit--;
                                break;
                            }
                            Console.WriteLine();

                        }
                        if (allValuesAreEqual)
                        {
                            cashDeposit++;
                            winningLinesCount++;
                            Console.WriteLine("Win!");
                        }
                    }
                }
                if (wagerAmount > allRowsandColsChecked)
                {

                    bool allValuesAreEqual = true;
                    for (int i = 0; i < GRID_ROW; i++)
                    {
                        int row = i;
                        int col = i;
                        int firstValueOfDLine = slotMachine[0, 0];
                        if (firstValueOfDLine != slotMachine[row, col])
                        {
                            allValuesAreEqual = false;
                            cashDeposit--;
                            break;
                        }
                    }
                    if (allValuesAreEqual)
                    {
                        cashDeposit++;
                        winningLinesCount++;
                        Console.WriteLine("Win!");
                    }
                }
                if (wagerAmount == MAXIMUM_WAGER)
                {
                    bool allValuesAreEqual = true;
                    for (int i = GRID_COLUMN; i > 0; i--)
                    {
                        int row = Math.Abs(i - GRID_COLUMN);
                        int col = i - 1;
                        int firstValueOfDLine = slotMachine[0, GRID_COLUMN - 1];
                        if (firstValueOfDLine != slotMachine[row, col])
                        {
                            allValuesAreEqual = false;
                            cashDeposit--;
                            break;
                        }
                    }
                    if (allValuesAreEqual)
                    {
                        cashDeposit++;
                        winningLinesCount++;
                        Console.WriteLine("Win!");
                    }
                }
                int winningLines = cashDeposit - winningLinesCount;
                if (winningLinesCount > 0)
                {
                    Console.WriteLine($"You had {winningLines} lines!\nNice!\nLets spin some more!\n");
                }
                else
                {
                    Console.WriteLine("No luck for you this time!\nLets spin some more!\n");
                }
                Console.WriteLine($"Your current playing deposit is {cashDeposit}$\n");
            }
        }
    }
}