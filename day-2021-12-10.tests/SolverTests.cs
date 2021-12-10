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
    
    [Test]
    public void Part2()
    {
        Assert.That(Solver.Part2(Parser.Parse(Data)), Is.Null);
    }
}