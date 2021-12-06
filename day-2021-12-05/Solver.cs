using System.Linq;
using System.Collections.Generic;

namespace day_2021_12_05
{
    public static class Solver
    {
        public static int Part1(IEnumerable<Line> lines)
        {
            var field = new Dictionary<(int x, int y), int>();
            foreach (var line in lines)
            {
                if (line.X1 == line.X2)
                {
                    var x = line.X1;
                    var (start, finish) = line.Y1 < line.Y2
                        ? (line.Y1, line.Y2)
                        : (line.Y2, line.Y1);
                    for (var y = start; y <= finish; y++)
                    {
                        UpdateField(field, x, y);
                    }
                }
                else if (line.Y1 == line.Y2)
                {
                    var y = line.Y1;
                    var (start, finish) = line.X1 < line.X2
                        ? (line.X1, line.X2)
                        : (line.X2, line.X1);
                    for (var x = start; x <= finish; x++)
                    {
                        UpdateField(field, x, y);
                    }
                }
            }

            return field.Values.Count(v => v >= 2);
        }

        private static void UpdateField(IDictionary<(int x, int y), int> field, int x, int y)
        {
            if (field.TryGetValue((x, y), out var counter))
            {
                field[(x, y)] = counter + 1;
            }
            else
            {
                field.Add((x, y), 1);
            }
        }

        public static object Part2()
        {
            return null!;
        }
    }
}