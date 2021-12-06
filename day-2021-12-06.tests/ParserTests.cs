using System.Linq;
using NUnit.Framework;

namespace day_2021_12_06.tests
{
    public class ParserTests
    {
        [Test]
        public void Parser_Works_Correctly()
        {
            var numbers = Parser.Parse("3,4,3,1,2").ToList();
            Assert.That(numbers, Is.EquivalentTo(new [] {3, 4, 3, 1, 2}));
        }
    }
}