namespace SlotMachine
{
    internal class Program
    {
        public const int UPPER_BOUND = 5;
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

                slotMachine = LogicMethods.GenerateSlotMachineGrid(GRID_ROW, GRID_COLUMN);

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
                   winningLinesCount += LogicMethods.SearchFirstDiagonal(slotMachine);
                }

                if (wagerAmount == MAXIMUM_WAGER)
                {
                    winningLinesCount += LogicMethods.SearchSecondDiagonal(slotMachine);
                }

                UIMethods.DisplayPlayingOutcome(winningLinesCount);

                winningLinesCount *= winningLinesCount;
                playingCredits += winningLinesCount;

                Console.WriteLine($"Your current playing credits are {playingCredits}\n");
                bool gameOver = false;

                if (playingCredits > 0)
                {
                   gameOver = LogicMethods.SearchTruth(cashDeposit, playingCredits);
                }
                if (gameOver == true)
                {
                    break;
                }
            }
            Console.WriteLine("GAME OVER!");
        }

    }

}