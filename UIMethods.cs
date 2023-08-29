using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlotMachine
{
    public static class UIMethods
    {
        public static void IntroAndRules()
        {
            Console.WriteLine("\t***Welcome to SlotMachine***\n");
            Console.WriteLine("To play this game you are going to need to deposit certain amount of money");
            Console.WriteLine("Further you will be asked how much are you willing to play for after every spin\n");
            Console.WriteLine($"Minimun deposit and wager is {Program.MINIMUM_WAGER} dollar");
            Console.WriteLine("For every dollar you deposit wi will give you 5 playing credits");
            Console.WriteLine("One credit will give you opportunity to play one line\n");
            Console.WriteLine("As you increase the wager more lines will open continuing downwords horisontally,vertically and diagonally");
            Console.WriteLine($"{Program.MAXIMUM_WAGER} credits is a maximum as it gives you oportunity to play all possible lines\n");
            Console.WriteLine("\t!!!Spining time!!!\n");
            Console.WriteLine("\t$Insert the deposit$");
        }
        public static int StringToIntConvert()
        {
            string deposit = Console.ReadLine();
            int result = int.Parse(deposit);
            return result;
        }

        public static void WagerInquiry()
        {
            Console.WriteLine("\t!?How much is your wager?!");
        }

        public static void InvalidInput() 
        {
            Console.WriteLine("Invalid input!");
            Console.WriteLine("Your wager is bigger than maximum wager amount!");
            Console.WriteLine("Apply the amount correctly!");
        }

        public static void DisplayGrid(int slotgrid)
        {
            Console.Write("\t " + slotgrid + " ");
        }

       
    }
}
