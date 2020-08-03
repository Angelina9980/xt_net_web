using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4_4_1_FILE_MANAGEMENT_SYSTEM
{
    class Program
    {
        private static string directoryPath;

        static void Main()
        {
            try
            {
                Console.WriteLine("Please enter the path of directory : ");
                directoryPath = Console.ReadLine();
                var FileManagement = new FileManagement(@directoryPath);
                FileManagement.Dispose();
            }
            catch (DirectoryNotFoundException exception)
            {
                Console.WriteLine("Do you want to create a directory with this path?");
                Console.Write("Please enter 'Y' or 'N' : ");

                if (Console.ReadKey().Key == ConsoleKey.Y)
                {
                    try
                    {
                        Directory.CreateDirectory(exception.Message);
                        Main();
                    }
                    catch (ArgumentException argumentExeption)
                    {
                        Console.WriteLine(argumentExeption.Message);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else
                {
                    return;
                }
            }
            Console.ReadKey();
        }
    }
}

