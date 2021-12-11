namespace day_2021_12_11;

public static class Solver
{
    public static int Step(Grid grid)
    {
        grid.IncreaseAllLevels();

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
                    if (grid.CanFlash(x, y))
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
            grid.Reset(x, y);
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
        var grid = new Grid(data);
        var step = 0;
        while (!grid.IsAllFlashes())
        {
            Step(grid);
            step += 1;
        }
        return step;
    }
}