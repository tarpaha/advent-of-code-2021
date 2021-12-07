using System;
using System.Collections.Generic;
using System.Linq;

namespace day_2021_12_07
{
    public static class Solver
    {
        public static int Part1(IEnumerable<int> numbersCollection)
        {
            return FindMinimumFuel(numbersCollection, CalculateTotalFuel);
        }

        public static int Part2(IEnumerable<int> numbersCollection)
        {
            return FindMinimumFuel(numbersCollection, CalculateTotalFuelExpensive);
        }

        private delegate int FuelCalculator(IEnumerable<int> positions, int center);
        
        private static int FindMinimumFuel(IEnumerable<int> numbersCollection, FuelCalculator fuelCalculator)
        {
            var numbers = numbersCollection.OrderBy(n => n).ToList();
            
            var current = numbers.Count / 2;
            var left = current - 1;
            var right = current + 1;

            var fuelCurrent = fuelCalculator(numbers, current);

            var indexMoveDirection = -1;
            var fuelLeft = fuelCalculator(numbers, left);
            if (fuelLeft > fuelCurrent)
            {
                var fuelRight = fuelCalculator(numbers, right);
                if (fuelRight > fuelCurrent)
                    return fuelCurrent;
                indexMoveDirection = 1;
            }

            current += indexMoveDirection;
            while (current >= 0 && current < numbers.Count)
            {
                current += indexMoveDirection;
                var fuelCurrentNew = fuelCalculator(numbers, current);
                if (fuelCurrentNew > fuelCurrent)
                    break;
                fuelCurrent = fuelCurrentNew;
            }
            
            return fuelCurrent;
        }

        public static int CalculateTotalFuel(IEnumerable<int> positions, int center)
        {
            return positions.Select(position => Math.Abs(position - center)).Sum();
        }
        
        public static int CalculateTotalFuelExpensive(IEnumerable<int> positions, int center)
        {
            return positions
                .Select(position => Math.Abs(position - center))
                .Select(n => (1 + n) * n / 2)
                .Sum();
        }
    }
}