using NUnit.Framework;

namespace day_2021_12_09.tests
{
    public class SolverTests
    {
        private const string Data = @"
2199943210
3987894921
9856789892
8767896789
9899965678"; 
        
        [Test]
        public void Part1()
        {
            Assert.That(Solver.Part1(Parser.Parse(Data)), Is.EqualTo(15));
        }
        
        [Test]
        public void Part2()
        {
            Assert.That(Solver.Part2(Parser.Parse(Data)), Is.EqualTo(1134));
        }
    }
}