namespace day_2021_12_12;

public static class Solver
{
    public static int Part1(Data data)
    {
        var caves = new Caves(data);
        var visitsLeft = caves
            .AllCaves
            .Where(Caves.IsSmall)
            .ToDictionary(cave => cave, _ => 1);
        return Traverse(new Caves(data), visitsLeft, "start", new List<string>()).Distinct().Count();
    }

    public static object Part2(Data data)
    {
        var caves = new Caves(data);
        var smallCaves = caves.AllCaves.Where(Caves.IsSmall).ToList();

        var variants = new List<Dictionary<string, int>>();
        foreach (var smallCave in smallCaves)
        {
            var visitsLeft = smallCaves.ToDictionary(cave => cave, _ => 1);
            if (smallCave != "start" && smallCave != "end")
                visitsLeft[smallCave] = 2;
            variants.Add(visitsLeft);
        }

        return variants
            .AsParallel()
            .SelectMany(visitsLeft => Traverse(caves, visitsLeft, "start", new List<string>()))
            .Distinct()
            .Count();
    }

    private static IEnumerable<string> Traverse(Caves caves, Dictionary<string, int> visitsLeft, string cave, List<string> path)
    {
        path = new List<string>(path) { cave };
        if (cave == "end")
        {
            return new [] { string.Join(",", path) };
        }

        if (Caves.IsSmall(cave))
        {
            visitsLeft = new Dictionary<string, int>(visitsLeft);
            visitsLeft[cave] -= 1;
        }

        var linkedCaves = new List<string>();
        foreach (var linkedCave in caves.GetCavesLinkedTo(cave))
        {
            if (Caves.IsSmall(linkedCave))
            {
                if(visitsLeft[linkedCave] > 0)
                    linkedCaves.Add(linkedCave);
            }
            else
                linkedCaves.Add(linkedCave);
        }
            
        var paths = new List<string>();
        foreach (var linkedCave in linkedCaves)
        {
            paths.AddRange(Traverse(caves, visitsLeft, linkedCave, path));
        }
        
        return paths;
    }
}