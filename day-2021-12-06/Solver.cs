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

        public static long Part2(IEnumerable<int> numbers, int days)
        {
            var timers = new List<int>(numbers);
            
            var bornPerDay = new long[days + 1];
            foreach (var timer in timers)
            {
                var bornDay = timer + 1;
                while (bornDay < bornPerDay.Length)
                {
                    bornPerDay[bornDay] += 1;
                    bornDay += 7;
                }
            }

            var totalBornCount = 0L;
            for (var day = 1; day <= days; day++)
            {
                var bornToday = bornPerDay[day];
                if(bornToday == 0)
                    continue;

                totalBornCount += bornToday;
                var grandchildBornDay = day + 9;
                while (grandchildBornDay <= days)
                {
                    bornPerDay[grandchildBornDay] += bornToday;
                    grandchildBornDay += 7;
                }
            }
            
            return timers.Count + totalBornCount;
        }
    }
}