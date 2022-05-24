using Xunit;
using static LeetCode.Problems.Hard.RegularExpressionMatching;

namespace LeetCode.Problems.Tests.Hard;

public sealed class RegularExpressionMatchingTests
{
    [Theory]
    [InlineData("aa", "a", false)]
    [InlineData("aa", "aa", true)]
    [InlineData("aa", "aaa", false)]
    [InlineData("aa", "a*", true)]
    [InlineData("ab", ".*", true)]
    [InlineData("aab", "c*a*b", true)]
    [InlineData("mississippi", "mis*is*p*.", false)]
    [InlineData("aaa", "a*a.", true)]
    public void Test(string input, string pattern, bool output)
        => Assert.Equal(output, IsMatch(input, pattern));
}