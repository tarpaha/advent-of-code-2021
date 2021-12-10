namespace day_2021_12_09;

public class Field
{
    public int Width { get; }
    public int Height { get; }

    public int Number(int x, int y) => _numbers[x  + y * Width];
    public void SetNumber(int x, int y, int number) => _numbers[x + y * Width] = number;

    private readonly List<int> _numbers;

    public Field(int width, int height, IEnumerable<int> numbers)
    {
        Width = width;
        Height = height;
        _numbers = new List<int>(numbers);
    }
}