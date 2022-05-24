using System.Linq;
using Xunit;
using static LeetCode.Problems.Medium.LettersCombinationOfAPhoneNumber;

namespace LeetCode.Problems.Tests.Medium;

public sealed class LettersCombinationOfAPhoneNumberTests
{
    [Theory]
    [InlineData("23", new[] { "ad", "ae", "af", "bd", "be", "bf", "cd", "ce", "cf" })]
    [InlineData("2", new[] { "a", "b", "c" })]
    public void Test(string input, string[] expected)
    {
        var result = LetterCombinations(input).ToArray();

        Assert.Equal(expected.Length, result.Length);

        foreach (var el in result)
            Assert.Contains(el, expected);

        foreach (var el in expected)
            Assert.Contains(el, result);
    }
}