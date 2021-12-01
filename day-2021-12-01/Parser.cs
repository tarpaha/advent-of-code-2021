using System;
using System.Linq;
using System.Collections.Generic;

namespace day_2021_12_01
{
    public static class Parser
    {
        public static IEnumerable<int> Parse(string data)
        {
            return data
                .Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse);
        }
    }
}