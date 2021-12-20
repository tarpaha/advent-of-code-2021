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

    public static void Explode(Pair pair)
    {
        var left = pair;
        while (left.Parent != null && left != left.Parent.Right)
        {
            left = left.Parent;
        }
        if (left.Parent != null)
        {
            var rightmostToTheLeft = GetRightmostNumber(left.Parent.Left);
            rightmostToTheLeft.Add(((Number)pair.Left).Value);
        }
        
        var right = pair;
        while (right.Parent != null && right != right.Parent.Left)
        {
            right = right.Parent;
        }
        if (right.Parent != null)
        {
            var leftmostToTheRight = GetLeftmostNumber(right.Parent!.Right);
            leftmostToTheRight.Add(((Number)pair.Right).Value);
        }

        pair.Parent!.ReplaceWith(pair, new Number(0));
    }

    private static Number GetRightmostNumber(SN sn)
    {
        return sn switch
        {
            Number number => number,
            Pair pair => GetRightmostNumber(pair.Right),
            _ => throw new ArgumentOutOfRangeException(nameof(sn))
        };
    }
    
    private static Number GetLeftmostNumber(SN sn)
    {
        return sn switch
        {
            Number number => number,
            Pair pair => GetLeftmostNumber(pair.Left),
            _ => throw new ArgumentOutOfRangeException(nameof(sn))
        };
    }

    public static Pair Split(Number number)
    {
        var half = number.Value >> 1;
        var delta = (number.Value & 1) == 1 ? 1 : 0;
        return new Pair(new Number(half), new Number(half + delta));
    }

    public static object Part2(Data data)
    {
        return null!;
    }
}