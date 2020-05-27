using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1_2_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the first string");
            string firststring = Console.ReadLine();
            Console.WriteLine("Enter the second string");
            string secondstring = Console.ReadLine();

            var charlist = new List<char>();

            foreach(var secondsymbols in secondstring)
            {
                if (!charlist.Contains(secondsymbols))
                {
                    charlist.Add(secondsymbols);
                }
            }

            foreach(var ch in charlist)
            {
                firststring = firststring.Replace(ch.ToString(), ch.ToString() + ch.ToString());
            }
            Console.WriteLine(firststring);

            Console.ReadKey();
        }
    }
}
