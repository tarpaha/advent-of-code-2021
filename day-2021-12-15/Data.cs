namespace day_2021_12_15;

public class Data
{
    public int Size { get; }
    public IEnumerable<int> Numbers { get; }

    public Data(int size, IEnumerable<int> numbers)
    {
        Size = size;
        Numbers = numbers;
    }
}