using System.Linq;
using NUnit.Framework;

namespace day_2021_12_08.tests
{
    public class ParserTests
    {
        [TestCase(@"acedgfb cdfbe gcdfa fbcad dab cefabd cdfgeb eafb cagedb ab | cdfeb fcadb cdfeb cdbaf", 10, 4)]
        public void ParseLine_Works_Correctly(string data, int digitsCount, int outputCount)
        {
            var entry = Parser.ParseLine(data);
            
            Assert.That(entry.Digits.Length, Is.EqualTo(digitsCount));
            Assert.That(entry.Output.Length, Is.EqualTo(outputCount));
            
            Assert.That(entry.Digits.SelectMany(s => s).All(char.IsLetter), Is.True);
            Assert.That(entry.Output.SelectMany(s => s).All(char.IsLetter), Is.True);
        }
    }
}