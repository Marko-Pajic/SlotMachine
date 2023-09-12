using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlotMachine
{
    public static class UIMethods
    {
        /// <summary>
        /// Displays intro and game rules
        /// </summary>
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

        /// <summary>
        /// Converts string input to int 
        /// </summary>
        /// <returns>integer</returns>
        public static int ConvertStringToInt()
        {
            string deposit = Console.ReadLine();
            int result = int.Parse(deposit);
            return result;
        }

        /// <summary>
        /// Displays a message
        /// </summary>
        public static void DisplayWagerInquiry()
        {
            Console.WriteLine("\t(X) How much is your wager (X)");
        }

        /// <summary>
        /// Displays a message with instructions
        /// </summary>
        public static void DisplayInvalidInput()
        {
            Console.WriteLine("\tInvalid input!");
            Console.WriteLine("\tYour wager is bigger than maximum wager amount!");
            Console.WriteLine("\tApply the amount correctly!");
        }

        /// <summary>
        /// Makes decision and displays text depending on a parameter
        /// </summary>
        /// <param name="winningLines">takes a number</param>
        public static void DisplayPlayingOutcome(int winningLines)
        {
            if (winningLines > 0)
            {
                Console.WriteLine($"\tYou had {winningLines} winning lines!");
                Console.WriteLine("\tNice!");
            }
            else
            {
                Console.WriteLine("\tNo luck this time!\n");
            }
        }

        /// <summary>
        /// Displays a message
        /// </summary>
        public static void DisplayEncouragementMessage() 
        {
            Console.WriteLine("\tLets spin some more!\n"); 
        }

        /// <summary>
        /// Displays a message with current state of playing credits
        /// </summary>
        /// <param name="currentCredits">takes a number</param>
        public static void DisplayCurrentCredits(int currentCredits)
        {
            Console.WriteLine($"\tYour current playing credits are {currentCredits} (X)\n");
        }

        /// <summary>
        /// Displays a message
        /// </summary>
        public static void DisplayEndingMessage()
        {
            Console.WriteLine("\tGAME OVER!");
        }

        /// <summary>
        /// Displays a message
        /// </summary>
        /// <param name="result">takes a number</param>
        public static void DisplayPlayingCredits(int result)
        {
            Console.WriteLine($"\tPlaying credits = {result} (X)\n\t");
        }

        /// <summary>
        /// Displays visualy 2d array in a grid
        /// </summary>
        /// <param name="slotMachine">takes a 2d array</param>
        /// <param name="row">takes a number</param>
        /// <param name="col">takes a number</param>
        public static void DisplayGrid(int[,] slotMachine, int row, int col)
        {
            Console.Write("\t " + slotMachine[row, col] + " ");
        }

        /// <summary>
        /// Adds an empty line
        /// </summary>
        public static void AddEmptyLine()
        {
            Console.WriteLine();
        }

        /// <summary>
        /// Displays a message
        /// </summary>
        public static void DisplayWinningMessage()
        {
            Console.WriteLine("\tWin!\n");
        }

        /// <summary>
        /// Displays a message
        /// </summary>
        public static void DisplayCashOutInquiry()
        {
            Console.WriteLine("\tDo you want to CASH OUT?");
            Console.WriteLine("\tPress N if you want to continue... ");
            Console.WriteLine("\tPress Y if you want finish game and retrive your money...");
        }

        /// <summary>
        /// Displays a message
        /// </summary>
        /// <param name="cashDeposit"></param>
        public static void DisplayPaidOutAmount(int cashDeposit)
        {
            Console.WriteLine($"\tYour money total {cashDeposit}$ will be paid out now.\n");
            Console.WriteLine("\tThank you for playing!\n");
        }

        /// <summary>
        /// Displays a message
        /// </summary>
        public static void DisplayContinueMessage()
        {
            Console.WriteLine("\tLets continue!\n");
        }
    }
}
