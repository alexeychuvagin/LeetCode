using Xunit;
using static LeetCode.Problems.Medium.ZigZagConversion;

namespace LeetCode.Problems.Tests.Medium;

public sealed class ZigZagConversionTests
{
    [Theory]
    [InlineData("PAYPALISHIRING", 3, "PAHNAPLSIIGYIR")]
    [InlineData("PAYPALISHIRING", 4, "PINALSIGYAHRPI")]
    public void Test(string input, int numRows, string output) 
        => Assert.Equal(output, Convert(input, numRows));
}