using System.Linq;
using NUnit.Framework;

namespace day_2021_12_14.tests;

public class ParserTests
{
    [Test]
    public void Parser_Works_Correctly()
    {
        var data = Parser.Parse(@"
NNCB

CH -> B
HH -> N
CB -> H
NH -> C
HB -> C
HC -> B
HN -> C
NN -> C
BH -> H
NC -> B
NB -> B
BN -> B
BB -> N
BC -> B
CC -> N
CN -> C");
        Assert.That(data.Template, Is.EqualTo("NNCB"));
        Assert.That(data.Pairs.Count, Is.EqualTo(16));
    }
}