using Xunit;
using static LeetCode.Problems.Easy.PalindromeNumber;

namespace LeetCode.Problems.Tests.Easy;

public sealed class PalindromeNumberTests
{
    [Theory]
    [InlineData(121, true)]
    [InlineData(-121, false)]
    [InlineData(10, false)]
    [InlineData(-101, false)]
    [InlineData(9999, true)]
    public void Test(int input, bool result)
    {
        Assert.Equal(result, IsPalindrome(input));
        Assert.Equal(result, IsPalindrome2(input));
    }
}