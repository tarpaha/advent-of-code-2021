namespace day_2021_12_09
{
    public static class Solver
    {
        public static int Part1(Field field)
        {
            var result = 0;
            for (var y = 0; y < field.Height; y++)
            {
                for (var x = 0; x < field.Width; x++)
                {
                    if (IsLowPoint(field, x, y))
                    {
                        result += 1 + field.Number(x, y);
                    }
                }
            }
            return result;
        }

        public static int Part2(Field field)
        {
            var basinSizes = new List<int>();
            while (true)
            {
                var basinPosition = GetBasinPosition(field);
                if (!basinPosition.HasValue)
                    break;
                var basinSize = FillBasin(field, basinPosition.Value);
                basinSizes.Add(basinSize);
            }
            return basinSizes.OrderByDescending(n => n).Take(3).Aggregate((m, n) => m * n);
        }

        private static (int, int)? GetBasinPosition(Field field)
        {
            for(var y = 0; y < field.Height; y++)
            for (var x = 0; x < field.Width; x++)
            {
                var number = field.Number(x, y);
                if (number >= 0 && number < 9)
                    return (x, y);
            }
            return null;
        }

        private static int FillBasin(Field field, (int x, int y) initialPosition)
        {
            var positions = new Queue<(int x, int y)>();
            var basinSize = 0;

            positions.Enqueue(initialPosition);
            while (positions.Count > 0)
            {
                var (x, y) = positions.Dequeue();
                
                if(field.Number(x, y) < 0)
                    continue;
                
                field.SetNumber(x, y, -1);
                basinSize += 1;

                if (x > 0)
                {
                    var number = field.Number(x - 1, y);
                    if(number >= 0 && number < 9)
                        positions.Enqueue((x - 1, y));
                }
                
                if (x < field.Width - 1)
                {
                    var number = field.Number(x + 1, y);
                    if(number >= 0 && number < 9)
                        positions.Enqueue((x + 1, y));
                }
                
                if (y > 0)
                {
                    var number = field.Number(x, y - 1);
                    if(number >= 0 && number < 9)
                        positions.Enqueue((x, y - 1));
                }
                
                if (y < field.Height - 1)
                {
                    var number = field.Number(x, y + 1);
                    if(number >= 0 && number < 9)
                        positions.Enqueue((x, y + 1));
                }
            }

            return basinSize;
        }
        
        private static bool IsLowPoint(Field field, int x, int y)
        {
            var point = field.Number(x, y);
            if (x > 0 && field.Number(x - 1, y) <= point)
                return false;
            if (x < field.Width - 1 && field.Number(x + 1, y) <= point)
                return false;
            if (y > 0 && field.Number(x, y - 1) <= point)
                return false;
            if (y < field.Height - 1 && field.Number(x, y + 1) <= point)
                return false;
            return true;
        }
    }
}