using Xunit;
using static LeetCode.Problems.Easy.RomanToInteger;

namespace LeetCode.Problems.Tests.Easy;

public sealed class RomanToIntegerTests
{
    [Theory]
    [InlineData("III", 3)]
    [InlineData("IV", 4)]
    [InlineData("IX", 9)]
    [InlineData("LVIII", 58)]
    [InlineData("MCMXCIV", 1994)]
    public void Test(string input, int result)
        => Assert.Equal(result, RomanToInt(input));
}