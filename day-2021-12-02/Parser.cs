using System;
using System.Collections.Generic;
using System.Linq;

namespace day_2021_12_02
{
    public static class Parser
    {
        public static IEnumerable<(int x, int y)> Parse(string data)
        {
            return data
                .Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries)
                .Select(line => line.Split(' '))
                .Select(parts => (
                    step: parts[0] switch
                    {
                        "forward" => (x: 1, y:  0),
                        "down"    => (x: 0, y: +1),
                        "up"      => (x: 0, y: -1),
                        _ => throw new ArgumentOutOfRangeException($"Invalid direction: {parts[0]}")
                    },
                    distance: int.Parse(parts[1])))
                .Select(move => (move.step.x * move.distance, move.step.y * move.distance));
        }
    }
}