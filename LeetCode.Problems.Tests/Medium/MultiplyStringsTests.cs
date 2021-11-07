using LeetCode.Problems.Medium;
using Xunit;

namespace LeetCode.Problems.Tests.Medium;

public class MultiplyStringsTests
{
    [Theory]
    [InlineData("2", "3", "6")]
    [InlineData("11", "88", "968")]
    [InlineData("123", "456", "56088")]
    [InlineData("36", "427", "15372")]
    [InlineData("123456789", "987654321", "121932631112635269")]
    [InlineData("9133", "0", "0")]
    [InlineData("0", "9133", "0")]
    public void MultiplyTest(string num1, string num2, string output)
        => Assert.Equal(output, MultiplyStrings.Multiply(num1, num2));
}