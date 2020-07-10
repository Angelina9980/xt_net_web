using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TASK3_1_2_TEXT_ANALYSIS
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Welcome to the program 'Text Analysis'!");

            string sourceText = "Fashion has always had a huge influence on people around the world. " +
                "\nThe main reason why we try to follow the latest fashion trends is a desire to look stylish, attractive, popular and more confident. " +
                "\nGenerally people judge a new person by his appearance and his clothes and only then, by his inner qualities. There is a proverb: " +
                "\n“Good clothes open all doors.” That’s why we do our best to make a favourable impression on others. " +
                "\nWe spend a lot of money to keep up with fashion and buy designer clothes.";

            Console.WriteLine();
            Console.WriteLine("The source text looks like this:");

            Console.WriteLine();
            Console.WriteLine(sourceText);
            Console.WriteLine();

            Dictionary <string, int> wordsAndTheirNumberInTheText = TextAnalysis(sourceText);
            bool IsVarious = true;

            Console.WriteLine("Start analyzing the read text.");
            Console.WriteLine();

            foreach (KeyValuePair <string, int> keyValue in wordsAndTheirNumberInTheText)
            {
                Console.WriteLine("The word '{0}' contains {1} times", keyValue.Key, keyValue.Value);
                Console.WriteLine();
                if (keyValue.Value >= 5)
                {
                    Console.WriteLine("Please note: the word '{0}' was used too many times!", keyValue.Key);
                    Console.WriteLine();
                    IsVarious = false;
                }
            }

            Console.WriteLine("Text analysis result : ");
            if (IsVarious)
                Console.WriteLine("The text is quite diverse. Text processing is not required.");
            else
                Console.WriteLine("The text contains frequently repeated words. You need to correct the text.");

            Console.WriteLine("Please enter any key to exit.");
            Console.ReadKey();
        }

        public static Dictionary <string, int> TextAnalysis(string textForAnalysis)
        {
            char[] marks = { ' ', '.', ',', '!', '?', ':', ';', '-', '\n', '“', '”', '(', ')', '{', '}', '[', ']'};
            string[] arrayOfWords = textForAnalysis.ToLower().Split(marks, StringSplitOptions.RemoveEmptyEntries);
            Dictionary <string, int> wordsAndTheirNumberInTheText = new Dictionary <string, int>();
            
            foreach (var word in arrayOfWords)
            {
                int wordCounter = 0;
                foreach (var enotherWord in arrayOfWords)
                {
                    if (word.Equals(enotherWord))
                    {
                        wordCounter++;
                    }
                }
                if (!wordsAndTheirNumberInTheText.ContainsKey(word)) 
                    wordsAndTheirNumberInTheText.Add(word, wordCounter);
            }
            return wordsAndTheirNumberInTheText;
        }

    }

}
