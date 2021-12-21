namespace day_2021_12_18;

public static class Solver
{
    public static long Part1(Data data)
    {
        return Magnitude(FinalSum(data.Numbers));
    }

    public static SN Add(SN n1, SN n2)
    {
        return new Pair(n1, n2);
    }

    public static SN AddAndReduce(SN n1, SN n2)
    {
        var sum = Add(n1, n2);
        while (Reduce(sum)) { }
        return sum;
    }

    public static SN FinalSum(IEnumerable<SN> numbersCollection)
    {
        var numbers = numbersCollection.ToList();
        var sum = numbers.First();
        return numbers.Skip(1).Aggregate(sum, AddAndReduce);
    }

    public static long Magnitude(SN sn)
    {
        return sn switch
        {
            Number number => number.Value,
            Pair pair => 3L * Magnitude(pair.Left) + 2L * Magnitude(pair.Right),
            _ => throw new ArgumentOutOfRangeException(nameof(sn))
        };
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

    public static Number? FindReadyToSplitNumber(SN sn)
    {
        return sn switch
        {
            Number number => number.Value >= 10 ? number : null,
            Pair pair => FindReadyToSplitNumber(pair.Left) ?? FindReadyToSplitNumber(pair.Right),
            _ => throw new ArgumentOutOfRangeException(nameof(sn))
        };
    }
    
    public static Pair Split(Number number)
    {
        var half = number.Value >> 1;
        var delta = (number.Value & 1) == 1 ? 1 : 0;
        var divided = new Pair(new Number(half), new Number(half + delta)); 
        number.Parent?.ReplaceWith(number, divided);
        return divided;
    }

    public static bool Reduce(SN number)
    {
        var exploding = FindReadyToExplodePair(number);
        if (exploding != null)
        {
            Explode(exploding);
            return true;
        }

        var splitting = FindReadyToSplitNumber(number);
        if (splitting != null)
        {
            Split(splitting);
            return true;
        }

        return false;
    }

    public static object Part2(Data data)
    {
        return null!;
    }
}