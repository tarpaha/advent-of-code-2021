using System;
using System.Collections.Generic;
using System.Linq;

namespace day_2021_12_08
{
    public static class Parser
    {
        public static IEnumerable<Entry> Parse(in string data)
        {
            return data
                .Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries)
                .Select(line => ParseLine(line));
        }

        public static Entry ParseLine(in string data)
        {
            var parts = data
                .Replace(Environment.NewLine, "")
                .Split('|')
                .Select(part => part.Split(' ', StringSplitOptions.RemoveEmptyEntries))
                .ToList();
            return new Entry(parts[0], parts[1]);
        }
    }
}