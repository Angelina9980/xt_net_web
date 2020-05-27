using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Необходимо найти площадь треугольника со сторонами a и b
//Если введены некорректные значения - выдать сообщение об ошибке
//Возможность ввода строки или нецелых чисел игнорировать

namespace Task1_1_1
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Enter the first side:");
            int a = 0;
            Check(ref a);
            Console.WriteLine("Enter the second side:");
            int b = 0;
            Check(ref b);
            int result;

            while (a <=0 || b <= 0)
            {
                Console.WriteLine("Please enter a positive numbers");
                Check(ref a);
                Check(ref b);
            }
            
            result = a * b;
            Console.WriteLine("The area: {0} * {1} = {2}",a, b, result);
            
            Console.ReadKey();
        }
        static void Check(ref int number)
        {
            if (int.TryParse(Console.ReadLine(), out int numb))
            {
                number = numb;
            }
            else
            {
                Check(ref number);
            }
        }

        
    }
}
