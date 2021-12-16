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
    
    [TestCase("C200B40A82", 3)]
    [TestCase("04005AC33890", 54)]
    [TestCase("880086C3E88112", 7)]
    [TestCase("CE00C43D881120", 9)]
    [TestCase("D8005AC2A8F0", 1)]
    [TestCase("F600BC2D8F", 0)]
    [TestCase("9C005AC2F8F0", 0)]
    [TestCase("9C0141080250320F1802104A08", 1)]
    public void Part2(string data, int result)
    {
        Assert.That(Solver.Part2(Parser.Parse(data)), Is.EqualTo(result));
    }
}