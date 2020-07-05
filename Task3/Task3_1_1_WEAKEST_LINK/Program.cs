using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3_1_1_WEAKEST_LINK
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.Write("Please enter the number of people in a circle : ");
            int numberOfPeople = int.Parse(Console.ReadLine());

            while (numberOfPeople <= 0)
            {
                Console.WriteLine("Sorry, but there should be people in the circle.");
                Console.Write("Please enter a positive number : ");
                numberOfPeople = int.Parse(Console.ReadLine());
            }

            Console.WriteLine("Which person will be deleted?");
            Console.Write("Please enter this number : ");
            int numberToDelete = int.Parse(Console.ReadLine());

            while (numberToDelete > numberOfPeople || numberToDelete <= 0 || numberToDelete == 1)
            {
                Console.WriteLine("Sorry, but you must enter a number from two and no more than {0}", numberOfPeople);
                Console.Write("Please enter the correct number : ");
                numberToDelete = int.Parse(Console.ReadLine());
            }

            for (int i = 1; i <= numberOfPeople - numberToDelete + 1; i++)
            {
                Console.WriteLine("Round {0}. A person is crossed out. There are {1} people left", i, numberOfPeople - i);
                if (i == numberOfPeople - numberToDelete + 1) Console.WriteLine("The game is over. You can't cross out more people.");
            }

            Console.WriteLine("Please press any key to exit the game.");

            Console.ReadKey();
        }
    }
}
