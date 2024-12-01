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