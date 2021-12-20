namespace day_2021_12_18;

public class Number : SN
{
    public int Value { get; }
    
    public Number(int value)
    {
        Value = value;
    }

    public override string ToString() => Value.ToString();
}