using System.Collections.Generic;

namespace day_2021_12_01
{
    public static class Solver
    {
        public static int Part1(IEnumerable<int> depths)
        {
            var increasedCount = 0;
            var previousDepth = int.MaxValue;
            foreach (var depth in depths)
            {
                if (depth > previousDepth)
                    increasedCount += 1;
                previousDepth = depth;
            }
            return increasedCount;
        }

        public static object Part2()
        {
            return null!;
        }
    }
}