namespace day_2021_12_11;

public static class Parser
{
    public static Data Parse(string data)
    {
        var lines = data.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
        var width = lines[0].Length;
        var height = lines.Length;
        return new Data(width, height, lines.SelectMany(line => line).Select(ch => ch - '0'));
    }
}