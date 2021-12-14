namespace day_2021_12_14;

public static class Solver
{
    public static int Part1(Data data)
    {
        var template = ProcessSteps(data, 10).GroupBy(ch => ch).ToList();
        var min = template.Min(g => g.Count());
        var max = template.Max(g => g.Count());
        return max - min;
    }

    public static string ProcessSteps(Data data, int stepsCount)
    {
        var template = new LinkedList<char>(data.Template);
        var pairs = data.Pairs.ToDictionary(pair => (pair.Item1[0], pair.Item1[1]), pair => pair.Item2);

        for (var step = 0; step < stepsCount; step++)
        {
            var prev = template.First;
            while (prev != template.Last)
            {
                var current = prev!.Next;
                if (pairs.TryGetValue((prev.Value, current!.Value), out var ch))
                {
                    template.AddAfter(prev, ch);
                }
                prev = current;
            }
        }

        return string.Join("", template);
    }

    public static object Part2(Data data)
    {
        return null!;
    }
}