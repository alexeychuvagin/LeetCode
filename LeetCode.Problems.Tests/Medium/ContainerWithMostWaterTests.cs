using static LeetCode.Problems.Medium.ContainerWithMostWater;
using Xunit;

namespace LeetCode.Problems.Tests.Medium;

public sealed class ContainerWithMostWaterTests
{
    [Theory]
    [InlineData(new[] { 1, 1 }, 1)]
    [InlineData(new[] { 4, 3, 2, 1, 4 }, 16)]
    [InlineData(new[] { 1, 2, 1 }, 2)]
    public void Test(int[] input, int output)
        => Assert.Equal(output, MaxArea(input));
}