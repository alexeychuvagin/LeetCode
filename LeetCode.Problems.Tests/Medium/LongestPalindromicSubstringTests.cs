using Xunit;
using static LeetCode.Problems.Medium.LongestPalindromicSubstring;

namespace LeetCode.Problems.Tests.Medium;

public sealed class LongestPalindromicSubstringTests
{
    [Theory]
    [InlineData("babad", "bab")]
    [InlineData("cbbd", "bb")]
    [InlineData("a", "a")]
    [InlineData("bb", "bb")]
    [InlineData("ccd", "cc")]
    [InlineData("aaaa", "aaaa")]
    public void Test(string input, string output) 
        => Assert.Equal(output, Solution(input));
}