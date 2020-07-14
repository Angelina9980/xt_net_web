using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TASK3_2_1_DYNAMIC_ARRAY
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("The example of class working");

            DynamicArray <int> sourceArray = new DynamicArray<int>(3);
            sourceArray.Add(3);
            sourceArray.Add(4);
            sourceArray.Add(5);

            Console.WriteLine("Source array:");

            foreach (object obj in sourceArray)
            {
                Console.WriteLine(obj);
            }

            Console.WriteLine();

            sourceArray.Add(15);
            Console.WriteLine("Array after adding element '15'");
            foreach (object obj in sourceArray)
            {
                Console.WriteLine(obj);
            }

            Console.WriteLine("Capacity is {0}", sourceArray.Capacity);
            Console.WriteLine("Length is {0}", sourceArray.Length);

            sourceArray.Remove(15);
            Console.WriteLine("Array after removing element '15'");
            foreach (object obj in sourceArray)
            {
                Console.WriteLine(obj);
            }
            Console.WriteLine("Capacity is {0}", sourceArray.Capacity);
            Console.WriteLine("Length is {0}", sourceArray.Length);
            Console.WriteLine("Array after inserting element '15' on '2' position");
            sourceArray.Insert(10, 2);
            foreach (object obj in sourceArray)
            {
                Console.WriteLine(obj);
            }
            Console.WriteLine("Capacity is {0}", sourceArray.Capacity);
            Console.WriteLine("Length is {0}", sourceArray.Length);
            Console.WriteLine("Value of 3 element is {0}",3, sourceArray[3]);
            Console.ReadKey();
        }
    }
}
