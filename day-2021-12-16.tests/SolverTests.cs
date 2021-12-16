using NUnit.Framework;

namespace day_2021_12_16.tests;

public class SolverTests
{
    [TestCase("8A004A801A8002F478", 16)]
    [TestCase("620080001611562C8802118E34", 12)]
    [TestCase("C0015000016115A2E0802F182340", 23)]
    [TestCase("A0016C880162017C3686B18A3D4780", 31)]
    public void Part1(string data, int result)
    {
        Assert.That(Solver.Part1(Parser.Parse(data)), Is.EqualTo(result));
    }
    
    [Test]
    public void Part2()
    {
        Assert.Pass();
    }
}