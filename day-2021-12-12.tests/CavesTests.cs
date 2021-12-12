using System.Linq;
using NUnit.Framework;

namespace day_2021_12_12.tests;

public class CavesTests
{
    [Test]
    public void Caves_Construction_Works_Correctly()
    {
        var caves = new Caves(Parser.Parse(@"
start-A
start-b
A-c
A-b
b-d
A-end
b-end"));
        Assert.That(caves.GetLinkedCaves("start").OrderBy(s => s), Is.EquivalentTo(new [] { "A", "b" }.OrderBy(s => s)));
        Assert.That(caves.GetLinkedCaves("end").OrderBy(s => s), Is.EquivalentTo(new [] { "A", "b" }.OrderBy(s => s)));
        Assert.That(caves.GetLinkedCaves("A").OrderBy(s => s), Is.EquivalentTo(new [] { "c", "start", "b", "end" }.OrderBy(s => s)));
        Assert.That(caves.GetLinkedCaves("b").OrderBy(s => s), Is.EquivalentTo(new [] { "A", "start", "d", "end" }.OrderBy(s => s)));
    }
}