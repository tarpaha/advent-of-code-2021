using System;
using utils;

namespace day_2021_12_08.app
{
    public class Solution : ISolution
    {
        public static void Main()
        {
            var solution = new Solution();
            Console.WriteLine($"Part1: {solution.SolvePart1()}");
            Console.WriteLine($"Part2: {solution.SolvePart2()}");
        }

        public object SolvePart1()
        {
            return Solver.Part1();
        }

        public object SolvePart2()
        {
            return Solver.Part2();
        }
    }
}