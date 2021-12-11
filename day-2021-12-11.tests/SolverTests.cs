using NUnit.Framework;

namespace day_2021_12_11.tests;

public class SolverTests
{
    private const string Data = @"
5483143223
2745854711
5264556173
6141336146
6357385478
4167524645
2176841721
6882881134
4846848554
5283751526";

    [Test]
    public void Step_Works_Correctly()
    {
        var grid = new Grid(Parser.Parse(@"
11111
19991
19191
19991
11111"));
        Solver.Step(grid);
        Assert.That(grid.ToString(), Is.EqualTo(@"34543
40004
50005
40004
34543"));
        Solver.Step(grid);
        Assert.That(grid.ToString(), Is.EqualTo(@"45654
51115
61116
51115
45654"));    }

    [Test]
    public void Steps_Works_Correctly()
    {
        var grid = new Grid(Parser.Parse(Data));
        Assert.That(Solver.Steps(grid, 10), Is.EqualTo(204));
    }
    
    [Test]
    public void Part1()
    {
        Assert.That(Solver.Part1(Parser.Parse(Data)), Is.EqualTo(1656));
    }
    
    [Test]
    public void Part2()
    {
        Assert.That(Solver.Part2(Parser.Parse(Data)), Is.EqualTo(195));
    }
}