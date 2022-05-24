using Xunit;
using static LeetCode.Problems.Hard.MedianOfTwoSortedArrays;

namespace LeetCode.Problems.Tests.Hard;

public sealed class MedianOfTwoSortedArraysTests
{
    [Theory]
    [InlineData(new int[] { 1, 3 }, new int[] { 2 }, 2)]
    [InlineData(new int[] { 1, 2 }, new int[] { 3, 4 }, 2.5)]
    public void Test(int[] nums1, int[] nums2, double result) 
        => Assert.Equal(result, Solution(nums1, nums2));
}