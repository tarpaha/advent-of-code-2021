namespace day_2021_12_16;

public static class Solver
{
    public static int Part1(Data data)
    {
        var packet = Decoder.Decode(data.Message);
        return SumVersionNumbers(packet);
    }

    private static int SumVersionNumbers(Packet packet)
    {
        return packet switch
        {
            LiteralPacket literalPacket => literalPacket.Version,
            OperatorPacket operatorPacket => operatorPacket.Version + operatorPacket.Packets.Sum(SumVersionNumbers),
            _ => throw new ArgumentOutOfRangeException(nameof(packet))
        };
    }

    public static object Part2(Data data)
    {
        return null!;
    }
}