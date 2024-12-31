using Algorithms;
using FluentAssertions;

namespace Tests;

public class MediumTests
{
    [Fact]
    public void Test_GroupAnagrams()
    {
        string[] words = ["eat", "tea", "tan", "ate", "nat", "bat"];

        IList<IList<string>> expectedGroups = [["bat"], ["nat", "tan"], ["ate", "eat", "tea"]];

        Medium.GroupAnagrams(words).Should().BeEquivalentTo(expectedGroups);
    }

    [Theory]
    [MemberData(nameof(TestDataKSmallestPairs))]
    public void Test_KSmallestPairs(int[] nums1, int[] nums2, int k, List<List<int>> expected)
    {
        Medium.KSmallestPairs(nums1, nums2, k).Should().BeEquivalentTo(expected);
    }

    [Theory]
    [InlineData("1", "1", "10")]
    [InlineData("11", "11", "110")]
    [InlineData("111", "101", "1100")]
    [InlineData("111", "1101", "10100")]
    [InlineData("100", "11", "111")]
    [InlineData("111", "1011", "10010")]
    public void Test_AddBinaryStrings(string a, string b, string expected)
    {
        Medium.AddBinaryStrings(a, b).Should().Be(expected);
    }

    [Fact]
    public void Test_FindHighAccessEmployees()
    {
        IList<IList<string>> accessTimes =
            [["a", "0549"], ["b", "0457"], ["a", "0532"], ["a", "0621"], ["b", "0540"]];

        var result = Medium.FindHighAccessEmployees(accessTimes);

        result.Should().Equal(["a"]);
    }

    [Fact]
    public void Test_Merge()
    {
        int[][] intervals = [[1, 3], [2, 6], [8, 10], [15, 18]];
        int[][] expected = [[1, 6], [8, 10], [15, 18]];

        var result = Medium.Merge(intervals);

        result.Should().BeEquivalentTo(expected, options => options.WithStrictOrdering());
    }

    [Theory]
    [InlineData(new int[] { 1, 1, 2, 3, 3, 4, 4, 8, 8 }, 2)]
    [InlineData(new int[] { 3, 3, 7, 7, 10, 11, 11 }, 10)]
    public void SingleNonDuplicate(int[] nums, int expected)
    {
        Medium.SingleNonDuplicateLogN(nums).Should().Be(expected);
    }

    [Fact]
    public void MaxArea()
    {
        int[] height = [10, 14, 10, 4, 10, 2, 6, 1, 6, 12];

        Medium.MaxArea(height).Should().Be(96);
    }

    [Theory]
    [InlineData("AAAAACCCCCAAAAACCCCCCAAAAAGGGTTT", new string[] { "AAAAACCCCC", "CCCCCAAAAA" })]
    [InlineData("AAAAAAAAAAAAA", new string[] { "AAAAAAAAAA" })]
    public void FindRepeatedDnaSequences(string sequence, IList<string> sequences)
    {
        Medium.FindRepeatedDnaSequences(sequence).Should().Equal(sequences);
    }
    
    [Theory]
    [InlineData("AAAAACCCCCAAAAACCCCCCAAAAAGGGTTT", new string[] { "AAAAACCCCC", "CCCCCAAAAA" })]
    [InlineData("AAAAAAAAAAAAA", new string[] { "AAAAAAAAAA" })]
    public void FindRepeatedDnaSequences1(string sequence, IList<string> sequences)
    {
        Medium.FindRepeatedDnaSequences1(sequence).Should().Equal(sequences);
    }

    [Theory]
    [InlineData(3749, "MMMDCCXLIX")]
    [InlineData(58, "LVIII")]
    [InlineData(1994, "MCMXCIV")]
    public void IntToRoman(int num, string expectedRoman)
    {
        Medium.IntToRoman(num).Should().Be(expectedRoman);
    }

    public static IEnumerable<object[]> TestDataKSmallestPairs =>
        new List<object[]>
        {
            new object[]
            {
                new[] { 1, 7, 11 }, new[] { 2, 4, 6 }, 3,
                new List<List<int>> { new List<int> { 1, 2 }, new List<int> { 1, 4 }, new List<int> { 1, 6 } }
            },
            new object[]
            {
                new[] { 1, 1, 2 }, new[] { 1, 2, 3 }, 2,
                new List<List<int>> { new List<int> { 1, 1 }, new List<int> { 1, 1 } }
            }
        };
}