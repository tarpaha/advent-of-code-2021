using System.Linq;
using NUnit.Framework;

namespace day_2021_12_15.tests;

public class ParserTests
{
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
2311944581", 10, 10)]
    [TestCase(@"
19999
19111
11191", 5, 3)]
    public void Parser_Works_Correctly(string str, int width, int height)
    {
        var data = Parser.Parse(str);
        Assert.That(data.Width, Is.EqualTo(width));
        Assert.That(data.Height, Is.EqualTo(height));
        Assert.That(data.Numbers.Count(), Is.EqualTo(width * height));
    }
}