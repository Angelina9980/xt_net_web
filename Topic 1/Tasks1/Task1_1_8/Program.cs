using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
Заменить все положительные элементы в трехмерном массиве на нули
*/

namespace Task1_1_8
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter x:");
            uint x = UInt16.Parse(Console.ReadLine());
            Console.WriteLine("Enter y:");
            uint y = UInt16.Parse(Console.ReadLine());
            Console.WriteLine("Enter z");
            uint z = UInt16.Parse(Console.ReadLine());

            int[,,] array = new int[x,y,z];
            Array(array,x,y,z);
            Console.WriteLine("array:");
            Print(array, x, y, z);
            Change(array, x, y, z);

            Console.WriteLine();
            Console.WriteLine("Final array:");
            Print(array,x,y,z);
            Console.ReadKey();
        }

        static void Array(int[,,] array, uint n, uint m, uint z)
        {
            Random rand = new Random();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    for (int k = 0; k < z; k++)
                    {
                        array[i, j, k] = rand.Next(-1000, 1000);
                    }
                }
            }
        }
        static void Print(int[,,] array, uint n, uint m, uint z)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    for (int k = 0; k < z; k++)
                    {
                        Console.Write(array[i, j, k]);
                        Console.Write(' ');
                    }
                }
            }
        }
        static void Change(int[,,] array, uint n, uint m, uint z)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    for (int k = 0; k < z; k++)
                    {
                        if (array[i, j, k] > 0)
                        {
                            array[i, j, k] = 0;
                        }
                    }
                }
            }
        }
    }

}
