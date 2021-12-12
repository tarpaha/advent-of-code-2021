namespace day_2021_12_12;

public class Caves
{
    public Caves(Data data)
    {
        foreach (var (cave1, cave2) in data.Pairs)
        {
            AddLink(cave1, cave2);
            AddLink(cave2, cave1);
        }
    }

    public List<string> GetLinkedCaves(string cave) => _links[cave];

    private void AddLink(string caveFrom, string caveTo)
    {
        if (!_links.TryGetValue(caveFrom, out var linkedCaves))
        {
            linkedCaves = new List<string>();
            _links.Add(caveFrom, linkedCaves);
        }
        linkedCaves!.Add(caveTo);
    }

    private readonly Dictionary<string, List<string>> _links = new();
}