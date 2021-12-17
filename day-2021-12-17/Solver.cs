namespace day_2021_12_17;

public static class Solver
{
    public static int Part1(Data data)
    {
        // there is "candles" when x velocity become 0 in target x range
        // and probe falls vertically
        
        // probe always be at y = 0 during fall
        
        // and velocity cannot be greater than lowest Y because in this
        // case probe will overshoot target area with very first step from y = 0
        
        // shot vertical speed is fall through zero speed minus 1
        
        var vy = -data.YMin - 1;

        // calculate shot height 
        
        var y = 0;
        while(vy != 0)
        {
            y += vy;
            vy -= 1;
        }
        return y;
    }

    public static int Part2(Data data)
    {
        var suitableXVelocities = GetSuitableXVelocities(data);

        var minYVelocity = data.YMin;
        var maxYVelocity = -data.YMin - 1; // see description in part1

        var result = 0;
        
        foreach (var initialXVelocity in suitableXVelocities)
        {
            for (var initialYVelocity = minYVelocity; initialYVelocity <= maxYVelocity; initialYVelocity++)
            {
                if (ShotTargetArea(data, initialXVelocity, initialYVelocity))
                    result += 1;
            }
        }
        
        return result;
    }

    private static bool ShotTargetArea(Data data, int initialXVelocity, int initialYVelocity)
    {
        var (x, y, vx, vy) = (0, 0, initialXVelocity, initialYVelocity);
        while (x < data.XMax && y > data.YMin)
        {
            x += vx;
            y += vy;
            if (vx > 0)
                vx -= 1;
            vy -= 1;
            if (data.XMin <= x && x <= data.XMax && data.YMin <= y && y <= data.YMax)
                return true;
        }
        return false;
    }
    
    private static IEnumerable<int> GetSuitableXVelocities(Data data)
    {
        var suitableVelocities = new List<int>();
        
        var maxSuitableVelocity = data.XMax;
        for (var initialVelocity = maxSuitableVelocity; initialVelocity > 0; initialVelocity--)
        {
            var x = 0;
            var velocity = initialVelocity;

            var inTargetArea = false;
            
            while(true)
            {
                x += velocity;
                velocity -= 1;
                {
                    if (x > data.XMax)
                        break;
                    if (data.XMin <= x && x <= data.XMax)
                    {
                        inTargetArea = true;
                        break;
                    }
                }
                if (velocity == 0)
                    break;
            }

            if (inTargetArea)
            {
                suitableVelocities.Add(initialVelocity);
            }
        }
        
        return suitableVelocities;
    }
}