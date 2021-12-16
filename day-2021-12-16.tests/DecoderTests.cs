using System.Linq;
using NUnit.Framework;

namespace day_2021_12_16.tests;

public class DecoderTests
{
    [TestCase("4", "0100")]
    [TestCase("D", "1101")]
    [TestCase("D2FE28", "110100101111111000101000")]
    [TestCase("38006F45291200", "00111000000000000110111101000101001010010001001000000000")]
    public void ConvertHexStringToBinary_Works_Correctly(string str, string resultStr)
    {
        var result = resultStr.Select(ch => ch - '0').ToList();
        Assert.That(Decoder.ConvertHexStringToBinary(str), Is.EquivalentTo(result));
    }
}