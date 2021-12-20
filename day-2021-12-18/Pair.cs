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

    public void ReplaceWithZero(Pair pair)
    {
        if (Left == pair)
            Left = new Number(0);
        else
            Right = new Number(0);
    }
    
    public override string ToString() => $"[{Left},{Right}]";
}