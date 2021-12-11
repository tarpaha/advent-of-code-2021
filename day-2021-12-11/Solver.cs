namespace day_2021_12_11;

public static class Solver
{
    public static int Step(Grid grid)
    {
        grid.Step();

        var flashed = new HashSet<(int, int)>();
        while (true)
        {
            var haveFlash = false;
            for (var y = 0; y < grid.Height; y++)
            {
                for (var x = 0; x < grid.Width; x++)
                {
                    if(flashed.Contains((x, y)))
                        continue;

                    if (grid.GetLevel(x, y) > 9)
                    {
                        grid.Flash(x, y);
                        flashed.Add((x, y));
                        haveFlash = true;
                    }
                }
            }
            if (!haveFlash)
                break;
        }

        foreach (var (x, y) in flashed)
        {
            grid.SetLevel(x, y, 0);
        }

        return flashed.Count;
    }

    public static int Steps(Grid grid, int stepsCount)
    {
        var flashes = 0;
        for (var i = 0; i < stepsCount; i++)
        {
            flashes += Step(grid);
        }
        return flashes;
    }
    
    public static object Part1(Data data)
    {
        return Steps(new Grid(data), 100);
    }

    public static object Part2(Data data)
    {
        return null!;
    }
}