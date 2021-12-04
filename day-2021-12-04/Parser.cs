using System;
using System.Collections.Generic;
using System.Linq;

namespace day_2021_12_04
{
    public static class Parser
    {
        public static Data Parse(string data)
        {
            var lines = data.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
            var numbers = lines[0].Split(',').Select(int.Parse).ToList();
            var boards = new List<Board>();
            for (var tablePos = 1; tablePos < lines.Length; tablePos += 5)
            {
                boards.Add(new Board(lines[tablePos..(tablePos+5)]));
            }
            return new Data(numbers, boards);
        }
    }
}