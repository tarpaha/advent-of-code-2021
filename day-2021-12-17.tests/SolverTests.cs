using NUnit.Framework;

namespace day_2021_12_17.tests;

public class SolverTests
{
    [TestCase("target area: x=20..30, y=-10..-5", 45)]
    public void Part1(string input, int result)
    {
        Assert.That(Solver.Part1(Parser.Parse(input)), Is.EqualTo(result));
    }
    
    [TestCase("target area: x=20..30, y=-10..-5", 112)]
    public void Part2(string input, int result)
    {
        Assert.That(Solver.Part2(Parser.Parse(input)), Is.EqualTo(result));
    }
}