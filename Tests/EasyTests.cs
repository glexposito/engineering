using System.Runtime.InteropServices;
using Algorithms;
using FluentAssertions;

namespace Tests;

public class EasyTests
{
    [Theory]
    [InlineData("a", "b", false)]
    [InlineData("aa", "ab", false)]
    [InlineData("aa", "aab", true)]
    public void CanConstruct(string ransomNote, string magazine, bool expectedResult)
    {
        Easy.CanConstruct(ransomNote, magazine).Should().Be(expectedResult);
    }

    [Fact]
    public void CheckValid_ShouldReturnFalse()
    {
        var matrix = new int[3][];
        matrix[0] = [1, 2, 3];
        matrix[1] = [1, 2, 3];
        matrix[2] = [1, 2, 3];

        Easy.CheckValid(matrix).Should().BeFalse();
    }

    [Fact]
    public void CheckValid_ShouldReturnTrue()
    {
        var matrix = new int[3][];
        matrix[0] = [1, 2, 3];
        matrix[1] = [3, 2, 1];
        matrix[2] = [2, 3, 1];

        Easy.CheckValid(matrix).Should().BeFalse();
    }

    [Fact]
    public void MinOperations_ShouldReturnTwo()
    {
        string[] logs = ["d1/", "d2/", "../", "d21/", "./"];

        Easy.MinOperations(logs).Should().Be(2);
    }

    [Fact]
    public void MinOperations_ShouldReturnZero()
    {
        string[] logs = ["./", "../", "./"];

        Easy.MinOperations(logs).Should().Be(0);
    }

    [Fact]
    public void MaxProfit()
    {
        int[] prices = [7, 1, 5, 3, 6, 4];

        Easy.MaxProfit(prices).Should().Be(5);
    }

    [Theory]
    [InlineData("III", 3)]
    [InlineData("LVIII", 58)]
    [InlineData("MCMXCIV", 1994)]
    public void RomanToInt(string s, int expectedInt)
    {
        Easy.RomanToInt(s).Should().Be(expectedInt);
    }
}