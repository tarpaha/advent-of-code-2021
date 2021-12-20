using NUnit.Framework;

namespace day_2021_12_18.tests;

public class SolverTests
{
    private const string Data = @"";

    [TestCase("[1,2]", "[[3,4],5]", "[[1,2],[[3,4],5]]")]
    public void Add_Works_Correctly(string str1, string str2, string resultStr)
    {
        var n1 = Parser.ParseSnailfishNumber(str1);
        var n2 = Parser.ParseSnailfishNumber(str2);
        Assert.That(Solver.Add(n1, n2).ToString(), Is.EqualTo(resultStr));
    }
    
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