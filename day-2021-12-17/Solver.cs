namespace day_2021_12_17;

public static class Solver
{
    public static object Part1(Data data)
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

    private static IEnumerable<(int v, IEnumerable<(int t, int x, int vx)>)> GetSuitableXVelocities(Data data)
    {
        var suitableX = new List<(int, IEnumerable<(int, int, int)>)>();
        
        var maxSuitableVelocity = data.XMax;
        for (var initialVelocity = maxSuitableVelocity; initialVelocity > 0; initialVelocity--)
        {
            var t = 0;
            var x = 0;
            var velocity = initialVelocity;

            var inTargetArea = false;
            while(true)
            {
                t += 1;
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
                var timePos = new List<(int, int, int)>();
                while (true)
                {
                    timePos.Add((t, x, velocity));
                    if (velocity == 0)
                        break;
                    t += 1;
                    x += velocity;
                    velocity -= 1;
                    if(x > data.XMax)
                        break;
                }
                suitableX.Add((initialVelocity, timePos));
            }
        }
        
        return suitableX;
    }

    public static object Part2(Data data)
    {
        return null!;
    }
}