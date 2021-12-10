using System.Linq;
using NUnit.Framework;

namespace day_2021_12_10.tests;

public class ParserTests
{
    [Test]
    public void Parser_Works_Correctly()
    {
        var data = Parser.Parse(@"
[({(<(())[]>[[{[]{<()<>>
[(()[<>])]({[<{<<[]>>(
{([(<{}[<>[]}>{[]{[(<()>
(((({<>}<{<{<>}{[]{[]{}
[[<[([]))<([[{}[[()]]]
[{[{({}]{}}([{[{{{}}([]
{<[[]]>}<{[{[{[]{()[[[]
[<(<(<(<{}))><([]([]()
<{([([[(<>()){}]>(<<{{
<{([{{}}[<[[[<>{}]]]>[]]");
        Assert.That(data.Lines.Count(), Is.EqualTo(10));
    }
}