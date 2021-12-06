using System.Linq;
using NUnit.Framework;

namespace day_2021_12_05.tests
{
    public class ParserTests
    {
        [Test]
        public void A()
        {
            const string data = @"
0,9 -> 5,9
8,0 -> 0,8
9,4 -> 3,4
2,2 -> 2,1
7,0 -> 7,4
6,4 -> 2,0
0,9 -> 2,9
3,4 -> 1,4
0,0 -> 8,8
5,5 -> 8,2";
            var lines = Parser.Parse(data).ToList();
            Assert.That(lines.Count, Is.EqualTo(10));
            var line = lines.Last();
            Assert.That((line.X1, line.Y1, line.X2, line.Y2), Is.EqualTo((5, 5, 8, 2)));
        }
    }
}