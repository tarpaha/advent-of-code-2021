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
        return Traverse(new Caves(data), visitsLeft, "start");
    }

    private static int Traverse(Caves caves, Dictionary<string, int> visitsLeft, string cave)
    {
        if (cave == "end")
            return 1;

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
            
        var result = 0;
        foreach (var linkedCave in linkedCaves)
        {
            result += Traverse(caves, visitsLeft, linkedCave);
        }
        
        return result;
    }

    public static object Part2(Data data)
    {
        return null!;
    }
}