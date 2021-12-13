namespace day_2021_12_13;

public static class Solver
{
    public static int Part1(Data data)
    {
        var dots = new List<(int, int)>(data.Dots);
        var (foldOrientation, foldCoord) = data.Folds.First();
        return Fold(dots, foldOrientation, foldCoord).Count();
    }

    private static IEnumerable<(int, int)> Fold(IEnumerable<(int, int)> dots, Data.Fold foldOrientation, int foldCoord)
    {
        var folded = new HashSet<(int, int)>();
        if (foldOrientation == Data.Fold.Horz)
        {
            foreach (var (x, y) in dots)
            {
                folded.Add(
                    y < foldCoord
                        ? (x, y)
                        : (x, 2 * foldCoord - y));
            }
        }
        else
        {
            foreach (var (x, y) in dots)
            {
                folded.Add(
                    x < foldCoord
                        ? (x, y)
                        : (2 * foldCoord - x, y));
            }
        }
        return folded;
    }

    public static string Part2(Data data)
    {
        var dots = data.Dots;
        foreach (var (foldOrientation, foldCoord) in data.Folds)
        {
            dots = Fold(dots, foldOrientation, foldCoord);
        }
        return DotsToString(dots);
    }

    private static string DotsToString(IEnumerable<(int, int)> dotsCollection)
    {
        var dots = new HashSet<(int, int)>(dotsCollection);
        
        var (xMax, yMax) = (0, 0); 
        foreach (var (x, y) in dots)
        {
            if (x > xMax)
                xMax = x;
            if (y > yMax)
                yMax = y;
        }

        var result = "";
        for (var y = 0; y <= yMax; y++)
        {
            for (var x = 0; x <= xMax; x++)
            {
                result += dots.Contains((x, y)) ? '#' : '.';
            }
            if (y < yMax)
                result += Environment.NewLine;
        }

        return result;
    }
}