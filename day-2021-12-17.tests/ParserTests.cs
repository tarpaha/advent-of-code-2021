using NUnit.Framework;

namespace day_2021_12_17.tests;

public class ParserTests
{
    [TestCase("target area: x=20..30, y=-10..-5", 20, 30, -10, -5)]
    public void Parser_Works_Correctly(string input, int xMin, int xMax, int yMin, int yMax)
    {
        var data = Parser.Parse(input);
        Assert.That(data.XMin, Is.EqualTo(xMin));
        Assert.That(data.XMax, Is.EqualTo(xMax));
        Assert.That(data.YMin, Is.EqualTo(yMin));
        Assert.That(data.YMax, Is.EqualTo(yMax));
    }
}