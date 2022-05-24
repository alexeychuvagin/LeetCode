using Xunit;
using static LeetCode.Problems.Medium.ReverseInteger;

namespace LeetCode.Problems.Tests.Medium;

public sealed class ReverseIntegerTests
{
    [Theory]
    [InlineData(123, 321)]
    [InlineData(-123, -321)]
    [InlineData(120, 21)]
    [InlineData(0, 0)]
    [InlineData(1534236469, 0)]
    public void Test(int input, int output) 
        => Assert.Equal(output, Reverse(input));
}