namespace day_2021_12_18;

public class Data
{
    public IEnumerable<SN> Numbers { get; }

    public Data(IEnumerable<SN> numbers)
    {
        Numbers = numbers;
    }
}