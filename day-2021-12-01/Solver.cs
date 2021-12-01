using System.Linq;
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

        public static int Part2(IEnumerable<int> depthsCollection)
        {
            var depths = depthsCollection.ToArray();
            var increasedCount = 0;
            var previousSum = depths[0] + depths[1] + depths[2];
            for (var i = 3; i < depths.Length; i++)
            {
                var sum = previousSum - depths[i - 3] + depths[i];
                if (sum > previousSum)
                    increasedCount += 1;
                previousSum = sum;
            }
            return increasedCount;
        }
    }
}