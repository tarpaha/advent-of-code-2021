using System.Linq;

namespace day_2021_12_08
{
    public static class Display
    {
        private static string[] Digits = new string []
        {
            "abcefg",
            "cf",
            "acdeg",
            "acdfg",
            "bcdf",
            "abdfg",
            "abdefg",
            "acf",
            "abcdefg",
            "abcdfg"
        };
        
        public static int GetDigit(string chars)
        {
            chars = new string(chars.OrderBy(ch => ch).ToArray());
            return Enumerable.Range(0, Digits.Length).First(id => Digits[id] == chars);
        }
    }
}