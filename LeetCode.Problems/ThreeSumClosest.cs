using System;
using Xunit;

namespace LeetCode.Problems
{
    /// <summary>
    /// Given an array nums of n integers and an integer target, find three integers in nums such that the sum is closest to target.
    /// Return the sum of the three integers.
    /// You may assume that each input would have exactly one solution.
    /// </summary>
    /// <remarks>Medium</remarks>
    /// <seealso cref="https://leetcode.com/problems/3sum-closest/"/>
    public sealed class ThreeSumClosest
    {
        [Theory]
        [InlineData(new[] { -1, 2, 1, -4 }, 1, 2)]
        [InlineData(new[] { 0, 2, 1, -3 }, 1, 0)]
        public void Test(int[] nums, int target, int expected)
            => Assert.Equal(expected, Solution(nums, target)); 

        public int Solution(int[] nums, int target)
        {
            Array.Sort(nums);
            var result = 0;
            var diff = int.MaxValue;

            for (var i = 0; i < nums.Length - 1; i++)
            {
                if (i > 0 && nums[i] == nums[i-1])
                    continue;

                var j = i + 1;
                var k = nums.Length - 1;

                while (j < k)
                {
                    var sum = nums[i] + nums[j] + nums[k];

                    if (sum == target)
                        return sum;

                    var curDiff = Math.Abs(target - sum);
                    
                    if (curDiff < diff)
                    {
                        diff = curDiff;
                        result = sum;
                    }

                    if (sum > target)
                    {
                        do
                        {
                            k--;
                        } while (j < k && nums[k] == nums[k + 1]);
                    }
                    
                    if (sum < target)
                    {
                        do
                        {
                            j++;
                        } while (j < k && nums[j] == nums[j - 1]);
                    }
                }
            }

            return result;
        }
    }
}