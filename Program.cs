namespace SlotMachine
{
    internal class Program
    {
        public static readonly Random rng = new Random();
        static void Main(string[] args)
        {
            UIMethods.DisplayIntroAndRules();

            int cashDeposit = UIMethods.ConvertStringToInt();
            int playingCredits = LogicMethods.CalculatePlayingCredits(cashDeposit);

            int allRowsandColsChecked = Constants.GRID_ROW_COUNT + Constants.GRID_COLUMN_COUNT;
            bool gameOn = true;
            while (gameOn) //(playingCredits >= Constants.MINIMUM_WAGER)
            {
                UIMethods.DisplayWagerInquiry();
                int wagerAmount = UIMethods.ConvertStringToInt();

                if (wagerAmount > Constants.MAXIMUM_WAGER)
                {
                    UIMethods.DisplayInvalidInput();
                    continue;
                }

                if (playingCredits < Constants.MAXIMUM_WAGER)
                {
                    wagerAmount = Math.Min(playingCredits, wagerAmount);
                }

                playingCredits -= wagerAmount;

                int[,] slotMachine = LogicMethods.GenerateSlotMachineGrid();

                int winningLinesCount = LogicMethods.SearchingWinningCombination(wagerAmount, allRowsandColsChecked, slotMachine);

                UIMethods.DisplayPlayingOutcome(winningLinesCount);

                winningLinesCount *= winningLinesCount;
                playingCredits += winningLinesCount;

                UIMethods.DisplayCurrentCredits(playingCredits);

                if (playingCredits > 0)
                {
                    UIMethods.DisplayEncouragementMessage();
                    gameOn = LogicMethods.GameEndingDecision(cashDeposit, playingCredits);
                }
                else
                {
                    gameOn = false;
                }
            }
            UIMethods.DisplayEndingMessage();
        }

    }

}