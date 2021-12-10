namespace day_2021_12_10;

public class Data
{
    public IEnumerable<string> Lines { get; }

    public Data(IEnumerable<string> lines)
    {
        Lines = new List<string>(lines);
    }
}