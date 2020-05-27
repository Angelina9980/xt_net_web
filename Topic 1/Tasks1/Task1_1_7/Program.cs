using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Генерируются случайные элементы массива
//Определить мин, макс, отсортировать массив и вывести на экран

namespace Task1_1_7
{
    class Program
    {
        static void Main(string[] args)
        {
            int min = 0, max = 0;
            int[] array = new int[20];
            Random rand = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = rand.Next(1, 1000);
            }

            Console.WriteLine("array:");
            Print(array);

            Console.WriteLine();
            Console.WriteLine("Changed array");
            

            BubbleSort(array, ref min, ref max);
            Print(array);
            Console.WriteLine();
            Console.WriteLine("min = {0}", min);
            Console.WriteLine("max = {0}", max);
            Console.ReadKey();
        }

        static void BubbleSort(int[] array, ref int min, ref int max)
        {
            int t;
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[i] > array[j])
                    {
                        t = array[i];
                        array[i] = array[j];
                        array[j] = t;
                    }
                   
                }
                min = array[0];
                max = array[array.Length-1];
            }
        }

        static void Print(int[] mas)
        {
            for (int i = 0; i < mas.Length; i++)
            {
                Console.Write(mas[i]);
                Console.Write(' ');
            }
        }
    }
}
