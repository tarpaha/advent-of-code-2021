namespace day_2021_12_09;

public class Field
{
    public int Width { get; }
    public int Height { get; }

    public int Number(int x, int y) => _numbers[x  + y * Width];

    private readonly List<int> _numbers;

    public Field(int width, int height, IEnumerable<int> numbers)
    {
        Width = width;
        Height = height;
        _numbers = new List<int>(numbers);
    }
}