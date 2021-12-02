using NUnit.Framework;

namespace day_2021_12_02.tests
{
    public class SolverTests
    {
        private const string Data = @"
forward 5
down 5
forward 8
up 3
down 8
forward 2";

        private const int Part1Result = 150;
        
        [Test]
        public void Part1()
        {
            Assert.That(Solver.Part1(Parser.Parse(Data)), Is.EqualTo(Part1Result));
        }

        [Test]
        public void Part2()
        {
            Assert.That(Solver.Part2(), Is.Null);
        }
    }
}