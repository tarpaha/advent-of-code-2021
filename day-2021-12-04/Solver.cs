using System.Collections.Generic;
using System.Linq;

namespace day_2021_12_04
{
    public static class Solver
    {
        public static int Part1(Data data)
        {
            var rows = new List<int[]>();
            var cols = new List<int[]>();
            var markedNumbers = new List<HashSet<int>>();

            foreach (var _ in data.Boards)
            {
                rows.Add(new int[5]);
                cols.Add(new int[5]);
                markedNumbers.Add(new HashSet<int>());
            }

            Board winner = null;
            var winnerId = 0;
            var winnerNumber = 0;
            foreach (var number in data.Numbers)
            {
                var boardId = 0;
                foreach (var board in data.Boards)
                {
                    var pos = board.GetNumberPos(number);
                    if (pos.HasValue)
                    {
                        rows[boardId][pos.Value.row] += 1;
                        cols[boardId][pos.Value.col] += 1;
                        markedNumbers[boardId].Add(number);
                        if (rows[boardId][pos.Value.row] == 5 || cols[boardId][pos.Value.col] == 5)
                        {
                            winner = board;
                            winnerId = boardId;
                            break;
                        }
                    }
                    boardId += 1;
                }
                if (winner != null)
                {
                    winnerNumber = number;
                    break;
                }
            }

            return winnerNumber * winner.GetNumbers().Where(number => !markedNumbers[winnerId].Contains(number)).Sum();
        }

        public static object Part2()
        {
            return null!;
        }
    }
}