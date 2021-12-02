using System.Collections.Generic;
using System.Linq;

namespace day_2021_12_02
{
    public static class Solver
    {
        public static int Part1(IEnumerable<(int x, int y)> commands)
        {
            var (x, y) = commands.Aggregate((c1, c2) => (c1.x + c2.x, c1.y + c2.y));
            return x * y;
        }
        
        public static object Part2()
        {
            return null!;
        }
    }
}