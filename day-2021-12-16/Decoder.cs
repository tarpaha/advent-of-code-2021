namespace day_2021_12_16;

public static class Decoder
{
    private const int VersionBitLength = 3;
    private const int TypeIdBitLength = 3;

    private const int LiteralTypeId = 4;
    private const int LiteralNumberChunkSize = 4;

    private const int BitsCountLength = 15;
    private const int NumbersCountLength = 11;
    
    public static Packet Decode(string message)
    {
        var pos = 0;
        return Decode(ConvertHexStringToBinary(message), ref pos);
    }

    private static Packet Decode(IReadOnlyList<int> bits, ref int pos)
    {
        var version = ReadBits(bits, VersionBitLength, ref pos);
        var typeId = ReadBits(bits, TypeIdBitLength, ref pos);
        
        if (typeId == LiteralTypeId)
            return new LiteralPacket(version, ReadLiteralNumber(bits, ref pos));

        var packets = bits[pos++] == 0
            ? ReadPacketsWithBitsLimit(bits, ref pos)
            : ReadPacketsWithCountLimit(bits, ref pos);
        return new OperatorPacket(version, packets);
    }

    private static int ReadLiteralNumber(IReadOnlyList<int> bits, ref int pos)
    {
        var number = 0;
        while (true)
        {
            var lastChunk = bits[pos++] == 0;
            number <<= LiteralNumberChunkSize;
            number += ReadBits(bits, LiteralNumberChunkSize, ref pos);
            if (lastChunk)
                break;
        }
        return number;
    }

    private static IEnumerable<Packet> ReadPacketsWithBitsLimit(IReadOnlyList<int> bits, ref int pos)
    {
        var length = ReadBits(bits, BitsCountLength, ref pos);
        var endPos = pos + length;
        var packets = new List<Packet>();
        while (pos < endPos)
        {
            packets.Add(Decode(bits, ref pos));
        }
        return packets;
    }

    private static IEnumerable<Packet> ReadPacketsWithCountLimit(IReadOnlyList<int> bits, ref int pos)
    {
        var count = ReadBits(bits, NumbersCountLength, ref pos);
        var packets = new List<Packet>();
        for (var i = 0; i < count; i++)
        {
            packets.Add(Decode(bits, ref pos));
        }
        return packets;
    }
    
    private static int ReadBits(IReadOnlyList<int> bits, int count, ref int pos)
    {
        var number = 0;
        for (var i = 0; i < count; i++)
        {
            number <<= 1;
            number += bits[pos++];
        }
        return number;
    }

    public static int[] ConvertHexStringToBinary(string str)
    {
        var bits = new int[str.Length * 4];
        var p = 0;
        foreach (var number in str.Select(ch => ch <= '9' ? ch - '0' : ch - 'A' + 10))
        {
            bits[p++] = (number & 0b1000) != 0 ? 1 : 0; 
            bits[p++] = (number & 0b0100) != 0 ? 1 : 0; 
            bits[p++] = (number & 0b0010) != 0 ? 1 : 0; 
            bits[p++] = (number & 0b0001) != 0 ? 1 : 0;
        }
        return bits;
    }
}