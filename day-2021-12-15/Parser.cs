namespace day_2021_12_15;

public static class Parser
{
    public static Data Parse(string data)
    {
        var lines = data.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
        var width = lines[0].Length;
        var height = lines.Length;
        var numbers = lines.SelectMany(line => line).Select(ch => ch - '0');
        return new Data(width, height, numbers);
    }
}