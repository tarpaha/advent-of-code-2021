namespace day_2021_12_18;

public static class Solver
{
    public static object Part1(Data data)
    {
        return null!;
    }

    public static SN Add(SN n1, SN n2)
    {
        return new Pair(n1, n2);
    }

    public static Pair? FindReadyToExplodePair(SN number, int depth = 0)
    {
        if (number is Pair pair)
        {
            if (depth == 4)
            {
                if (!(pair.Left is Number && pair.Right is Number))
                    throw new Exception("There is pair inside four pairs");
                return pair;
            }
            
            var result = FindReadyToExplodePair(pair.Left, depth + 1);
            if (result != null)
                return result;
            
            return FindReadyToExplodePair(pair.Right, depth + 1);
        }
        return null;
    }

    public static object Part2(Data data)
    {
        return null!;
    }
}