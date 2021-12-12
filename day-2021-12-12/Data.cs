namespace day_2021_12_12;

public class Data
{
    public IEnumerable<(string, string)> Pairs { get; }

    public Data(IEnumerable<(string, string)> pairs)
    {
        Pairs = new List<(string, string)>(pairs);
    }
}