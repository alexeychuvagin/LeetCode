using Xunit;

namespace LeetCode.Problems
{
    /// <summary>
    /// Given an array of integers, return indices of the two numbers such that they add up to a specific target.
    /// You may assume that each input would have exactly one solution, and you may not use the same element twice.
    /// </summary>
    /// <remarks>Easy</remarks>
    /// <seealso cref="https://leetcode.com/problems/two-sum/"/>
    public sealed class TwoSum
    {
        [Theory]
        [InlineData(new int[] { 2, 7, 11, 15 }, 9, new int[] { 0, 1 })]
        [InlineData(new int[0], 0, new int[0])]
        [InlineData(new int[] { 2 }, 0, new int[0])]
        public void Test(int[] nums, int target, int[] result)
        {
            Assert.Equal(result, Solution(nums, target));
        }

        private int[] Solution(int[] nums, int target)
        {
            int i = 0;

            while (i < nums.Length)
            {
                int j = i + 1;

                while (j < nums.Length)
                {
                    if (nums[i] + nums[j] == target)
                        return new int[] { i, j };

                    j++;
                }

                i++;
            }

            return new int[0];
        }
    }
}