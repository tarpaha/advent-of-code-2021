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

    public static long Part2(Data data)
    {
        var packet = Decoder.Decode(data.Message);
        return Calculate(packet);
    }

    private static long Calculate(Packet packet)
    {
        if (packet is LiteralPacket literalPacket)
            return literalPacket.Number;

        var operatorPacket = (OperatorPacket)packet;
        var numbers = operatorPacket.Packets.Select(Calculate).ToList();

        return operatorPacket.Type switch
        {
            OperatorType.Sum => numbers.Sum(),
            OperatorType.Product => numbers.Aggregate((m, n) => m * n),
            OperatorType.Minimum => numbers.Min(),
            OperatorType.Maximum => numbers.Max(),
            OperatorType.Greater => numbers[0] >  numbers[1] ? 1L : 0L,
            OperatorType.Less    => numbers[0] <  numbers[1] ? 1L : 0L,
            OperatorType.Equal   => numbers[0] == numbers[1] ? 1L : 0L,
            _ => throw new Exception()
        };
    }
}