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
            Console.WriteLine("For every dollar you deposit wi will give you 5 playing credits");
            Console.WriteLine("One credit will give you opportunity to play one line\n");
            Console.WriteLine("As you increase the wager more lines will open continuing downwords horisontally,vertically and diagonally");
            Console.WriteLine($"{Constants.MAXIMUM_WAGER} credits is a maximum as it gives you oportunity to play all possible lines\n");
            Console.WriteLine("\t!!!Spining time!!!\n");
            Console.WriteLine("\t$Insert the deposit$");
        }
        public static int ConvertStringToInt()
        {
            string deposit = Console.ReadLine();
            int result = int.Parse(deposit);
            return result;
        }

        public static void DisplayWagerInquiry()
        {
            Console.WriteLine("\t!?How much is your wager?!");
        }

        public static void DisplayInvalidInput()
        {
            Console.WriteLine("Invalid input!");
            Console.WriteLine("Your wager is bigger than maximum wager amount!");
            Console.WriteLine("Apply the amount correctly!");
        }

        public static void DisplayPlayingOutcome(int winningLines)
        {
            if (winningLines > 0)
            {
                Console.WriteLine($"You had {winningLines} winning lines!\nNice!\nLets spin some more!\n");
            }
            else
            {
                Console.WriteLine("\tNo luck this time!\nLets spin some more!\n");
            }
        }

        public static void DisplayCurrentCredits(int currentCredits)
        {
            Console.WriteLine($"Your current playing credits are {currentCredits}\n");
        }

        public static void DisplayEndingMessage()
        {
            Console.WriteLine("GAME OVER!");
        }
        public static void DisplayPlayingCredits(int result)
        {
            Console.WriteLine($"\nPlaying credits = {result}\n");
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
            Console.WriteLine("Win!\n");
        }

        public static void DisplayCashOutInquiry()
        {
            Console.WriteLine("Do you want to cash out?");
        }

        public static void DisplayPaidOutAmount(int cashDeposit) 
        {
            Console.WriteLine($"Your money total {cashDeposit}$ will be paid out now.\n");
            Console.WriteLine("Thank you for playing!\n");
        }

        public static void DisplayContinueMessage()
        {
            Console.WriteLine("Lets continue!\n");
        }
    }
}
