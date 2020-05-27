using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1_2_4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter your string");
            var line = Console.ReadLine();
            char[] marks = { ' ', '.', ',', '!', '?', ':', ';', '-' };
            var option1 = line.Split(' ');
            var option2 = line.Split(marks, StringSplitOptions.RemoveEmptyEntries);


            Console.WriteLine(Change(line));

            foreach (char s in line)
            {
                
            }

            Console.ReadKey();

        }
        static string Change(string line)
        {
            char[] a = line.ToCharArray();
            a[0] = char.ToUpper(a[0]);
            return new string(a);
        }
    }
}
