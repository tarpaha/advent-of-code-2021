namespace day_2021_12_16;

public abstract class Packet
{
    public int Version { get; }
    
    protected Packet(int version)
    {
        Version = version;
    }

    // equality comparer for tests
    
    private bool Equals(Packet other)
    {
        return Version == other.Version;
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
        return Version;
    }
}