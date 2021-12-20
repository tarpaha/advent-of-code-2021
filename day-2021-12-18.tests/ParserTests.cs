using NUnit.Framework;

namespace day_2021_12_18.tests;

public class ParserTests
{
    [TestCase("[1,2]")]
    [TestCase("[[1,2],3]")]
    [TestCase("[9,[8,7]]")]
    [TestCase("[[1,9],[8,5]]")]
    [TestCase("[[[[1,2],[3,4]],[[5,6],[7,8]]],9]")]
    [TestCase("[[[9,[3,8]],[[0,9],6]],[[[3,7],[4,9]],3]]")]
    [TestCase("[[[[1,3],[5,3]],[[1,3],[8,7]]],[[[4,9],[6,9]],[[8,2],[7,3]]]]")]    
    public void ParseSnailfishNumber_Works_Correctly(string str)
    {
        var sn = Parser.ParseSnailfishNumber(str);
        Assert.That(sn.ToString(), Is.EqualTo(str));
    }
}