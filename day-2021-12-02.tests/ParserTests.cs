using System.Linq;
using NUnit.Framework;

namespace day_2021_12_02.tests
{
    public class ParserTests
    {
        [TestCase("forward 5", 5, 0)]
        [TestCase("down 4", 0, 4)] 
        [TestCase("up 3", 0, -3)]
        public void Parser_Works_Right(string line, int x, int y)
        {
            var commands = Parser.Parse(line).ToList();
            Assert.That(commands.Count, Is.EqualTo(1));
            Assert.That(commands.First(), Is.EqualTo((x, y)));
        }
    }
}