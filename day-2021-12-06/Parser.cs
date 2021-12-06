using System;
using System.Collections.Generic;
using System.Linq;

namespace day_2021_12_06
{
    public class Parser
    {
        public static IEnumerable<int> Parse(string data)
        {
            return data.Split(',', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse);
        }
    }
}