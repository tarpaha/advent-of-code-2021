using System.Linq;
using NUnit.Framework;

namespace day_2021_12_13.tests;

public class ParserTests
{
    [Test]
    public void Parser_Works_Correctly()
    {
        var data = Parser.Parse(@"
6,10
0,14
9,10
0,3
10,4
4,11
6,0
6,12
4,1
0,13
10,12
3,4
3,0
8,4
1,10
2,14
8,10
9,0

fold along y=7
fold along x=5");
        
        Assert.That(data.Dots.Count(), Is.EqualTo(18));
        Assert.That(data.Folds.Count(), Is.EqualTo(2));
        
        Assert.That(data.Folds.Contains((Data.Fold.Horz, 7)), Is.True);
        Assert.That(data.Folds.Contains((Data.Fold.Vert, 5)), Is.True);
    }
}