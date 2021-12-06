using System.Collections.Generic;

namespace day_2021_12_06
{
    public static class Solver
    {
        public static int Part1(IEnumerable<int> numbers, int days)
        {
            var timers = new List<int>(numbers);
            for (var day = 0; day < days; day++)
            {
                var bornCount = 0;
                for (var id = 0; id < timers.Count; id++)
                {
                    if (timers[id] > 0)
                    {
                        timers[id] -= 1;
                    }
                    else
                    {
                        timers[id] = 6;
                        bornCount += 1;
                    }
                }
                for(var i = 0; i < bornCount; i++)
                    timers.Add(8);
            }
            return timers.Count;
        }

        public static object Part2()
        {
            return null!;
        }
    }
}