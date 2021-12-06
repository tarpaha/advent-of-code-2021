using System;
using System.Collections.Generic;
using System.Linq;

namespace day_2021_12_05
{
    public static class Parser
    {
        public static IEnumerable<Line> Parse(string data)
        {
            var lines = new List<Line>();
            foreach (var line in data.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries))
            {
                var pairs = line.Split(" -> ");
                var first = pairs[0].Split(',').Select(int.Parse).ToList();
                var second = pairs[1].Split(',').Select(int.Parse).ToList();
                lines.Add(new Line(first[0], first[1], second[0], second[1]));
            }
            return lines;
        }
    }
}