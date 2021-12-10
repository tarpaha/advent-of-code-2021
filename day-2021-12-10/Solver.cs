namespace day_2021_12_10;

public static class Solver
{
    private static readonly Dictionary<char, int> Part1Scores = new()
    {
        [')'] = 3,
        [']'] = 57,
        ['}'] = 1197,
        ['>'] = 25137
    };

    public static object Part1(Data data)
    {
        return data.Lines
            .AsParallel()
            .Select(GetInvalidChar)
            .Where(ch => ch.HasValue)
            .Select(ch => Part1Scores[ch!.Value])
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

    public static string GetClosingCharacters(string line)
    {
        var stack = new Stack<char>();
        
        foreach (var ch in line)
        {
            if(ch is '(' or '[' or '{' or '<')
                stack.Push(ch);
            else
                stack.Pop();
        }

        var result = "";
        while (stack.Count > 0)
        {
            result += stack.Pop() switch
            {
                '(' => ')',
                '[' => ']',
                '{' => '}',
                '<' => '>',
                _ => throw new Exception("Invalid character")
            };
        }

        return result;
    }

    private static readonly Dictionary<char, int> Part2Scores = new()
    {
        [')'] = 1,
        [']'] = 2,
        ['}'] = 3,
        ['>'] = 4
    };
    
    public static long CalculateStringCompletionScore(string str)
    {
        return str.Aggregate(0L, (current, ch) => current * 5 + Part2Scores[ch]);
    }

    public static object Part2(Data data)
    {
        var scores = data.Lines
            .AsParallel()
            .Where(line => GetInvalidChar(line) == null)
            .Select(GetClosingCharacters)
            .Where(line => !string.IsNullOrEmpty(line))
            .Select(CalculateStringCompletionScore)
            .OrderBy(score => score)
            .ToList();
        return scores[scores.Count / 2];
    }
}