using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_1_1_CUSTOM_STRING
{
    class MyString
    {
        private char[] arrayofsymbols;

        public MyString(string lineforprocessing)
        {
            this.arrayofsymbols = lineforprocessing.ToCharArray();
        }

        public MyString(char[] arrayofsymbols)
        {
            this.arrayofsymbols = new char[arrayofsymbols.Length];
            this.arrayofsymbols.CopyTo(arrayofsymbols,0);
        }

        public int Length
        {
            get
            {
                return arrayofsymbols.Length;
            }
        }
        public char[] ConvertToChar(string lineforprocessing)
        {
            char[] arrayofsymbols = lineforprocessing.ToCharArray();
            return arrayofsymbols;
        }
        public string ConvertToString(char[] arrayofsymbols)
        {
            string originalstring = "";
            for (int i = 0; i < arrayofsymbols.Length; i++)
            {
                originalstring += arrayofsymbols[i];
            }
            return originalstring;
        }

        public int this[string word] => FindAwordInAstring(word);
        private int FindAwordInAstring(string word)
        {
            char[] marks = { ' ', '.', ',', '!', '?', ':', ';', '-' };
            string[] stringarray = ConvertToString(arrayofsymbols).Split(marks, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < stringarray.Length; i++)
            {
                if (stringarray[i] == word)
                    return ++i;
            }
            throw new System.ArgumentOutOfRangeException(
               nameof(word), $"Word '{word}' is not contained in the sentence"
                );
        }
        
        //additional methods for working with strings
        public static void CompareStrings(string firststringtocompare, string secondstringtocompare)
        {
            int resultoftheconcat = string.Compare(firststringtocompare, secondstringtocompare);
            if (resultoftheconcat < 0)
                Console.WriteLine("The first string before the second");
            else if (resultoftheconcat > 0)
                Console.WriteLine("The first string after the second");
            else Console.WriteLine("The strings are identical");
        }

        public void CompareStrings(string secondstringtocompare)
        {
            char[] secondarraytocompare = ConvertToChar(secondstringtocompare);
            int thecharactercounter = 0;
            if (arrayofsymbols.Length == secondarraytocompare.Length)
            {
                Console.WriteLine("The strings have the same length");
                for (int i = 0; i< arrayofsymbols.Length; i++)
                {
                    if (arrayofsymbols[i] != secondarraytocompare[i])
                    {
                        Console.WriteLine("This strings are not the same");
                    }
                    else
                    {
                        thecharactercounter++;
                    }
                }
                if (thecharactercounter == arrayofsymbols.Length)
                {
                    Console.WriteLine("The strings are the same");
                }
            }
            else
            {
                Console.WriteLine("The strings are not equal in length");
            }
        }

        public void CompareStrings(char[] secondarrayofsymbols)
        {
            int thecharactercounter = 0;
            if (arrayofsymbols.Length == secondarrayofsymbols.Length)
            {
                Console.WriteLine("The strings have the same length");
                for (int i = 0; i < arrayofsymbols.Length; i++)
                {
                    if (secondarrayofsymbols[i] != secondarrayofsymbols[i])
                    {
                        Console.WriteLine("This strings are not the same");
                    }
                    else
                    {
                        thecharactercounter++;
                    }
                }
                if (thecharactercounter == arrayofsymbols.Length)
                {
                    Console.WriteLine("The strings are the same");
                }
            }
            else
            {
                Console.WriteLine("The strings are not equal in length");
            }
        }

        public static void ConcatStrings(string lineforprocessing, string stringtoconcate)
        {
            string stringconcatenationwithplus = lineforprocessing + stringtoconcate;
            Console.WriteLine("Concatenate strings using the operation '+': {0}", stringconcatenationwithplus);
            string stringconcatenationwithconcat = String.Concat(lineforprocessing, stringtoconcate);
            Console.WriteLine("Concatenate strings using a concat method: {0}", stringconcatenationwithconcat);
            string[] arrayofstrings = new string[] {lineforprocessing, stringtoconcate};
            string joinstrings = string.Join(" ", arrayofstrings);
            Console.WriteLine("Concatenate strings using Join method with separator \" \": {0}", joinstrings);
        }

        public char[] ConcatStrings(char[] secondarrayofsymbols)
        {
            char[] theresultofconcat = new char[arrayofsymbols.Length + secondarrayofsymbols.Length];
            arrayofsymbols.CopyTo(theresultofconcat, 0);
            secondarrayofsymbols.CopyTo(theresultofconcat, arrayofsymbols.Length);
            return theresultofconcat;
        }

        public char[] ConcatStrings(string secondarrayofsymbols)
        {
            char[] theresultofconcat = new char[arrayofsymbols.Length + secondarrayofsymbols.Length];
            arrayofsymbols.CopyTo(theresultofconcat, 0);
            secondarrayofsymbols.ToCharArray().CopyTo(theresultofconcat, arrayofsymbols.Length);
            return theresultofconcat;
        }

        public static void SearchSymbol(string lineforprocessing, char symbolforsearch)
        {
            if (lineforprocessing.Contains(symbolforsearch))
            {
                int IndexOfSymbol = lineforprocessing.IndexOf(symbolforsearch);
                int LastIndexOfSymbol = lineforprocessing.LastIndexOf(symbolforsearch);
                Console.WriteLine("The first index of the symbol '{0}' in the string is {1}", symbolforsearch, IndexOfSymbol);
                Console.WriteLine("The last index of the symbol '{0}' in the string is {1}", symbolforsearch, LastIndexOfSymbol);
            }
            else
            {
                Console.WriteLine("Symbol is not found");
            }
        }

        public void SearchSymbol(char symbolforsearch)
        {
            for (int i = 0; i < arrayofsymbols.Length; i++)
            {
                if (arrayofsymbols[i] == symbolforsearch)
                {
                    Console.WriteLine("The index of symbol '{0}' : {1}",symbolforsearch, i);
                }
            }
        }
        public static void SearchAllIndexesOfSymbol(string lineforprocessing, char symbolforsearch)
        {
            string symbol = symbolforsearch.ToString();
            var allindex = new List<int>();
            int index = lineforprocessing.IndexOf(symbol, 0);
            while (index > -1)
            {
                allindex.Add(index);
                index = lineforprocessing.IndexOf(symbol, index + symbol.Length);
            }

            foreach(var indexes in allindex)
            {
                Console.WriteLine(indexes);
            }
        }

    }
}
