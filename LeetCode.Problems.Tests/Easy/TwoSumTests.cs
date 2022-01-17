using LeetCode.Problems.Easy;
using System;
using Xunit;

namespace LeetCode.Problems.Tests.Easy;

public sealed class TwoSumTests
{
    [Theory]
    [InlineData(new int[] { 2, 7, 11, 15 }, 9, new int[] { 0, 1 })]
    [InlineData(new int[0], 0, new int[0])]
    [InlineData(new int[] { 2 }, 0, new int[0])]
    public void Brute_Force_Approach_Test(int[] nums, int target, int[] expectedResult)
        => Assert.Equal(expectedResult, TwoSum.Approach1(nums, target));

    [Theory]
    [InlineData(new int[] { 3, 2, 4 }, 6, new int[] { 1, 2 })]
    //[InlineData(new int[] { 2, 7, 11, 15 }, 9, new int[] { 0, 1 })]
    //[InlineData(new int[0], 0, new int[0])]
    //[InlineData(new int[] { 2 }, 0, new int[0])]
    public void Two_Pass_Hash_Table_Approach_Test(int[] nums, int target, int[] expectedResult)
    {
        Assert.Equal(expectedResult, TwoSum.Approach2(nums, target));
    }

    [Theory]
    [InlineData(new int[] { 2, 7, 11, 15 }, 9, new int[] { 0, 1 })]
    [InlineData(new int[0], 0, new int[0])]
    [InlineData(new int[] { 2 }, 0, new int[0])]
    public void One_Pass_Hash_Table_Approach_Test(int[] nums, int target, int[] expectedResult)
    {
        var result = TwoSum.Approach3(nums, target);
        Array.Sort(result);
        Assert.Equal(expectedResult, result);
    }
}
