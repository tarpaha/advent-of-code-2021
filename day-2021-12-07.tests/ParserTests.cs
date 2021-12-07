using NUnit.Framework;

namespace day_2021_12_07.tests
{
    public class ParserTests
    {
        [Test]
        public void Parser_Works_Correctly()
        {
            Assert.That(
                Parser.Parse("16,1,2,0,4,2,7,1,2,14"),
                Is.EquivalentTo(new [] { 16, 1, 2, 0, 4, 2, 7, 1, 2, 14 }));
        }
    }
}