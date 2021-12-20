namespace day_2021_12_18;

public class Number : SN
{
    public int Value { get; private set; }
    
    public Number(int value)
    {
        Value = value;
    }

    public void Add(int value)
    {
        Value += value;
    }
    
    public override string ToString() => Value.ToString();
}