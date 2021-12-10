using NUnit.Framework;

namespace day_2021_12_10.tests;

public class SolverTests
{
    private const string Data = @"
[({(<(())[]>[[{[]{<()<>>
[(()[<>])]({[<{<<[]>>(
{([(<{}[<>[]}>{[]{[(<()>
(((({<>}<{<{<>}{[]{[]{}
[[<[([]))<([[{}[[()]]]
[{[{({}]{}}([{[{{{}}([]
{<[[]]>}<{[{[{[]{()[[[]
[<(<(<(<{}))><([]([]()
<{([([[(<>()){}]>(<<{{
<{([{{}}[<[[[<>{}]]]>[]]";

    [TestCase("()", null)]
    [TestCase("[]", null)]
    [TestCase("([])", null)]
    [TestCase("{()()()}", null)]
    [TestCase("<([{}])>", null)]
    [TestCase("[<>({}){}[([])<>]]", null)]
    [TestCase("(((((((((())))))))))", null)]    
    [TestCase("[({(<(())[]>[[{[]{<()<>>", null)]
    [TestCase("{([(<{}[<>[]}>{[]{[(<()>", '}')]
    [TestCase("[[<[([]))<([[{}[[()]]]", ')')]
    [TestCase("[{[{({}]{}}([{[{{{}}([]", ']')]
    [TestCase("[<(<(<(<{}))><([]([]()", ')')]
    [TestCase("<{([([[(<>()){}]>(<<{{", '>')]
    public void GetInvalidChar_Works_Correctly(string line, char? result)
    {
        Assert.That(Solver.GetInvalidChar(line), Is.EqualTo(result));
    }
    
    [Test]
    public void Part1()
    {
        Assert.That(Solver.Part1(Parser.Parse(Data)), Is.EqualTo(26397));
    }

    [TestCase("[({(<(())[]>[[{[]{<()<>>", "}}]])})]")]
    [TestCase("[(()[<>])]({[<{<<[]>>(", ")}>]})")]
    [TestCase("(((({<>}<{<{<>}{[]{[]{}", "}}>}>))))")]
    [TestCase("{<[[]]>}<{[{[{[]{()[[[]", "]]}}]}]}>")]
    [TestCase("<{([{{}}[<[[[<>{}]]]>[]]", "])}>")]
    public void GetClosingCharacters_Works_Correctly(string line, string result)
    {
        Assert.That(Solver.GetClosingCharacters(line), Is.EqualTo(result));
    }

    [TestCase("}}]])})]", 288957)]
    [TestCase(")}>]})", 5566)]
    [TestCase("}}>}>))))", 1480781)]
    [TestCase("]]}}]}]}>", 995444)]
    [TestCase("])}>", 294)]
    public void CalculateStringCompletionScore_Works_Correctly(string line, long result)
    {
        Assert.That(Solver.CalculateStringCompletionScore(line), Is.EqualTo(result));
    }
    
    [Test]
    public void Part2()
    {
        Assert.That(Solver.Part2(Parser.Parse(Data)), Is.EqualTo(288957));
    }
}