using LeetCode.Problems.Easy;
using Xunit;

namespace LeetCode.Problems.Tests.Easy;

public sealed class ValidParenthesesTests
{
    [Theory]
    [InlineData("()", true)]
    [InlineData("()[]{}", true)]
    [InlineData("(]", false)]
    [InlineData("([)]", false)]
    [InlineData("{[]}", true)]
    [InlineData("{", false)]
    [InlineData("((", false)]
    public void Approach1(string input, bool expectedResult)
        => Assert.Equal(expectedResult, ValidParentheses.IsValid(input));
}
