using System.Collections.Generic;
using System.Linq;

namespace day_2021_12_08
{
    public static class Solver
    {
        public static int Part1(IEnumerable<Entry> entries)
        {
            var result = 0;
            var lookingLengths = new HashSet<int> { 2, 4, 3, 7 };
            foreach (var entry in entries)
            {
                result += entry.Output.Count(s => lookingLengths.Contains(s.Length));
            }
            return result;
        }

        public static object Part2()
        {
            return null!;
        }
    }
}