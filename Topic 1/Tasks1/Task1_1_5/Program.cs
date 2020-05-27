using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Вывести на экран сумму чисел:
//меньше 1000, кратных 3 или 5
namespace Task1_1_5
{
    class Program
    {
        static void Main(string[] args)
        {
            int sum = 0;
            for (int i=3; i<=1000;i++)
            {
                if (i % 3 == 0 || i % 5 == 0) 
                    sum += i;
            }

            Console.WriteLine("sum = {0}", sum);
            Console.ReadKey();
        }
    }
}
