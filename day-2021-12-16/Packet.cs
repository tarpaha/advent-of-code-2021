namespace day_2021_12_16;

public abstract class Packet
{
    public int Version { get; }
    public OperatorType Type { get; }
    
    protected Packet(int version, OperatorType type)
    {
        Version = version;
        Type = type;
    }

    // equality comparer for tests

    protected bool Equals(Packet other)
    {
        return Version == other.Version && Type == other.Type;
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((Packet)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Version, (int)Type);
    }
}