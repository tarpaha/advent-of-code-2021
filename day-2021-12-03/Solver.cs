using System;
using System.Linq;
using System.Collections.Generic;

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
            var result = "";
            foreach (var ch in number)
            {
                result += ch == '0' ? '1' : '0';
            }
            return result;
        }
        
        public static object Part1(IEnumerable<string> numbers)
        {
            var gammaRateString = CalculateGammaRateString(numbers);
            var gammaRate = Convert.ToInt32(gammaRateString, 2);

            var epsilonRateString = InvertBinaryNumber(gammaRateString);
            var epsilonRate = Convert.ToInt32(epsilonRateString, 2);
            
            return gammaRate * epsilonRate;
        }
        
        public static object Part2()
        {
            return null!;
        }
    }
}