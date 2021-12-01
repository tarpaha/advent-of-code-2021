using NUnit.Framework;

namespace day_2021_12_01.tests
{
    public class SolverTests
    {
        private const string TestData = @"
199
200
208
210
200
207
240
269
260
263";

        [Test]
        public void Part1()
        {
            Assert.That(Solver.Part1(Parser.Parse(TestData)), Is.EqualTo(7));
        }
        
        [Test]
        public void Part2()
        {
            Assert.That(Solver.Part2(), Is.Null);
        }
    }
}