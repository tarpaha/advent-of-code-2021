using NUnit.Framework;
using System.Collections.Generic;

namespace day_2021_12_11.tests;

public class ParserTests
{
    [Test]
    public void Parser_Works_Correctly()
    {
        var data = Parser.Parse(@"
5483143223
2745854711
5264556173
6141336146
6357385478
4167524645
2176841721
6882881134
4846848554
5283751526");
        Assert.That(data.Width, Is.EqualTo(10));
        Assert.That(data.Height, Is.EqualTo(10));
        
        var digits = new List<int>(data.Digits);
        Assert.That(digits.Count, Is.EqualTo(100));
        
        Assert.That(digits[0], Is.EqualTo(5));
        Assert.That(digits[9], Is.EqualTo(3));
        Assert.That(digits[90], Is.EqualTo(5));
        Assert.That(digits[99], Is.EqualTo(6));
    }
}