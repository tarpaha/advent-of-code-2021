namespace day_2021_12_15;

public static class Solver
{
    private class Cell
    {
        public int X { get; }
        public int Y { get; }
        public int Number { get; }
        public int Total { get; set; }
        public bool Visited { get; set; }

        public Cell(int x, int y, int number, bool visited, int total)
        {
            X = x;
            Y = y;
            Number = number;
            Visited = visited;
            Total = total;
        }

        public override string ToString() => $"{X} {Y} {Total}";
    }

    public static int Part1(Data data)
    {
        var (w, h) = (data.Width, data.Height);
        var cells = MakeCells(data.Numbers.ToList(), w, h);

        var cellsQueue = new PriorityQueue<Cell, int>();
        
        cells[0].Total = 0;
        cellsQueue.Enqueue(cells[0], 0);
        
        while (true)
        {
            var cell = cellsQueue.Dequeue();

            if (cell.X == w - 1 && cell.Y == h - 1)
                return cell.Total;
            
            UpdateNeighborCell(cells, w, h, cell, -1,  0, cellsQueue);
            UpdateNeighborCell(cells, w, h, cell, +1,  0, cellsQueue);
            UpdateNeighborCell(cells, w, h, cell,  0, -1, cellsQueue);
            UpdateNeighborCell(cells, w, h, cell,  0, +1, cellsQueue);

            cell.Visited = true;
        }
    }

    private static List<Cell> MakeCells(IReadOnlyList<int> numbers, int w, int h)
    {
        var cells = new List<Cell>();
        for (var y = 0; y < h; y++)
        {
            for (var x = 0; x < w; x++)
            {
                cells.Add(new Cell(x, y, numbers[x + y * w], false, w * h * 10));
            }
        }
        return cells;
    }
    
    private static void UpdateNeighborCell(IReadOnlyList<Cell> cells, int w, int h,  Cell cell, int dx, int dy, PriorityQueue<Cell, int> queue)
    {
        var neighborX = cell.X + dx;
        if (neighborX < 0 || neighborX > w - 1)
            return;
        
        var neighborY = cell.Y + dy;
        if (neighborY < 0 || neighborY > h - 1)
            return;

        var neighborCell = cells[neighborX + neighborY * w];
        if (!neighborCell.Visited)
        {
            var distance = cell.Total + neighborCell.Number;
            if (distance < neighborCell.Total)
            {
                neighborCell.Total = distance;
                queue.Enqueue(neighborCell, neighborCell.Total);
            }
        }
    }

    public static object Part2(Data data)
    {
        return null!;
    }
}