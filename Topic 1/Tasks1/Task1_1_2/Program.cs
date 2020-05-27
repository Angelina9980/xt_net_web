using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1_1_2
{
    class Program
    {
        static void Output(int n)
        {
            for (int i = 1; i <= n; ++i)
            {
                Console.Write("*");
            }
            Console.WriteLine();
        }
        
        static void Stars(int n, int i)
        {
            if (i <= n)
            {
                Output(i);
                Stars(n, i + 1);
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("n = ");
            int n = Int16.Parse(Console.ReadLine());
            int i = 1;
            Stars(n, i);

            Console.ReadKey();
        }
    }
}


