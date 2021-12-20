namespace day_2021_12_18;

public class Pair : SN
{
    public SN Left { get; }
    public SN Right { get; }

    public Pair(SN left, SN right)
    {
        Left = left;
        Right = right;
    }

    public override string ToString() => $"[{Left},{Right}]";
}