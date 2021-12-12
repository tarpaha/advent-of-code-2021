using System.Diagnostics;
using utils;

namespace day_2021_12_12.app;

public class Solution : ISolution
{
    public static void Main()
    {
        var solution = new Solution();
        Console.WriteLine($"Part1: {solution.SolvePart1()}");

        var t = Stopwatch.StartNew();
        Console.WriteLine($"Part2: {solution.SolvePart2()} done in {t.ElapsedMilliseconds}ms");
    }

    public Solution()
    {
        _data = Parser.Parse(Input.GetData());
    }

    public object SolvePart1()
    {
        return Solver.Part1(_data);
    }

    public object SolvePart2()
    {
        return Solver.Part2(_data);
    }

    private readonly Data _data;
}