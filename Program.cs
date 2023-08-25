namespace SlotMachine
{
    internal class Program
    {
        public const int UPPER_BOUND = 6;
        public const int MINIMUM_WAGER = 1;
        public const int MAXIMUM_WAGER = 8;
        public const int GRID_ROW = 3;
        public const int GRID_COLUMN = 3;
        public const int CREDITS_CONVERTOR = 5;
        public static readonly Random rng = new Random();
        static void Main(string[] args)
        {
            Console.WriteLine("\t***Welcome to SlotMachine***\n");
            Console.WriteLine("To play this game you are going to need to deposit certain amount of money");
            Console.WriteLine("Further you will be asked how much are you willing to play for after every spin\n");
            Console.WriteLine($"Minimun deposit and wager is {MINIMUM_WAGER} dollar");
            Console.WriteLine("For every dollar you deposit wi will give you 5 playing credits");
            Console.WriteLine("One credit will give you opportunity to play one line\n");
            Console.WriteLine("As you increase the wager more lines will open continuing downwords horisontally,vertically and diagonally");
            Console.WriteLine($"{MAXIMUM_WAGER} credits is a maximum as it gives you oportunity to play all possible lines\n");

            //Console.WriteLine("\t!!!Spining time!!!\n");
            //Console.WriteLine("\t$Insert the deposit$");
            int cashDeposit = UIMethods.DepositInput(); //Convert.ToInt32(Console.ReadLine());
            int playingCredits = CalculatePlayingCredits(cashDeposit, CREDITS_CONVERTOR); //cashDeposit * CREDITS_CONVERTOR;
           // Console.WriteLine($"\nPlaying credits = {playingCredits}\n");

            int allRowsandColsChecked = GRID_ROW + GRID_COLUMN;

            while (playingCredits >= MINIMUM_WAGER)
            {
                Console.WriteLine("\t!?How much is your wager?!");
                int wagerAmount = Convert.ToInt32(Console.ReadLine());

                if (wagerAmount > MAXIMUM_WAGER)
                {
                    Console.WriteLine("Invalid input!");
                    Console.WriteLine("Your wager is bigger than maximum wager amount!");
                    Console.WriteLine("Apply the amount correctly!");
                    break;
                }

                if (playingCredits < MAXIMUM_WAGER)
                {
                    wagerAmount = Math.Min(playingCredits, wagerAmount);
                }

                playingCredits -= wagerAmount;
                int winningLinesCount = 0;
                int[,] slotMachine = new int[GRID_ROW, GRID_COLUMN];

                for (int row = 0; row < GRID_ROW; row++)
                {
                    for (int col = 0; col < GRID_COLUMN; col++)
                    {
                        slotMachine[row, col] = rng.Next(1, UPPER_BOUND);
                        Console.Write("\t " + slotMachine[row, col] + " ");
                    }
                    Console.WriteLine();
                }

                if (wagerAmount >= MINIMUM_WAGER)
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
                                break;
                            }
                            Console.WriteLine();
                        }

                        if (allValuesAreEqual)
                        {
                            winningLinesCount++;
                            Console.WriteLine("Win!");
                        }
                    }
                }

                if (wagerAmount > GRID_ROW)
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
                                break;
                            }
                            Console.WriteLine();
                        }

                        if (allValuesAreEqual)
                        {
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
                        int firstValueOfDLine = slotMachine[0, 0];

                        if (firstValueOfDLine != slotMachine[i, i])
                        {
                            allValuesAreEqual = false;
                            break;
                        }
                    }

                    if (allValuesAreEqual)
                    {
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
                            break;
                        }
                    }

                    if (allValuesAreEqual)
                    {
                        winningLinesCount++;
                        Console.WriteLine("Win!");
                    }
                }

                if (winningLinesCount > 0)
                {
                    Console.WriteLine($"You had {winningLinesCount} winning lines!\nNice!\nLets spin some more!\n");
                }
                else
                {
                    Console.WriteLine("No luck this time!\nLets spin some more!\n");
                }

                winningLinesCount *= winningLinesCount;
                playingCredits += winningLinesCount;

                Console.WriteLine($"Your current playing credits are {playingCredits}\n");
                bool gameOver = false;

                while (playingCredits > 0)
                {
                    Console.WriteLine("Do you want to cash out?");
                    string cashMeOut = Console.ReadLine().ToLower();
                    if (cashMeOut == "y")
                    {
                        cashDeposit = playingCredits / CREDITS_CONVERTOR;
                        Console.WriteLine($"Your money total {cashDeposit}$ will be paid out now.\n");
                        Console.WriteLine("Thank you for playing!\n");
                        gameOver = true;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Lets continue!\n");
                        break;
                    }
                }
                if (gameOver)
                {
                    break;
                }
            }
            Console.WriteLine("GAME OVER!");
        }
        static int CalculatePlayingCredits(int cashDeposit, int constnant)
        {
            int result = cashDeposit * constnant;
            Console.WriteLine($"\nPlaying credits = {result}\n");
            return result;
        }
    }
}