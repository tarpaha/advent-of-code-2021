using NUnit.Framework;

namespace day_2021_12_10.tests;

public class ParserTests
{
    [Test]
    public void Parser_Works_Correctly()
    {
        Assert.That(Parser.Parse(""), Is.Not.Null);
    }
}