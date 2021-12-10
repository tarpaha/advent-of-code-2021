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

        public static object Part2()
        {
            return null!;
        }
    }
}