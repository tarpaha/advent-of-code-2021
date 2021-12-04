using System.Collections.Generic;

namespace day_2021_12_04
{
    public class Data
    {
        public IEnumerable<int> Numbers { get; }
        public IEnumerable<Board> Boards { get; }
        public Data(IEnumerable<int> numbers, IEnumerable<Board> boards)
        {
            Numbers = numbers;
            Boards = boards;
        }
    }
}