using System;
using System.Linq;
using System.Collections.Generic;
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
        public void Brute_Force_Test(int[] nums, int target, int[] expectedResult)
        {
            Assert.Equal(expectedResult, Approach1(nums, target));
        }

        [Theory]
        [InlineData(new int[] { 2, 7, 11, 15 }, 9, new int[] { 0, 1 })]
        [InlineData(new int[0], 0, new int[0])]
        [InlineData(new int[] { 2 }, 0, new int[0])]
        public void Two_Pass_Hash_Table_Test(int[] nums, int target, int[] expectedResult)
        {
            Assert.Equal(expectedResult, Approach2(nums, target));
        }

        [Theory]
        [InlineData(new int[] { 2, 7, 11, 15 }, 9, new int[] { 0, 1 })]
        [InlineData(new int[0], 0, new int[0])]
        [InlineData(new int[] { 2 }, 0, new int[0])]
        public void One_Pass_Hash_Table_Test(int[] nums, int target, int[] expectedResult)
        {
            var result = Approach3(nums, target);
            Array.Sort(result);

            Assert.Equal(expectedResult, result);
        }

        /// <summary>
        /// Approach 1: Brute Force
        /// Complexity O(n^2)
        /// </summary>
        private int[] Approach1(int[] nums, int target)
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

        /// <summary>
        /// Approach 2: Two-pass Hash Table
        /// Complexity O(2n)
        /// </summary>
        private int[] Approach2(int[] nums, int target)
        {
            var dict = new Dictionary<int, int>(nums.Length);

            for (int i = 0; i < nums.Length; i++)
            {
                dict.Add(nums[i], i);
            }

            for (int i = 0; i < nums.Length; i++)
            {
                var complement = target - nums[i];

                if (dict.TryGetValue(complement, out var index))
                {
                    return new int[] { i, index };
                }
            }

            return Array.Empty<int>();
        }

        /// <summary>
        /// Approach 3: One-pass Hash Table
        /// Complexity O(n)
        /// </summary>
        private int[] Approach3(int[] nums, int target)
        {
            var dict = new Dictionary<int, int>(nums.Length);

            for (int i = 0; i < nums.Length; i++)
            {
                var complement = target - nums[i];

                if (dict.TryGetValue(complement, out var index))
                {
                    return new int[] { i, index };
                }

                dict.Add(nums[i], i);
            }

            return Array.Empty<int>();
        }
    }
}