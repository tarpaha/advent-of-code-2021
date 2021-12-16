using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace day_2021_12_16.tests;

public class DecoderTests
{
    [TestCase("4", "0100")]
    [TestCase("D", "1101")]
    [TestCase("D2FE28", "110100101111111000101000")]
    [TestCase("38006F45291200", "00111000000000000110111101000101001010010001001000000000")]
    [TestCase("EE00D40C823060", "11101110000000001101010000001100100000100011000001100000")]
    public void ConvertHexStringToBinary_Works_Correctly(string str, string resultStr)
    {
        var result = resultStr.Select(ch => ch - '0').ToList();
        Assert.That(Decoder.ConvertHexStringToBinary(str), Is.EquivalentTo(result));
    }
    
    private static IEnumerable<TestCaseData> DecoderTestCases
    {
        get
        {
            yield return new TestCaseData("D2FE28", new LiteralPacket(6, 2021));
            yield return new TestCaseData("38006F45291200", new OperatorPacket(1, new [] { new LiteralPacket(6, 10), new LiteralPacket(2, 20) }));
            yield return new TestCaseData("EE00D40C823060", new OperatorPacket(7, new [] { new LiteralPacket(2, 1), new LiteralPacket(4, 2), new LiteralPacket(1, 3) }));
            yield return new TestCaseData("8A004A801A8002F478", new OperatorPacket(4, new [] { new OperatorPacket(1, new [] { new OperatorPacket(5, new []{ new LiteralPacket(6, 15) }) }) }));
        }
    }

    [TestCaseSource(nameof(DecoderTestCases))]
    public void Decoder_Works_Correctly(string message, Packet result)
    {
        Assert.That(Decoder.Decode(message), Is.EqualTo(result));
    }
}