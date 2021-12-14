namespace day_2021_12_14;

public class Data
{
    public string Template { get; }
    public IEnumerable<(string, char)> Pairs { get; }

    public Data(string template, IEnumerable<(string, char)> pairs)
    {
        Template = template;
        Pairs = pairs;
    }
}