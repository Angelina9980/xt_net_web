using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 Определить сумму элементов двумерного массива, стоящих на четных позициях
 */
namespace Task1_1_10
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter x:");
            int x = Int16.Parse(Console.ReadLine());
            Console.WriteLine("Enter y:");
            int y = Int16.Parse(Console.ReadLine());

            int[,] array = new int[x, y];
            int sum = 0;
            Random rand = new Random();
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    array[i, j] = rand.Next(-1000, 1000);
                    if ((i + j) % 2 == 0)
                    {
                        sum += array[i, j];
                    }
                }
            }

            Console.WriteLine("array:");
            Print(array,x,y);
            Console.WriteLine("Sum = {0}", sum);
            Sum(array,x,y, ref sum);
            Console.ReadKey();
        }

            static void Print(int[,] array, int x, int y)
            {
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    Console.WriteLine(array[i, j]);
                }
            }
        }
        static void Sum(int[,] array, int x, int y, ref int sum)
        {
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    if ((i + j) % 2 == 0)
                    {
                        sum += array[i, j];
                    }
                }
            }
        }
        
    }
}
