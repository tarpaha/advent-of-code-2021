﻿namespace day_2021_12_16;

public class LiteralPacket : Packet
{
    public int Number { get; }

    public LiteralPacket(int version, int number) : base(version, OperatorType.Number)
    {
        Number = number;
    }

    public override string ToString()
    {
        return $"Literal(v{Version}): {Number}";
    }
    
    // equality comparer for tests

    private bool Equals(LiteralPacket other)
    {
        return base.Equals(other) && Number == other.Number;
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((LiteralPacket)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(base.GetHashCode(), Number);
    }
}