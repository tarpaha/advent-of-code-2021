using System;
using System.Linq;
using System.Collections.Generic;

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

            Board winner = null!;
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

            return winnerNumber * winner?.GetNumbers().Where(number => !markedNumbers[winnerId].Contains(number)).Sum()
                   ?? throw new Exception("Cannot find result");
        }

        public static int Part2(Data data)
        {
            var rows = new List<int[]>();
            var cols = new List<int[]>();
            var markedNumbers = new List<HashSet<int>>();
            var completedBoards = new HashSet<Board>();

            foreach (var _ in data.Boards)
            {
                rows.Add(new int[5]);
                cols.Add(new int[5]);
                markedNumbers.Add(new HashSet<int>());
            }

            var winnerNumber = 0;
            var lastWinBoardId = 0;
            Board? lastWinBoard = null;
            foreach (var number in data.Numbers)
            {
                var boardId = 0;
                foreach (var board in data.Boards)
                {
                    if (completedBoards.Contains(board))
                    {
                        boardId += 1;
                        continue;
                    }

                    var pos = board.GetNumberPos(number);
                    if (pos.HasValue)
                    {
                        rows[boardId][pos.Value.row] += 1;
                        cols[boardId][pos.Value.col] += 1;
                        markedNumbers[boardId].Add(number);
                        if (rows[boardId][pos.Value.row] == 5 || cols[boardId][pos.Value.col] == 5)
                        {
                            completedBoards.Add(board);
                            lastWinBoardId = boardId;
                            lastWinBoard = board;
                        }
                    }

                    boardId += 1;
                }
                if (completedBoards.Count == data.Boards.Count())
                {
                    winnerNumber = number;
                    break;
                }
            }
            
            return winnerNumber * lastWinBoard?.GetNumbers().Where(number => !markedNumbers[lastWinBoardId].Contains(number)).Sum()
                   ?? throw new Exception("Cannot find result");
        }
    }
}