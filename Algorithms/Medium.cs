using System.Text;

namespace Algorithms;

public static class Medium
{
    // 49. Group Anagrams https://leetcode.com/problems/group-anagrams/description/
    public static IList<IList<string>> GroupAnagrams(string[] strs)
    {
        Dictionary<string, IList<string>> groups = [];

        foreach (var word in strs)
        {
            var key = new string(word.Order().ToArray());

            if (!groups.TryAdd(key, [word]))
            {
                groups[key].Add(word);
            }
        }

        return groups.Select(group => group.Value).ToList();
    }

    // 373. Find K Pairs with Smallest Sums https://leetcode.com/problems/find-k-pairs-with-smallest-sums/description/
    public static IList<IList<int>> KSmallestPairs(int[] nums1, int[] nums2, int k)
    {
        var priorityQueue = new PriorityQueue<List<int>, int>();

        for (var i = 0; i < Math.Min(k, nums1.Length); i++)
        {
            priorityQueue.Enqueue([i, 0], nums1[i] + nums2[0]);
        }

        IList<IList<int>> result = [];

        while (priorityQueue.Count > 0 && k > 0)
        {
            var current = priorityQueue.Dequeue();
            result.Add([nums1[current[0]], nums2[current[1]]]);

            --k;

            if (current[1] + 1 < nums2.Length)
            {
                priorityQueue.Enqueue([current[0], current[1] + 1], nums1[current[0]] + nums2[current[1] + 1]);
            }
        }

        return result;
    }

    public static string AddBinaryStrings(string a, string b)
    {
        var indexA = a.Length - 1;
        var indexB = b.Length - 1;
        var carry = 0;
        var result = new StringBuilder();

        while (indexA >= 0 || indexB >= 0 || carry > 0)
        {
            var digitA = indexA >= 0 ? a[indexA--] - '0' : 0;
            var digitB = indexB >= 0 ? b[indexB--] - '0' : 0;

            var sum = digitA + digitB + carry;
            result.Append(sum % 2);
            carry = sum / 2;
        }

        var charArray = result.ToString().ToCharArray();
        Array.Reverse(charArray);
        return new string(charArray);
    }

    // https://leetcode.com/problems/high-access-employees/
    // ReSharper disable once InconsistentNaming
    public static IList<string> FindHighAccessEmployees(IList<IList<string>> access_times)
    {
        IList<string> highAccessEmployees = [];
        Dictionary<string, IList<TimeOnly>> logs = [];

        foreach (var record in access_times)
        {
            var employee = record[0];
            var hour = int.Parse(record[1][..2]);
            var minute = int.Parse(record[1][2..]);
            var accessTime = new TimeOnly(hour, minute);

            if (!logs.TryAdd(employee, [accessTime]))
            {
                logs[employee].Add(accessTime);
            }
        }

        foreach (var log in logs)
        {
            var orderedAccessTimes = log.Value.Order().ToList();
            for (var i = 0; i < orderedAccessTimes.Count; i++)
            {
                if (i + 2 < orderedAccessTimes.Count
                    && orderedAccessTimes[i + 2] - orderedAccessTimes[i] < TimeSpan.FromHours(1))
                {
                    highAccessEmployees.Add(log.Key);
                    break;
                }
            }
        }

        return highAccessEmployees;
    }

    public static int[][] Merge(int[][] intervals)
    {
        var orderedIntervals = intervals
            .OrderBy(interval => interval[0])
            .ToArray();

        List<int[]> mergedIntervals = [orderedIntervals[0]];

        for (var i = 1; i < orderedIntervals.Length; i++)
        {
            var lastMergedInterval = mergedIntervals[^1];
            var orderedInterval = orderedIntervals[i];

            if (lastMergedInterval[1] >= orderedInterval[0])
            {
                lastMergedInterval[1] = Math.Max(lastMergedInterval[1], orderedInterval[1]);
            }
            else
            {
                mergedIntervals.Add(orderedInterval);
            }
        }

        return mergedIntervals.ToArray();
    }

    public static int SingleNonDuplicate(int[] nums)
    {
        var nonDuplicatedNumber = nums[0];

        for (var i = 1; i < nums.Length; i++)
        {
            nonDuplicatedNumber ^= nums[i];
        }

        return nonDuplicatedNumber;
    }


    // 540. Single Element in a Sorted Array https://leetcode.com/problems/single-element-in-a-sorted-array
    public static int SingleNonDuplicateLogN(int[] nums)
    {
        int left = 0, right = nums.Length - 1;

        while (left < right)
        {
            var mid = (left + right) / 2;

            // Ensure mid is even for comparison
            if (mid % 2 == 1) mid--;

            // Compare with the next element
            if (nums[mid] == nums[mid + 1])
            {
                // Single element is in the right half
                left = mid + 2;
            }
            else
            {
                // Single element is in the left half
                right = mid;
            }
        }

        return nums[left];
    }

    // 794. Valid Tic-Tac-Toe State https://leetcode.com/problems/valid-tic-tac-toe-state/
    public static bool ValidTicTacToe(string[] board)
    {
        return false;
    }

    // 11. Container With Most Water https://leetcode.com/problems/container-with-most-water/description/
    public static int MaxArea(int[] height)
    {
        var left = 0;
        var right = height.Length - 1;

        var maxArea = right * Math.Min(height[left], height[right]);

        while (left < right)
        {
            if (height[left] > height[right])
            {
                right--;
            }
            else
            {
                left++;
            }

            var area = (right - left) * Math.Min(height[left], height[right]);

            maxArea = Math.Max(area, maxArea);
        }

        return maxArea;
    }

    // 187. Repeated DNA Sequences https://leetcode.com/problems/repeated-dna-sequences/
    public static IList<string> FindRepeatedDnaSequences(string s)
    {
        HashSet<string> sequences = [];
        HashSet<string> repeatedSequences = [];

        for (var i = 0; i < s.Length - 9; i++)
        {
            var sequence = s.Substring(i, 10);
            if (!sequences.Add(sequence))
            {
                repeatedSequences.Add(sequence);
            }
        }

        return repeatedSequences.ToList();
    }

    // 187. Repeated DNA Sequences https://leetcode.com/problems/repeated-dna-sequences/
    public static IList<string> FindRepeatedDnaSequences1(string s)
    {
        Dictionary<string, int> dnaMap = [];

        for (var i = 0; i < s.Length - 9; i++)
        {
            var sequence = s.Substring(i, 10);
            if (!dnaMap.TryAdd(sequence, 1))
            {
                dnaMap[sequence]++;
            }
        }

        List<string> repeatedSequences = [];

        foreach (var valuePar in dnaMap)
        {
            if (valuePar.Value > 1)
            {
                repeatedSequences.Add(valuePar.Key);
            }
        }

        return repeatedSequences;
    }

    // 12. Integer to Roman https://leetcode.com/problems/integer-to-roman/
    public static string IntToRoman(int num)
    {
        var romanNumber = string.Empty;

        string[] symbols = ["M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I"];
        int[] values = [1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1];

        var index = 0;

        while (num > 0)
        {
            var value = values[index];

            if (num >= value)
            {
                num -= value;
                romanNumber += symbols[index];
            }
            else
            {
                index++;
            }
        }

        return romanNumber;
    }
}