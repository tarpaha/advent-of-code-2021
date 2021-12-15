using NUnit.Framework;

namespace day_2021_12_15.tests;

public class SolverTests
{
    [TestCase(@"
39999
19111
11191", 8)]
    [TestCase(@"
1163751742
1381373672
2136511328
3694931569
7463417111
1319128137
1359912421
3125421639
1293138521
2311944581", 40)]
    public void Part1(string data, int result)
    {
        Assert.That(Solver.Part1(Parser.Parse(data)), Is.EqualTo(result));
    }
    
    [Test]
    public void Part2()
    {
        Assert.Pass();
    }
}