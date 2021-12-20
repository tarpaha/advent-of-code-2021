namespace day_2021_12_18;

public static class Parser
{
    public static Data Parse(string data)
    {
        var lines = data.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
        return new Data(lines.Select(ParseSnailfishNumber));
    }

    public static SN ParseSnailfishNumber(string str)
    {
        var pos = 0;
        return ParseSnailfishNumber(str, ref pos);
    }
    
    private static SN ParseSnailfishNumber(string str, ref int pos)
    {
        if(char.IsDigit(str[pos]))
            return new Number(str[pos++] - '0');
        pos += 1; // [
        var left = ParseSnailfishNumber(str, ref pos);
        pos += 1; // ,
        var right = ParseSnailfishNumber(str, ref pos);
        pos += 1; // ]
        return new Pair(left, right);
    }
}