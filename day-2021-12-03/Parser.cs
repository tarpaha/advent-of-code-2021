using System;
using System.Collections.Generic;

namespace day_2021_12_03
{
    public static class Parser
    {
        public static IEnumerable<string> Parse(string data)
        {
            return data.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}