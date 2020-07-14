using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TASK3_3_2_SUPER_STRING
{
    public static class StringExtension
    {
        public static string GetLanguage(this string sourceString)
        {
            if (sourceString == null)
                throw new AggregateException("String cannot be empty");

            string definingString = sourceString.ToLower();

            const string
                russianLetters = "абвгдеёжзиклмнопрстуфхцчшщъыьэюя",
                englishLetters = "abcdefghiklmnopqrstuvwxyz",
                numberLetters = "0123456789";

            if (definingString.All(letters => russianLetters.Contains(letters)))
                return "The language is russian";
            else
            if (definingString.All(letters => englishLetters.Contains(letters)))
                return "The language is english";
            else
            if (definingString.All(letters => numberLetters.Contains(letters)))
                return "Your string consists of numbers";
            else
                return "The language is mixed";
        }
    }
}
