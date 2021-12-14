namespace day_2021_12_14;

public static class Parser
{
    public static Data Parse(string data)
    {
        var lines = data.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
        var template = lines.First();

        var pairs = new List<(string, char)>();
        foreach (var line in lines.Skip(1))
        {
            var parts = line.Split(" -> ");
            pairs.Add((parts[0], parts[1][0]));
        }
        
        return new Data(template, pairs);
    }
}