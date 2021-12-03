using NUnit.Framework;

namespace day_2021_12_03.tests
{
    public class SolverTests
    {
        private const string Data = @"
00100
11110
10110
10111
10101
01111
00111
11100
10000
11001
00010
01010";

        [Test]
        public void CalculateGammaRateString_Works_Correctly()
        {
            Assert.That(Solver.CalculateGammaRateString(Parser.Parse(Data)), Is.EqualTo("10110"));
        }

        [TestCase("10110", "01001")]
        public void InvertBinaryNumber(string number, string result)
        {
            Assert.That(Solver.InvertBinaryNumber(number), Is.EqualTo(result));
        }
        
        [Test]
        public void Part1()
        {
            Assert.That(Solver.Part1(Parser.Parse(Data)), Is.EqualTo(198));
        }

        [Test]
        public void Part2()
        {
            Assert.That(Solver.Part2(), Is.Null);
        }
    }
}