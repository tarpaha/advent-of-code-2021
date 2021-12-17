using NUnit.Framework;

namespace day_2021_12_17.tests;

public class SolverTests
{
    [TestCase("target area: x=20..30, y=-10..-5", 45)]
    public void Part1(string input, int result)
    {
        Assert.That(Solver.Part1(Parser.Parse(input)), Is.EqualTo(result));
    }
    
    [Test]
    public void Part2()
    {
        Assert.Pass();
    }
}