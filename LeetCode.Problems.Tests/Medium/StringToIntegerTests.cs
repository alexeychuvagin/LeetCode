using Xunit;
using static LeetCode.Problems.Medium.StringToInteger;

namespace LeetCode.Problems.Tests.Medium;

public sealed class StringToIntegerTests
{
    [Theory]
    [InlineData("   -42", -42)]
    [InlineData("-42   ", -42)]
    [InlineData("4193 with words", 4193)]
    [InlineData("words and 987", 0)]
    [InlineData("-91283472332", -2147483648)]
    [InlineData("-2147483648", -2147483648)]
    public void Test(string input, int output) 
        => Assert.Equal(output, MyAtoi(input));
}