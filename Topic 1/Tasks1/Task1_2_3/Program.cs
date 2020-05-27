using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
/*
 Посчитать кол-во слов, начинающихся с маленькой буквы
 */
namespace Task1_2_3
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
            
            int count1 = 0, count2 = 0;

            foreach(var sl in option1)
            {
                if (char.IsLower(sl[0]))
                {
                    count1++;
                }
            }

            foreach (var sl in option2)
            {
                if (char.IsLower(sl[0]))
                {
                    count2++;
                }
            }

            Console.WriteLine("Option 1: Number of words with a small letter: {0}", count1);
            Console.WriteLine("Option 2: Number of words with a small letter: {0}", count2);
            Console.ReadKey();
            
        }
        
    }
}
