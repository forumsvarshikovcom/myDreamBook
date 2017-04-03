using System.Collections.Generic;

namespace ConsoleApplication4
{
    public static class Translator
    {
        private static Dictionary<char,string> CurrilicToLatDictionary = new Dictionary<char, string>
        {
            ['й'] = "y",
            ['ц'] = "c",
            ['у'] = "u",
            ['к'] = "k",
            ['е'] = "e",
            ['н'] = "n",
            ['г'] = "g",
            ['ш'] = "sh",
            ['щ'] = "ch",
            ['з'] = "z",
            ['х'] = "h",
            ['ъ'] = "_",
            ['ф'] = "f",
            ['ы'] = "i",
            ['в'] = "v",
            ['а'] = "a",
            ['п'] = "p",
            ['р'] = "r",
            ['о'] = "o",
            ['л'] = "l",
            ['д'] = "d",
            ['ж'] = "g",
            ['э'] = "i",
            ['я'] = "ia",
            ['ч'] = "ch",
            ['с'] = "s",
            ['м'] = "m",
            ['и'] = "i",
            ['т'] = "t",
            ['ь'] = "_",
            ['б'] = "b",
            ['ю'] = "y",
        };

        public static string ToLatinica(this string cyrilicName)
        {
            var latName = "";
            foreach (var cyrWord in cyrilicName.ToLower())
            {
                latName += GetLatSymbol(cyrWord);
            }
            return latName;
        }
        private static string GetLatSymbol(char curilicSymbol)
        {
            var latSymbol = "_";
            CurrilicToLatDictionary.TryGetValue(curilicSymbol, out latSymbol);
            return latSymbol;
        }
    }
}
