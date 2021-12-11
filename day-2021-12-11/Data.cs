namespace day_2021_12_11;

public class Data
{
    public int Width { get; }
    public int Height { get; }
    public IEnumerable<int> Digits { get; }

    public Data(int width, int height, IEnumerable<int> digits)
    {
        Width = width;
        Height = height;
        Digits = new List<int>(digits);
    }
}