namespace day_2021_12_09;

public static class Parser
{
    public static Field Parse(string data)
    {
        var lines = data.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
        var width = lines[0].Length;
        var height = lines.Length;
        var numbers = lines.SelectMany(line => line).Select(ch => ch - '0');
        return new Field(width, height, numbers);
    }
}