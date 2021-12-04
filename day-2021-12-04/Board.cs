using System;
using System.Collections.Generic;
using System.Linq;

namespace day_2021_12_04
{
    public class Board
    {
        public Board(IReadOnlyList<string> lines)
        {
            for (var row = 0; row < 5; row++)
            {
                var numbers = lines[row].Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
                for (var col = 0; col < 5; col++)
                {
                    _numbers.Add(numbers[col], (col, row));
                }
            }
            if (_numbers.Count != 25)
                throw new ArgumentException();
        }

        private readonly Dictionary<int, (int, int)> _numbers = new();
    }
}