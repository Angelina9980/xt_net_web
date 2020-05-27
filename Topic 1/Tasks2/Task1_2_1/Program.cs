using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1_2_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter your string");
            string line = Console.ReadLine();

            char[] marks = { ' ', '.', ',', '!', '?', ':', ';', '-' };
            string[] array = line.Split(marks, StringSplitOptions.RemoveEmptyEntries);
            int[] wordslength = new int[array.Length];
            int i = 0, count = 0, length = 0, averagelength;
            foreach(string str in array)
            {
                wordslength[i] = str.Length;
                length += wordslength[i];
                i++;
            }

            foreach(int word in wordslength)
            {
                count += 1;
            }

            averagelength = length / count;
            Console.WriteLine("Average length: {0}", averagelength);
                
            Console.ReadKey();
        }
    }
}
