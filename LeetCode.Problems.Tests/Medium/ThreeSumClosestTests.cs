using Xunit;
using static LeetCode.Problems.Medium.ThreeSumClosest;

namespace LeetCode.Problems.Tests.Medium;

public sealed class ThreeSumClosestTests
{
    [Theory]
    [InlineData(new[] { -1, 2, 1, -4 }, 1, 2)]
    [InlineData(new[] { 0, 2, 1, -3 }, 1, 0)]
    public void Test(int[] nums, int target, int expected)
        => Assert.Equal(expected, Solution(nums, target));
}