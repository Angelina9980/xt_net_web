using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
//Написать программу, позволяющую устанавливать и изменять начертание
namespace Task1_1_6
{
    class Program
    {

        static void Main(string[] args)
        {
            var boldtype = Types.None;
            var italictype = Types.None;
            var underlinetype = Types.None;

            while (true)
            {
                Console.WriteLine("The label parameters: {0}, {1}, {2}", boldtype, italictype, underlinetype);
                Console.WriteLine("Enter:");
                Console.WriteLine("1: bold");
                Console.WriteLine("2: metalic");
                Console.WriteLine("3: underline");
                int choice = Int16.Parse(Console.ReadLine());

                switch(choice)
                {
                    case 0:
                        Console.WriteLine("No changes");
                        break;
                    case 1:
                        if (boldtype != Types.Bold)
                        {
                            boldtype = Types.Bold;
                        }
                        else boldtype = Types.None;
                        break;
                    case 2:
                        if (italictype != Types.Italic)
                        {
                            italictype = Types.Italic;
                        }
                        else italictype = Types.None;
                        break;
                    case 3:
                        if (underlinetype!= Types.Underline)
                        {
                            underlinetype = Types.Underline;
                        }
                        else underlinetype = Types.None;
                        break;
                    default:
                        Console.WriteLine("Please inter the correct number");
                            break;
                }

                Console.ReadKey();
            }
        }

        enum Types
        {
            None,
            Bold,
            Italic,
            Underline
        }
    }
}
