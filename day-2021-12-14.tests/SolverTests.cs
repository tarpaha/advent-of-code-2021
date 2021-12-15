using NUnit.Framework;

namespace day_2021_12_14.tests;

public class SolverTests
{
    private const string Data = @"
NNCB

CH -> B
HH -> N
CB -> H
NH -> C
HB -> C
HC -> B
HN -> C
NN -> C
BH -> H
NC -> B
NB -> B
BN -> B
BB -> N
BC -> B
CC -> N
CN -> C";

    [TestCase(1, "NCNBCHB")]
    [TestCase(2, "NBCCNBBBCBHCB")]
    [TestCase(3, "NBBBCNCCNBBNBNBBCHBHHBCHB")]
    [TestCase(4, "NBBNBNBBCCNBCNCCNBBNBBNBBBNBBNBBCBHCBHHNHCBBCBHCB")]
    public void ProcessSteps_Works_Correctly(int stepsCount, string result)
    {
        Assert.That(Solver.ProcessSteps(Parser.Parse(Data), stepsCount), Is.EqualTo(result));
    }
    
    [Test]
    public void Part1()
    {
        Assert.That(Solver.Part1(Parser.Parse(Data)), Is.EqualTo(1588));
    }

    [Test]
    public void ProcessStepsQuick_Works_Correctly()
    {
        Assert.That(Solver.ProcessStepsQuick(Parser.Parse(Data), 10), Is.EqualTo(1588));
    }
    
    [Test]
    public void Part2()
    {
        Assert.That(Solver.Part2(Parser.Parse(Data)), Is.EqualTo(2188189693529));
    }
}