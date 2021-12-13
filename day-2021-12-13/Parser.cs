namespace day_2021_12_13;

public static class Parser
{
    public static Data Parse(string data)
    {
        var lines = data.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
        var dots = new List<(int, int)>();
        var folds = new List<(Data.Fold, int)>();
        foreach (var line in lines)
        {
            if (line[0] == 'f')
            {
                var record = line.Split(' ').Last();
                var parts = record.Split('=');
                folds.Add((
                    parts[0][0] switch
                    {
                        'y' => Data.Fold.Horz,
                        'x' => Data.Fold.Vert,
                        _ => throw new Exception()
                    },
                    int.Parse(parts[1])));
            }
            else
            {
                var coords = line.Split(',').Select(int.Parse).ToList();
                dots.Add((coords[0], coords[1]));
            }
        }
        return new Data(dots, folds);
    }
}