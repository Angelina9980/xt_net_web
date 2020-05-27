using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 Определить сумму неотрицательных чисел в одномерном массиве
 */
namespace Task1_1_9
{
    class Program
    {
        static void Main(string[] args)
        {
            int sum = 0;

            int[] array = new int[20];
            Random rand = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = rand.Next(-1000, 1000);
            }

            Console.WriteLine("array:");
            Print(array);
            Console.WriteLine();
            Change(array, ref sum);
            Console.WriteLine("Sum = {0}", sum);
            Console.ReadKey();
        }
        static void Print(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i]);
                Console.Write(' ');
            }
        }
        static void Change(int[] array, ref int sum)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] >= 0)
                {
                    sum += array[i];
                }
            }
        }
    }
}
