using NUnit.Framework;

namespace day_2021_12_16.tests;

public class ParserTests
{
    [TestCase("D2FE28", "D2FE28")]
    public void Parser_Works_Correctly(string data, string message)
    {
        Assert.That(Parser.Parse(data).Message, Is.EqualTo(message));
    }
}