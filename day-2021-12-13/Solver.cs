namespace day_2021_12_13;

public static class Solver
{
    public static int Part1(Data data)
    {
        var dots = new List<(int, int)>(data.Dots);
        var fold = data.Folds.First();

        var folded = new HashSet<(int, int)>();
        
        if (fold.orientation == Data.Fold.Horz)
        {
            var foldY = fold.coord;
            foreach (var (x, y) in dots)
            {
                folded.Add(
                    y < foldY
                        ? (x, y)
                        : (x, 2 * foldY - y));
            }
        }
        else
        {
            var foldX = fold.coord;
            foreach (var (x, y) in dots)
            {
                folded.Add(
                    x < foldX
                        ? (x, y)
                        : (2 * foldX - x, y));
            }
        }
        
        return folded.Count;
    }

    public static object Part2(Data data)
    {
        return null!;
    }
}