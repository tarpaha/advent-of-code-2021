using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace day_2021_12_03
{
    public static class Solver
    {
        public static string CalculateGammaRateString(IEnumerable<string> numbersCollection)
        {
            var numbers = numbersCollection.ToArray();
            
            var numberOfBits = numbers[0].Length;
            var onesCount = new int[numberOfBits];
            foreach (var number in numbers)
            {
                for (var bitPos = 0; bitPos < numberOfBits; bitPos++)
                {
                    if (number[bitPos] == '1')
                        onesCount[bitPos] += 1;
                }
            }

            var result = "";
            for (var bitPos = 0; bitPos < numberOfBits; bitPos++)
            {
                result += onesCount[bitPos] * 2 >= numbers.Length ? '1' : '0';
            }
            return result;
        }

        public static string InvertBinaryNumber(string number)
        {
            return number.Aggregate("", (current, ch) => current + (char)('0' + '1' - ch));
        }
        
        public static object Part1(IEnumerable<string> numbers)
        {
            var gammaRateString = CalculateGammaRateString(numbers);
            var gammaRate = Convert.ToInt32(gammaRateString, 2);

            var epsilonRateString = InvertBinaryNumber(gammaRateString);
            var epsilonRate = Convert.ToInt32(epsilonRateString, 2);
            
            return gammaRate * epsilonRate;
        }

        public static string CalculateOxygenGeneratorRating(IEnumerable<string> numbersCollection)
        {
            return CalculateSelectiveRating(numbersCollection, true);
        }

        public static string CalculateCO2ScrubberRating(IEnumerable<string> numbersCollection)
        {
            return CalculateSelectiveRating(numbersCollection, false);
        }

        private static string CalculateSelectiveRating(IEnumerable<string> numbersCollection, bool lookMostCommonValue)
        {
            var numbers = numbersCollection.ToList();
            var bitsCount = numbers[0].Length;

            for (var bitPos = 0; bitPos < bitsCount; bitPos++)
            {
                var onesCount = 0;
                foreach (var number in numbers)
                {
                    if (number[bitPos] == '1')
                        onesCount += 1;
                }
                var zerosCount = numbers.Count - onesCount;

                char saveBit;
                if (lookMostCommonValue)
                {
                    saveBit = onesCount >= zerosCount ? '1' : '0';
                }
                else
                {
                    saveBit = onesCount < zerosCount ? '1' : '0';
                }

                numbers.RemoveAll(number => number[bitPos] != saveBit);

                if (numbers.Count <= 1)
                    break;
            }
            
            return numbers[0];
        }
        
        public static object Part2(IEnumerable<string> numbersCollection)
        {
            var numbers = numbersCollection.ToList();
            return Task.WhenAll(
                    Task.Run(() => Convert.ToInt32(CalculateOxygenGeneratorRating(numbers), 2)),
                    Task.Run(() => Convert.ToInt32(CalculateCO2ScrubberRating(numbers), 2)))
                .Result
                .Aggregate((v1, v2) => v1 * v2);
        }
    }
}