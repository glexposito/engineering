namespace Algorithms;

public static class Easy
{
    public static bool CanConstruct(string ransomNote, string magazine)
    {
        var ransomNoteLettersCount = new int[26];
        var magazineLettersCount = new int[26];

        foreach (var letter in ransomNote)
        {
            ransomNoteLettersCount[letter - 'a']++;
        }

        foreach (var letter in magazine)
        {
            magazineLettersCount[letter - 'a']++;
        }

        for (var i = 0; i < ransomNoteLettersCount.Length; i++)
        {
            if (magazineLettersCount[i] < ransomNoteLettersCount[i])
            {
                return false;
            }
        }

        return true;
    }

    public static bool CheckValid(int[][] matrix)
    {
        List<HashSet<int>> sets = [];
        var matrixSum = matrix.Length * 2;
        for (var i = 0; i < matrixSum; i++)
        {
            sets.Add([]);
        }

        for (var i = 0; i < matrix.Length; i++)
        {
            foreach (var number in matrix[i])
            {
                sets[i].Add(number);
            }

            if (sets[i].Count != matrix.Length)
            {
                return false;
            }
        }

        for (var column = 0; column < matrix.Length; column++)
        {
            var setIndex = column + matrix.Length;

            for (var row = 0; row < matrix.Length; row++)
            {
                var number = matrix[row][column];
                sets[setIndex].Add(number);
            }

            if (sets[setIndex].Count != matrix.Length)
            {
                return false;
            }
        }

        return true;
    }

    // https://leetcode.com/problems/crawler-log-folder/
    public static int MinOperations(string[] logs)
    {
        var depth = 0;

        foreach (var log in logs)
        {
            if (log == "../")
            {
                if (depth > 0) depth--;
            }
            else if (log != "./")
            {
                depth++;
            }
        }

        return depth;
    }

    // 121. Best Time to Buy and Sell Stock https://leetcode.com/problems/best-time-to-buy-and-sell-stock/
    public static int MaxProfit(int[] prices)
    {
        var maxProfit = 0;
        var minPrice = prices[0];

        for (var i = 1; i < prices.Length; i++)
        {
            var currentPrice = prices[i];
            maxProfit = Math.Max(currentPrice - minPrice, maxProfit);
            minPrice = Math.Min(currentPrice, minPrice);
        }

        return maxProfit;
    }

    // 13. Roman to Integer https://leetcode.com/problems/roman-to-integer/
    public static int RomanToInt(string s)
    {
        var result = 0;

        Dictionary<char, int> map = [];
        map.Add('I', 1);
        map.Add('V', 5);
        map.Add('X', 10);
        map.Add('L', 50);
        map.Add('C', 100);
        map.Add('D', 500);
        map.Add('M', 1000);

        var previous = 0;

        for (var i = s.Length - 1; i >= 0; i--)
        {
            var value = map[s[i]];
            if (value < previous)
            {
                result -= value;
            }
            else
            {
                result += value;
            }

            previous = value;
        }

        return result;
    }
}