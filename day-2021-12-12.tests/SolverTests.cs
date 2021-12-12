using NUnit.Framework;

namespace day_2021_12_12.tests;

public class SolverTests
{
    private const string Data = @"
start-A
start-b
A-c
A-b
b-d
A-end
b-end";

    [TestCase(@"
start-A
start-b
A-c
A-b
b-d
A-end
b-end", 10)]
    [TestCase(@"
dc-end
HN-start
start-kj
dc-start
dc-HN
LN-dc
HN-end
kj-sa
kj-HN
kj-dc", 19)]
    [TestCase(@"
fs-end
he-DX
fs-he
start-DX
pj-DX
end-zg
zg-sl
zg-pj
pj-he
RW-he
fs-DX
pj-RW
zg-RW
start-pj
he-WI
zg-he
pj-fs
start-RW", 226)]
    public void Part1(string data, int result)
    {
        Assert.That(Solver.Part1(Parser.Parse(data)), Is.EqualTo(result));
    }
    
    [TestCase(@"
start-A
start-b
A-c
A-b
b-d
A-end
b-end", 36)]
    public void Part2(string data, int result)
    {
        Assert.That(Solver.Part2(Parser.Parse(data)), Is.EqualTo(result));
    }
}