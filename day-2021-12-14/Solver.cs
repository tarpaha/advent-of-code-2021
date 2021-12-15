namespace day_2021_12_14;

public static class Solver
{
    public static int Part1(Data data)
    {
        var template = ProcessSteps(data, 10).GroupBy(ch => ch).ToList();
        var min = template.Min(g => g.Count());
        var max = template.Max(g => g.Count());
        return max - min;
    }

    public static string ProcessSteps(Data data, int stepsCount)
    {
        var template = new LinkedList<char>(data.Template);
        var pairs = data.Pairs.ToDictionary(pair => (pair.Item1[0], pair.Item1[1]), pair => pair.Item2);

        for (var step = 0; step < stepsCount; step++)
        {
            var prev = template.First;
            while (prev != template.Last)
            {
                var current = prev!.Next;
                if (pairs.TryGetValue((prev.Value, current!.Value), out var ch))
                {
                    template.AddAfter(prev, ch);
                }
                prev = current;
            }
        }

        return string.Join("", template);
    }

    public static long Part2(Data data)
    {
        return ProcessStepsQuick(data, 40);
    }
    
    public static long ProcessStepsQuick(Data data, int stepsCount)
    {
        // CH -> B converted to (CH) -> (CB, B, BH)  
        var pairToPairs = data.Pairs.ToDictionary(
            p => p.Item1,
            p => (pair1: new string(new [] { p.Item1[0], p.Item2}), middle: p.Item2 , pair2: new string(new [] { p.Item2, p.Item1[1]})));

        // dictionary template, used to speedup dictionaries init
        var charsDict = pairToPairs.Keys.SelectMany(s => s).Distinct().ToDictionary(ch => ch, _ => 0L);

        // main data holder
        // contains (step, pair) => number of each character for the pair on this step
        // fill at zero step (number of characters is equal to number of characters in pair)
        var charCountPerStepAndPair = new Dictionary<(int, string), Dictionary<char, long>>();
        foreach (var pair in pairToPairs.Keys)
        {
            var charsCount = new Dictionary<char, long>(charsDict);
            foreach (var ch in pair)
            {
                charsCount[ch] += 1;
            }
            charCountPerStepAndPair.Add((0, pair), charsCount);
        }
        
        // algorithm is:
        //     number of characters that produces pair on step N is equal to
        //     sum of characters from two resulting pairs on step N-1 minus middle character
        // i.e. for NN -> C
        // NN(1) = NC(0) - C + CN(0) = NCN
        // after first loop have all step 1 data calculated, so can calculate step 2 and so
        // i.e. for step 2 
        // NN(2) = NC(1) - C + CN(1)
        // NN(2) = NBC   - C + CCN
        // NN(2) = NBCCN
        for (var step = 1; step <= stepsCount; step++)
        {
            foreach (var pair in pairToPairs.Keys)
            {
                var (pair1, middle, pair2) = pairToPairs[pair];
                var pair1CharsCount = charCountPerStepAndPair[(step - 1, pair1)];
                var pair2CharsCount = charCountPerStepAndPair[(step - 1, pair2)];
                var charsCount = new Dictionary<char, long>(charsDict);
                foreach (var ch in charsCount.Keys)
                {
                    charsCount[ch] = pair1CharsCount[ch] + pair2CharsCount[ch];
                }
                charsCount[middle] -= 1;
                charCountPerStepAndPair.Add((step, pair), charsCount);
            }
        }

        // have characters count of each pair for required step
        // can calculate final character count
        
        var resultCharsCount = new Dictionary<char, long>(charsDict);
        var prev = data.Template[0];
        for(var id = 1; id < data.Template.Length; id++)
        {
            var ch = data.Template[id];
            var pair = new string(new[] { prev, ch });
            var pairCharsCount = charCountPerStepAndPair[(stepsCount, pair)];
            foreach (var chKey in resultCharsCount.Keys)
            {
                resultCharsCount[chKey] += pairCharsCount[chKey];
            }
            // same as in calculation, remove char between pairs
            if (id > 1)
                resultCharsCount[prev] -= 1;
            prev = ch;
        }

        var counts = resultCharsCount.Values;
        return counts.Max() - counts.Min();
    }
}