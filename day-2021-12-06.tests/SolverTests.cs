using NUnit.Framework;

namespace day_2021_12_06.tests
{
    public class SolverTests
    {
        [TestCase("3,4,3,1,2", 18, 26)]
        [TestCase("3,4,3,1,2", 80, 5934)]
        public void Part1(string data, int days, int count)
        {
            Assert.That(Solver.Part1(Parser.Parse(data), days), Is.EqualTo(count));
        }
        
        [Test]
        public void Part2()
        {
            Assert.That(Solver.Part2(), Is.Null);
        }
    }
}