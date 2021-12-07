using System;
using System.Collections.Generic;
using System.Linq;
using utils;

namespace day_2021_12_07.app
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
            return Solver.Part1(Parser.Parse(Input.GetData()));
        }

        public object SolvePart2()
        {
            return Solver.Part2(Parser.Parse(Input.GetData()));
        }
    }
}