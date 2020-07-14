using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TASK3_3_2_SUPER_STRING
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Lets check your string!");

            bool isWorking = true;
            while (isWorking)
            {
                Console.WriteLine("Please enter the action:");
                Console.WriteLine("1 - Enter and check the string");
                Console.WriteLine("2 - Exit");
                Console.Write("Your action is : ");
                int personChoice = int.Parse(Console.ReadLine());

                switch (personChoice)
                {
                    case 1:
                        Console.Write("Please enter the string to check the language : ");
                        string soureString = Console.ReadLine();
                        Console.WriteLine(soureString.GetLanguage());
                        break;
                    case 2:
                        isWorking = false;
                        Console.WriteLine("Good luck!");
                        Console.WriteLine("Press any key to exit");
                        break;
                }             
            }

            Console.ReadKey();
        }
    }
}
