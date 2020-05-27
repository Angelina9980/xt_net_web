using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1_1_4
{
    class Program
    {
        static void Stars(int n)
        {
            for (int i = 1; i <= n; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    string pinecone = new String('*', j);
                    Console.WriteLine(pinecone.PadLeft(n + 3) + '*' + pinecone);
                }
            }      
                Console.WriteLine();
            }
        
        static void Main(string[] args)
        {
            Console.WriteLine("n = ");
            int n = Int16.Parse(Console.ReadLine());

            while (n <= 0)
            {
                Console.WriteLine("Enter a positive number");
                n = Int16.Parse(Console.ReadLine());
            }

            Stars(n);

            Console.ReadKey();
        }
    }
}
