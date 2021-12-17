namespace day_2021_12_17;

public static class Parser
{
    public static Data Parse(string data)
    {
        var parts = data
            .Split(new[] { "target area: x=", "..", ", y=" }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToList();
        return new Data(parts[0], parts[1], parts[2], parts[3]);
    }
}