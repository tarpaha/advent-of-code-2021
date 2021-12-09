using NUnit.Framework;

namespace day_2021_12_09.tests;

public class ParserTests
{
    [Test]
    public void Parser_Works_Correctly()
    {
        const string data = @"
2199943210
3987894921
9856789892
8767896789
9899965678";

        var field = Parser.Parse(data);
        Assert.That(field.Width, Is.EqualTo(10));
        Assert.That(field.Height, Is.EqualTo(5));
        
        Assert.That(field.Number(0, 0), Is.EqualTo(2));
        Assert.That(field.Number(9, 0), Is.EqualTo(0));
        Assert.That(field.Number(0, 4), Is.EqualTo(9));
        Assert.That(field.Number(9, 4), Is.EqualTo(8));
    }    
}