namespace day_2021_12_10;

public static class Solver
{
    public static object Part1(Data data)
    {
        var scores = new Dictionary<char, int>()
        {
            [')'] = 3,
            [']'] = 57,
            ['}'] = 1197,
            ['>'] = 25137
        };
        return data.Lines
            .AsParallel()
            .Select(GetInvalidChar)
            .Where(ch => ch.HasValue)
            .Select(ch => scores[ch!.Value])
            .Sum();
    }

    public static char? GetInvalidChar(string line)
    {
        var stack = new Stack<char>();
        foreach (var ch in line)
        {
            switch (ch)
            {
                case '(' or '[' or '{' or '<':
                    stack.Push(ch);
                    break;
                case ')' when stack.Pop() != '(':
                    return ')';
                case ']' when stack.Pop() != '[':
                    return ']';
                case '}' when stack.Pop() != '{':
                    return '}';
                case '>' when stack.Pop() != '<':
                    return '>';
            }
        }
        return null;
    }

    public static object Part2(Data data)
    {
        return null!;
    }
}