namespace day_2021_12_18;

public class Pair : SN
{
    public SN Left { get; private set; }
    public SN Right { get; private set; }

    public Pair(SN left, SN right)
    {
        Left = left;
        Right = right;
        Left.Parent = Right.Parent = this;
    }

    public void ReplaceWith(SN pair, SN sn)
    {
        if (Left == pair)
            Left = sn;
        else
            Right = sn;
    }
    
    public override string ToString() => $"[{Left},{Right}]";
}