using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_1_1_CUSTOM_STRING
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter your string");
            string stringforprocessing = Console.ReadLine();
            MyString stringtouse = new MyString(stringforprocessing);

            //typical operation for strings using standart methods and own implementations
            Console.WriteLine("Which symbol are you looking for in your string?");
            char symbolforsearch = Convert.ToChar(Console.ReadLine());
            stringtouse.SearchSymbol(symbolforsearch);

            char[] arrayofsymbols = stringtouse.ConvertToChar(stringforprocessing);
            Console.WriteLine("Converting from a string to an array of symbols:");
            foreach(char symbol in arrayofsymbols)
            {
                Console.WriteLine(symbol);
            }
      
            string originalstring = stringtouse.ConvertToString(arrayofsymbols);
            Console.WriteLine("Converting from an array of symbols to a string: {0}", originalstring);

            Console.WriteLine("Enter a comparison string");
            string stringtocompare = Console.ReadLine();
            stringtouse.CompareStrings(stringtocompare);

            Console.WriteLine("Enter a string to concate");
            string stringtoconcate = Console.ReadLine();
            Console.WriteLine(stringtouse.ConcatStrings(stringtoconcate));

            //new function 
            Console.WriteLine("All indexes of the symbol '{0}' occurrence in the string: '{1}' :", symbolforsearch, stringforprocessing);
            MyString.SearchAllIndexesOfSymbol(stringforprocessing, symbolforsearch);

            //Using the index
            //display the index of a word in a string
            //indexing starting from one
                        Console.WriteLine("Please inter the word to get index in '{0}':",stringforprocessing);
            string findIndex = Console.ReadLine();

            try
            {
                Console.WriteLine(stringtouse[findIndex]);
            }
            catch (System.ArgumentOutOfRangeException exeption)
            {
                Console.WriteLine($"Not supported input: {exeption.Message}");
            }

            Console.ReadKey();
        }
    }
}
