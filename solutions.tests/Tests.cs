using NUnit.Framework;
using System.Collections.Generic;
using utils;

namespace solutions.tests
{
    public class Tests
    {
        private static IEnumerable<TestCaseData> SolutionsTestCases
        {
            get
            {
                yield return new TestCaseData(new day_2021_12_01.app.Solution(), 1715, 1739);
                yield return new TestCaseData(new day_2021_12_02.app.Solution(), 1507611, 1880593125);
                yield return new TestCaseData(new day_2021_12_03.app.Solution(), 3969000, 4267809);
                yield return new TestCaseData(new day_2021_12_04.app.Solution(), 33348, 8112);
                yield return new TestCaseData(new day_2021_12_05.app.Solution(), 4421, 18674);
                yield return new TestCaseData(new day_2021_12_06.app.Solution(), 387413, 1738377086345);
                yield return new TestCaseData(new day_2021_12_07.app.Solution(), 344535, 95581659);
                yield return new TestCaseData(new day_2021_12_08.app.Solution(), 456, 1091609);
                yield return new TestCaseData(new day_2021_12_09.app.Solution(), 500, 970200);
                yield return new TestCaseData(new day_2021_12_10.app.Solution(), 168417, 2802519786);
                yield return new TestCaseData(new day_2021_12_11.app.Solution(), 1679, 519);
                yield return new TestCaseData(new day_2021_12_12.app.Solution(), 3298, 93572);
                yield return new TestCaseData(new day_2021_12_13.app.Solution(), 592, @"
..##..##...##....##.####.####.#..#.#..#
...#.#..#.#..#....#.#....#....#.#..#..#
...#.#....#..#....#.###..###..##...#..#
...#.#.##.####....#.#....#....#.#..#..#
#..#.#..#.#..#.#..#.#....#....#.#..#..#
.##...###.#..#..##..####.#....#..#..##.");
            }
        }
        
        [TestCaseSource(nameof(SolutionsTestCases))]
        public void Test(ISolution solution, object result1, object result2)
        {
            if(result1 != null)
                Assert.That(solution.SolvePart1(), Is.EqualTo(result1));
            if(result2 != null)
                Assert.That(solution.SolvePart2(), Is.EqualTo(result2));
        }
    }
}