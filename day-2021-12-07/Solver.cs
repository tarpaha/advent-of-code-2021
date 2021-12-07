using System;
using System.Collections.Generic;
using System.Linq;

namespace day_2021_12_07
{
    public static class Solver
    {
        public static int Part1(IEnumerable<int> numbersCollection)
        {
            var numbers = numbersCollection.OrderBy(n => n).ToList();
            
            var current = numbers.Count / 2;
            var left = current - 1;
            var right = current + 1;

            var fuelCurrent = CalculateTotalFuel(numbers, current);

            var indexMoveDirection = -1;
            var fuelLeft = CalculateTotalFuel(numbers, left);
            if (fuelLeft > fuelCurrent)
            {
                var fuelRight = CalculateTotalFuel(numbers, right);
                if (fuelRight > fuelCurrent)
                    return fuelCurrent;
                indexMoveDirection = 1;
            }

            current += indexMoveDirection;
            while (current >= 0 && current < numbers.Count)
            {
                current += indexMoveDirection;
                var fuelCurrentNew = CalculateTotalFuel(numbers, current);
                if (fuelCurrentNew > fuelCurrent)
                    break;
                fuelCurrent = fuelCurrentNew;
            }
            
            return fuelCurrent;
        }

        public static object Part2()
        {
            return null!;
        }

        public static int CalculateTotalFuel(IEnumerable<int> positions, int center)
        {
            return positions.Select(position => Math.Abs(position - center)).Sum();
        }
    }
}