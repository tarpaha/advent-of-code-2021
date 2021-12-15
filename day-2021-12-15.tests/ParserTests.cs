using System.Linq;
using NUnit.Framework;

namespace day_2021_12_15.tests;

public class ParserTests
{
    [Test]
    public void Parser_Works_Correctly()
    {
        var data = Parser.Parse(@"
1163751742
1381373672
2136511328
3694931569
7463417111
1319128137
1359912421
3125421639
1293138521
2311944581");
        Assert.That(data.Size, Is.EqualTo(10));
        Assert.That(data.Numbers.Count(), Is.EqualTo(100));
    }
}