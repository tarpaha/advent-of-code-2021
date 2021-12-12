namespace day_2021_12_12;

public static class Parser
{
    public static Data Parse(string data)
    {
        var pairs = data
            .Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries)
            .Select(line => line.Split('-'))
            .Select(parts => (parts[0], parts[1]));
        return new Data(pairs);
    }
}