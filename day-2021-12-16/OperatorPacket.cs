namespace day_2021_12_16;

public class OperatorPacket : Packet
{
    public OperatorType Type { get; }
    public IEnumerable<Packet> Packets => _packets;

    private readonly List<Packet> _packets;

    public OperatorPacket(int version, OperatorType type, IEnumerable<Packet> packets) : base(version)
    {
        Type = type;
        _packets = new List<Packet>(packets);
    }

    public override string ToString()
    {
        return $"{Type}(v{Version}):" + " { " + string.Join(", ", _packets.Select(p => p.ToString())) + " }";
    }
    
    // equality comparer for tests

    private bool Equals(OperatorPacket other)
    {
        if (!base.Equals(other))
            return false;
        if (Type != other.Type)
            return false;
        if (_packets.Count != other._packets.Count)
            return false;
        for (var i = 0; i < _packets.Count; i++)
        {
            if (!_packets[i].Equals(other._packets[i]))
                return false;
        }
        return true;
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((OperatorPacket)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(base.GetHashCode(), _packets, (int)Type);
    }
}