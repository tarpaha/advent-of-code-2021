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

    [TestCase("[[[[[9,8],1],2],3],4]", "[9,8]")]
    [TestCase("[7,[6,[5,[4,[3,2]]]]]", "[3,2]")]
    [TestCase("[[6,[5,[4,[3,2]]]],1]", "[3,2]")]
    [TestCase("[[3,[2,[1,[7,3]]]],[6,[5,[4,[3,2]]]]]", "[7,3]")]
    [TestCase("[[3,[2,[8,0]]],[9,[5,[4,[3,2]]]]]", "[3,2]")]
    public void FindReadyToExplodePair_Works_Correctly(string numberStr, string resultStr)
    {
        var number = Parser.ParseSnailfishNumber(numberStr);
        Assert.That(Solver.FindReadyToExplodePair(number)?.ToString(), Is.EqualTo(resultStr));
    }

    [TestCase("[[[[[9,8],1],2],3],4]", "[[[[0,9],2],3],4]")]
    [TestCase("[7,[6,[5,[4,[3,2]]]]]", "[7,[6,[5,[7,0]]]]")]
    [TestCase("[[6,[5,[4,[3,2]]]],1]", "[[6,[5,[7,0]]],3]")]
    [TestCase("[[3,[2,[1,[7,3]]]],[6,[5,[4,[3,2]]]]]", "[[3,[2,[8,0]]],[9,[5,[4,[3,2]]]]]")]
    [TestCase("[[3,[2,[8,0]]],[9,[5,[4,[3,2]]]]]", "[[3,[2,[8,0]]],[9,[5,[7,0]]]]")]
    public void Explode_Works_Correctly(string numberStr, string resultStr)
    {
        var number = Parser.ParseSnailfishNumber(numberStr);
        var explodingPair = Solver.FindReadyToExplodePair(number)!;
        Solver.Explode(explodingPair);
        Assert.That(number.ToString(), Is.EqualTo(resultStr));
    }

    [TestCase("[[[[0,7],4],[15,[0,13]]],[1,1]]", 15)]
    [TestCase("[[[[0,7],4],[[7,8],[0,13]]],[1,1]]", 13)]
    public void FindReadyToSplitNumber_Works_Correctly(string numberStr, int result)
    {
        var number = Parser.ParseSnailfishNumber(numberStr);
        Assert.That(Solver.FindReadyToSplitNumber(number)?.Value, Is.EqualTo(result));
    }
    
    [TestCase("10", "[5,5]")]
    [TestCase("11", "[5,6]")]
    [TestCase("12", "[6,6]")]
    public void Split_Works_Correctly(string numberStr, string resultStr)
    {
        var number = Parser.ParseSnailfishNumber(numberStr) as Number;
        Assert.That(Solver.Split(number!).ToString(), Is.EqualTo(resultStr));
    }

    [TestCase("[[[[[4,3],4],4],[7,[[8,4],9]]],[1,1]]", true, "[[[[0,7],4],[7,[[8,4],9]]],[1,1]]")]
    [TestCase("[[[[0,7],4],[7,[[8,4],9]]],[1,1]]", true, "[[[[0,7],4],[15,[0,13]]],[1,1]]")]
    [TestCase("[[[[0,7],4],[15,[0,13]]],[1,1]]", true, "[[[[0,7],4],[[7,8],[0,13]]],[1,1]]")]
    [TestCase("[[[[0,7],4],[[7,8],[0,13]]],[1,1]]", true, "[[[[0,7],4],[[7,8],[0,[6,7]]]],[1,1]]")]
    [TestCase("[[[[0,7],4],[[7,8],[0,[6,7]]]],[1,1]]", true, "[[[[0,7],4],[[7,8],[6,0]]],[8,1]]")]
    [TestCase("[[[[0,7],4],[[7,8],[6,0]]],[8,1]]", false, "[[[[0,7],4],[[7,8],[6,0]]],[8,1]]")]
    public void Reduce_Works_Correctly(string numberStr, bool resultReduced, string resultStr)
    {
        var number = Parser.ParseSnailfishNumber(numberStr);
        var reduced = Solver.Reduce(number);
        Assert.That(reduced, Is.EqualTo(resultReduced));
        Assert.That(number.ToString(), Is.EqualTo(resultStr));
    }

    [TestCase("[[[[4,3],4],4],[7,[[8,4],9]]]", "[1,1]", "[[[[0,7],4],[[7,8],[6,0]]],[8,1]]")]
    [TestCase("[[[0,[4,5]],[0,0]],[[[4,5],[2,6]],[9,5]]]", "[7,[[[3,7],[4,3]],[[6,3],[8,8]]]]", "[[[[4,0],[5,4]],[[7,7],[6,0]]],[[8,[7,7]],[[7,9],[5,0]]]]")]
    public void AddAndReduce_Works_Correctly(string str1, string str2, string resultStr)
    {
        var n1 = Parser.ParseSnailfishNumber(str1);
        var n2 = Parser.ParseSnailfishNumber(str2);
        Assert.That(Solver.AddAndReduce(n1, n2).ToString(), Is.EqualTo(resultStr));
    }

    [TestCase(@"
[1,1]
[2,2]
[3,3]
[4,4]", "[[[[1,1],[2,2]],[3,3]],[4,4]]")]
    [TestCase(@"
[1,1]
[2,2]
[3,3]
[4,4]
[5,5]", "[[[[3,0],[5,3]],[4,4]],[5,5]]")]
    [TestCase(@"
[1,1]
[2,2]
[3,3]
[4,4]
[5,5]
[6,6]", "[[[[5,0],[7,4]],[5,5]],[6,6]]")]
    [TestCase(@"
[[[0,[4,5]],[0,0]],[[[4,5],[2,6]],[9,5]]]
[7,[[[3,7],[4,3]],[[6,3],[8,8]]]]
[[2,[[0,8],[3,4]]],[[[6,7],1],[7,[1,6]]]]
[[[[2,4],7],[6,[0,5]]],[[[6,8],[2,8]],[[2,1],[4,5]]]]
[7,[5,[[3,8],[1,4]]]]
[[2,[2,2]],[8,[8,1]]]
[2,9]
[1,[[[9,3],9],[[9,0],[0,7]]]]
[[[5,[7,4]],7],1]
[[[[4,2],2],6],[8,7]]", "[[[[8,7],[7,7]],[[8,6],[7,7]]],[[[0,7],[6,6]],[8,7]]]")]
    public void FinalSum_Works_Correctly(string input, string resultStr)
    {
        var data = Parser.Parse(input);
        Assert.That(Solver.FinalSum(data.Numbers).ToString(), Is.EqualTo(resultStr));
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