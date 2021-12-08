using System.Collections.Generic;
using System.Linq;

namespace day_2021_12_08
{
    public static class Solver
    {
        public static int Part1(IEnumerable<Entry> entries)
        {
            var lookingLengths = new HashSet<int> { 2, 4, 3, 7 };
            return entries.Sum(entry => entry.Output.Count(d => lookingLengths.Contains(d.Length)));
        }

        public static int Part2(IEnumerable<Entry> entries)
        {
            return entries
                .AsParallel()
                .Select(CalculateNumber)
                .Sum();
        }

        public static int CalculateNumber(Entry entry)
        {
            var digits = entry.Digits;
            
            // digit 1 is only one with two segments
            var digit1 = digits.First(s => s.Length == 2);

            // digit 7 is only one with three segments
            var digit7 = digits.First(s => s.Length == 3);

            // digit 4 is only one with four segments
            var digit4 = digits.First(s => s.Length == 4);
            
            // top segment char is one from digit 7 (only it have 3 segments) that is not equal to chars from digit1
            var topSegmentChar = digit7.First(ch => !digit1.Contains(ch));
            
            // digits with 5 segments (2, 3, 5)
            var fiveSegmentDigits = digits.Where(d => d.Length == 5).ToList().ToList();
            
            // from digits with 5 segments (representing 2, 3, 5) can found digit 3 because only it contains all segments from digit 1
            var digit3 = fiveSegmentDigits.First(d => digit1.All(d.Contains));
            
            // from digit 1 and digit 3 can found chars representing horizontal segments
            var horizontalSegmentChars = digit3.Where(ch => !digit1.Contains(ch)).ToList();
            
            // from digit 4 can find center segment char
            var centerSegmentChar = digit4.First(ch => horizontalSegmentChars.Contains(ch));
            
            // knowing top and center segment chars allows to find bottom segment char
            var bottomSegmentChar = horizontalSegmentChars.First(ch => ch != topSegmentChar && ch != centerSegmentChar);
            
            // digits with 6 segments (0, 6, 9)
            var sixSegmentDigits = digits.Where(d => d.Length == 6).ToList();
            
            // from digits with 6 segments (0, 6, 9) can found digit 0 because only it do not contain center segment
            var digit0 = sixSegmentDigits.First(d => !d.Contains(centerSegmentChar));
            
            // from remaining digits with 6 segments (6, 9) can found digit 9 because only it contains all segments from digit 1 
            var digit9 = sixSegmentDigits.Where(d => d != digit0).First(d => digit1.All(d.Contains));

            // bottom left segment is one that is absent in 9 when compare it to 0
            var bottomLeftSegmentChar = digit0.First(ch => !digit9.Contains(ch));
            
            // from digits with 5 segments (representing 2, 3, 5) can found 2 because only it contains left bottom segment
            var digit2 = fiveSegmentDigits.First(d => d.Contains(bottomLeftSegmentChar));
            
            // top right segment char from digit 2 is one that is not horizontal and not left bottom
            var topRightSegmentChar = digit2.First(ch => !horizontalSegmentChars.Contains(ch) && ch != bottomLeftSegmentChar);
            
            // bottom right segment char from digit 1 is one that is not top right
            var bottomRightSegmentChar = digit1.First(ch => ch != topRightSegmentChar);
            
            // top left segment char from digit 4 is one that is not from digit1 and not center segment
            var topLeftSegmentChar = digit4.First(ch => !digit1.Contains(ch) && ch != centerSegmentChar);

            var translation = new Dictionary<char, char>
            {
                [topSegmentChar] = 'a',
                [topLeftSegmentChar] = 'b',
                [topRightSegmentChar] = 'c',
                [centerSegmentChar] = 'd',
                [bottomLeftSegmentChar] = 'e',
                [bottomRightSegmentChar] = 'f',
                [bottomSegmentChar] = 'g'
            };

            var number = 0;
            foreach (var output in entry.Output)
            {
                var translated = new string(output.Select(ch => translation[ch]).ToArray());
                var digit = Display.GetDigit(translated);
                number = number * 10 + digit;
            }

            return number;
        }
    }
}