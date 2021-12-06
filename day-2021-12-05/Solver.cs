using System;
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
                    FillHorizontal(field, line.X1, line.Y1, line.Y2);
                else if (line.Y1 == line.Y2)
                    FillVertical(field, line.Y1, line.X1, line.X2);
            }

            return field.Values.Count(v => v >= 2);
        }

        private static void FillHorizontal(IDictionary<(int x, int y), int> field, int x, int y1, int y2)
        {
            var (start, finish) = y1 < y2 ? (y1, y2) : (y2, y1);
            for (var y = start; y <= finish; y++)
            {
                UpdateField(field, x, y);
            }
        }

        private static void FillVertical(IDictionary<(int x, int y), int> field, int y, int x1, int x2)
        {
            var (start, finish) = x1 < x2 ? (x1, x2) : (x2, x1);
            for (var x = start; x <= finish; x++)
            {
                UpdateField(field, x, y);
            }
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

        public static int Part2(IEnumerable<Line> lines)
        {
            var field = new Dictionary<(int x, int y), int>();
            foreach (var line in lines)
            {
                if (line.X1 == line.X2)
                    FillHorizontal(field, line.X1, line.Y1, line.Y2);
                else if (line.Y1 == line.Y2)
                    FillVertical(field, line.Y1, line.X1, line.X2);
                else if(Math.Abs(line.X2 - line.X1) == Math.Abs(line.Y2 - line.Y1))
                {
                    var (sx, sy, fx, fy) = line.X1 < line.X2
                        ? (line.X1, line.Y1, line.X2, line.Y2)
                        : (line.X2, line.Y2, line.X1, line.Y1);
                    var dy = sy < fy ? 1 : -1;
                    var y = sy;
                    for (var x = sx; x <= fx; x++, y+=dy)
                    {
                        UpdateField(field, x, y);
                    }
                }
            }

            return field.Values.Count(v => v >= 2);
        }
    }
}