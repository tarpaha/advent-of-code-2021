namespace day_2021_12_09;

public class Field
{
    public int Width { get; }
    public int Height { get; }

    public int Number(int x, int y) => _numbers[(x, y)];

    private readonly Dictionary<(int, int), int> _numbers = new();

    public Field(int width, int height, IEnumerable<int> numbers)
    {
        Width = width;
        Height = height;

        var x = 0;
        var y = 0;
        foreach (var number in numbers)
        {
            _numbers[(x, y)] = number;
            x += 1;
            if (x >= width)
            {
                y += 1;
                x = 0;
            }
        }
    }
}