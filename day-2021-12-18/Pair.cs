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

    public void ReplaceWith(SN numberToReplace, SN replacer)
    {
        if (Left == numberToReplace)
            Left = replacer;
        else
            Right = replacer;
        replacer.Parent = this;
    }
    
    public override string ToString() => $"[{Left},{Right}]";
}