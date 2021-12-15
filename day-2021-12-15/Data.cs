namespace day_2021_12_15;

public class Data
{
    public int Width { get; }
    public int Height { get; }
    public IEnumerable<int> Numbers { get; }

    public Data(int width, int height, IEnumerable<int> numbers)
    {
        Width = width;
        Height = height;
        Numbers = numbers;
    }
}