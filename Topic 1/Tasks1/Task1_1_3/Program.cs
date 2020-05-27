using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Вывести на экран изображение в виде треугольника, состоящего из звездочек

namespace Task1_1_3
{
    class Program
    {
        static void Stars(int n)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j <= n-i; j++)
                {
                    Console.Write(' ');
                }
                for (int k = 0; k <= i; k++)
                {
                    Console.Write('*');
                }
                for (int m = 0; m <= i-1; m++)
                {
                    Console.Write('*');
                }
                
                Console.WriteLine();
            }
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
