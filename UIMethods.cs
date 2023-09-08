using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlotMachine
{
    public static class UIMethods
    {
        public static void DisplayIntroAndRules()
        {
            Console.WriteLine("\t***Welcome to SlotMachine***\n");
            Console.WriteLine("To play this game you are going to need to deposit certain amount of money");
            Console.WriteLine("Further you will be asked how much are you willing to play for after every spin\n");
            Console.WriteLine($"Minimun deposit and wager is {Constants.MINIMUM_WAGER} dollar");
            Console.WriteLine("For every dollar you deposit wi will give you 5 playing credits (X)");
            Console.WriteLine("One credit will give you opportunity to play one line\n");
            Console.WriteLine("As you increase the wager more lines will open continuing downwords horisontally,vertically and diagonally");
            Console.WriteLine($"{Constants.MAXIMUM_WAGER} credits is a maximum as it gives you oportunity to play all possible lines\n");
            Console.WriteLine("\t!!!Spining time!!!\n");
            Console.WriteLine("\t$ Insert the deposit $");
        }
        public static int ConvertStringToInt()
        {
            string deposit = Console.ReadLine();
            int result = int.Parse(deposit);
            return result;
        }

        public static void DisplayWagerInquiry()
        {
            Console.WriteLine("\t(X) How much is your wager (X)");
        }

        public static void DisplayInvalidInput()
        {
            Console.WriteLine("\tInvalid input!");
            Console.WriteLine("\tYour wager is bigger than maximum wager amount!");
            Console.WriteLine("\tApply the amount correctly!");
        }

        public static void DisplayPlayingOutcome(int winningLines)
        {
            if (winningLines > 0)
            {
                Console.WriteLine($"\tYou had {winningLines} winning lines!");
                Console.WriteLine("\tNice!");
                Console.WriteLine("\tLets spin some more!\n");
            }
            else
            {
                Console.WriteLine("\tNo luck this time!");
                Console.WriteLine("\tLets spin some more!\n");
            }
        }

        public static void DisplayCurrentCredits(int currentCredits)
        {
            Console.WriteLine($"\tYour current playing credits are {currentCredits} (X)\n");
        }

        public static void DisplayEndingMessage()
        {
            Console.WriteLine("\tGAME OVER!");
        }
        public static void DisplayPlayingCredits(int result)
        {
            Console.WriteLine($"\tPlaying credits = {result} (X)\n\t");
        }

        public static void DisplayGrid(int[,] slotMachine, int row, int col)
        {
            Console.Write("\t " + slotMachine[row, col] + " ");
        }

        public static void AddEmptyLine()
        {
            Console.WriteLine();
        }

        public static void DisplayWinningMessage()
        {
            Console.WriteLine("\tWin!\n");
        }

        public static void DisplayCashOutInquiry()
        {
            Console.WriteLine("\tDo you want to CASH OUT?");
            Console.WriteLine("\tPress N if you want to continue... ");
            Console.WriteLine("\tPress Y if you want finish game and retrive your money...");
        }

        public static void DisplayPaidOutAmount(int cashDeposit)
        {
            Console.WriteLine($"\tYour money total {cashDeposit}$ will be paid out now.\n");
            Console.WriteLine("\tThank you for playing!\n");
        }

        public static void DisplayContinueMessage()
        {
            Console.WriteLine("\tLets continue!\n");
        }
    }
}
