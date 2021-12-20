using NUnit.Framework;

namespace day_2021_12_18.tests;

public class SolverTests
{
    private const string Data = @"";

    [Test]
    public void Part1()
    {
        Assert.That(Solver.Part1(Parser.Parse(Data)), Is.Null);
    }
    
    [Test]
    public void Part2()
    {
        Assert.That(Solver.Part2(Parser.Parse(Data)), Is.Null);
    }
}