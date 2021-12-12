namespace day_2021_12_12;

public static class Solver
{
    public static int Part1(Data data)
    {
        return Traverse(new Caves(data), new HashSet<string>(), new List<string>(), "start");
    }

    private static int Traverse(Caves caves, HashSet<string> visitedCaves, List<string> path, string cave)
    {
        path = new List<string>(path) { cave };
        if (cave == "end")
        {
            return 1;
        }

        if (Caves.IsSmall(cave))
            visitedCaves = new HashSet<string>(visitedCaves) { cave };

        var linkedCaves = caves
            .GetCavesLinkedTo(cave)
            .Where(c => !visitedCaves.Contains(c))
            .ToList();
        var result = 0;
        foreach (var linkedCave in linkedCaves)
        {
            result += Traverse(caves, visitedCaves, path, linkedCave);
        }
        return result;
    }

    public static object Part2(Data data)
    {
        return null!;
    }
}