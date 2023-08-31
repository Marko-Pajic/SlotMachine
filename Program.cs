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
            UIMethods.DisplayIntroAndRules();

            int cashDeposit = UIMethods.ConvertStringToInt();
            int playingCredits = LogicMethods.CalculatePlayingCredits(cashDeposit, CREDITS_CONVERTOR);

            int allRowsandColsChecked = GRID_ROW + GRID_COLUMN;

            while (playingCredits >= MINIMUM_WAGER)
            {
                UIMethods.DisplayWagerInquiry();
                int wagerAmount = UIMethods.ConvertStringToInt();

                if (wagerAmount > MAXIMUM_WAGER)
                {
                    UIMethods.DisplayInvalidInput();
                    break;
                }

                if (playingCredits < MAXIMUM_WAGER)
                {
                    wagerAmount = Math.Min(playingCredits, wagerAmount);
                }

                playingCredits -= wagerAmount;
                int winningLinesCount = 0;
                int[,] slotMachine = new int[GRID_ROW, GRID_COLUMN];
                slotMachine = LogicMethods.GenerateSlotMachineGrid(GRID_ROW, GRID_COLUMN, UPPER_BOUND);

                if (wagerAmount >= MINIMUM_WAGER)
                {
                    int numberOfRowsToCheck = Math.Min(wagerAmount, GRID_ROW);

                    winningLinesCount += LogicMethods.SearchRows(numberOfRowsToCheck, slotMachine);
                }

                if (wagerAmount > GRID_ROW)
                {
                    int numberOfColumnsToCheck = Math.Min(wagerAmount - GRID_ROW, GRID_ROW);

                    winningLinesCount += LogicMethods.SearchColumns(numberOfColumnsToCheck, slotMachine);
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
                        Console.WriteLine("Win!\n");
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
                        Console.WriteLine("Win!\n");
                    }
                }

                if (winningLinesCount > 0)
                {
                    Console.WriteLine($"You had {winningLinesCount} winning lines!\nNice!\nLets spin some more!\n");
                }
                else
                {
                    Console.WriteLine("\tNo luck this time!\nLets spin some more!\n");
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

    }

}