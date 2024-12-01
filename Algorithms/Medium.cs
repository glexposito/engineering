using System.Text;

namespace Algorithms;

public static class Medium
{
    // 49. Group Anagrams https://leetcode.com/problems/group-anagrams/description/
    public static IList<IList<string>> GroupAnagrams(string[] words)
    {
        Dictionary<string, List<string>> groups = [];

        foreach (var word in words)
        {
            var sortedString = new string(word.Order().ToArray());
            if (!groups.TryAdd(sortedString, [word]))
            {
                groups[sortedString].Add(word);
            }
        }

        return groups.Values.ToList<IList<string>>();
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
}