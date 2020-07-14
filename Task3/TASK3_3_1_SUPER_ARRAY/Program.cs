using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TASK3_3_1_SUPER_ARRAY
{
    class Program
    {
        static void Main(string[] args)
        { 
            Console.Write("Please enter the number of items in the array: ");
            int arraySize = int.Parse(Console.ReadLine());

            while (arraySize < 0)
            {
                Console.Write("Sorry, but array must contain elements. Please enter a positive number: ");
                arraySize = int.Parse(Console.ReadLine());
            }

            double[] sourceArray = new double[arraySize];

            Console.WriteLine("Please enter the items in the array: ");

            for (int i = 0; i < sourceArray.Length; i++)
            {
                Console.Write("item[{0}] = ", i);
                sourceArray[i] = double.Parse(Console.ReadLine());
            }

            Console.WriteLine("Source array is:");

            foreach (var item in sourceArray)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();
            Console.WriteLine("Demonstration of methods of a class:");
            Console.WriteLine();

            Console.WriteLine("The sum of all elements in the source array is {0}", sourceArray.GetSumOfElements());
            Console.WriteLine("Avarage value in the source array is {0}", sourceArray.GetAvarageValue());
            Console.WriteLine("The most repeated element is {0}", sourceArray.GetOftRepeatedElement());

            Console.WriteLine();           

            Console.WriteLine("Lets change elements in your array!");
            Console.WriteLine("Please enter select an action for all elements in the array:");
            Console.WriteLine("1 - Increment");
            Console.WriteLine("2 - Squre");
            Console.WriteLine("3 - Cube");
            Console.WriteLine("4 - Zeroing");
            int personChoice;
            Console.WriteLine("Your choice is : {0} ", personChoice = int.Parse(Console.ReadLine()));
            double[] changedArray;

            switch (personChoice)
            {
                case 1: changedArray = sourceArray.Modify((items) => items +=1);
                    break;
                case 2: changedArray = sourceArray.Modify((items) => items * items);
                    break;
                case 3:
                    changedArray = sourceArray.Modify((items) => items * items * items);
                    break;
                case 4:
                    changedArray = sourceArray.Modify((items) => items = 0);
                    break;
                default:
                    Console.WriteLine("The default action is increment");
                    changedArray = sourceArray.Modify((items) => items++);
                    break;
            }

            Console.WriteLine("Changed array:");
            foreach (var item in changedArray)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("Please enter any key to exit");
            Console.ReadKey();
        }
    }
}
