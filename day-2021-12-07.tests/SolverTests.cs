using NUnit.Framework;

namespace day_2021_12_07.tests
{
    public class SolverTests
    {
        [TestCase("16,1,2,0,4,2,7,1,2,14", 37)]
        public void Part1(string data, int result)
        {
            Assert.That(Solver.Part1(Parser.Parse(data)), Is.EqualTo(result));
        }
        
        [TestCase("16,1,2,0,4,2,7,1,2,14", 168)]
        public void Part2(string data, int result)
        {
            Assert.That(Solver.Part2(Parser.Parse(data)), Is.EqualTo(result));
        }

        [TestCase("16,1,2,0,4,2,7,1,2,14", 2, 37)]
        [TestCase("16,1,2,0,4,2,7,1,2,14", 1, 41)]
        [TestCase("16,1,2,0,4,2,7,1,2,14", 3, 39)]
        public void CalculateTotalFuel_Works_Correctly(string data, int center, int totalFuel)
        {
            Assert.That(Solver.CalculateTotalFuel(Parser.Parse(data), center), Is.EqualTo(totalFuel));
        }

        [TestCase("16,1,2,0,4,2,7,1,2,14", 5, 168)]
        [TestCase("16,1,2,0,4,2,7,1,2,14", 2, 206)]
        public void CalculateTotalFuelExpensive_Works_Correctly(string data, int center, int totalFuel)
        {
            Assert.That(Solver.CalculateTotalFuelExpensive(Parser.Parse(data), center), Is.EqualTo(totalFuel));
        }
    }
}