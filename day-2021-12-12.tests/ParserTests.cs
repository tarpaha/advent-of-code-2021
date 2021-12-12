using System.Linq;
using NUnit.Framework;

namespace day_2021_12_12.tests;

public class ParserTests
{
    [Test]
    public void Parser_Works_Correctly()
    {
        var data = Parser.Parse(@"
start-A
start-b
A-c
A-b
b-d
A-end
b-end");
        Assert.That(data.Pairs.Count(), Is.EqualTo(7));
    }
}