namespace day_2021_12_18;

public class Number : SN
{
    public long Value { get; private set; }
    
    public Number(long value)
    {
        Value = value;
    }

    public void Add(long value)
    {
        Value += value;
    }
    
    public override string ToString() => Value.ToString();
}