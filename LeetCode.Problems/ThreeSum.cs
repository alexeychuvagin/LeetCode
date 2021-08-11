using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace LeetCode.Problems
{
    /// <summary>
    /// Given an array nums of n integers, are there elements a, b, c in nums such that a + b + c = 0?
    /// Find all unique triplets in the array which gives the sum of zero.Notice that the solution set must not contain duplicate triplets.
    /// Notice that the solution set must not contain duplicate triplets.
    /// </summary>
    /// <remarks>Medium</remarks>
    /// <seealso cref="https://leetcode.com/problems/3sum/"/>
    public sealed class ThreeSum
    {
        public static IEnumerable<object[]> TestCases()
        {
            yield return new object[]
            {
                new[] {-1, 0, 1, 2, -1, -4},
                new[] {new[] {-1, -1, 2}, new[] {-1, 0, 1}}
            };
            yield return new object[]
            {
                new[] {0, 0, 0, 0},
                new[] {new[] {0, 0, 0}}
            };
        }

        [Theory]
        [MemberData(nameof(TestCases))]
        public void Two_Pointers_Approach_Test(int[] input, int[][] output)
        {
            var result = TwoPointersApproach(input)
                .Select(x => x.ToArray())
                .ToArray();

            Assert.Equal(output.Length, result.Length);

            output = output.Select(x =>
            {
                Array.Sort(x);
                return x;
            }).ToArray();

            result = result.Select(x =>
            {
                Array.Sort(x);
                return x;
            }).ToArray();

            for (var i = 0; i < output.Length; i++)
            {
                Assert.Equal(output[i].Length, result[i].Length);

                for (var j = 0; j < output[i].Length; j++)
                {
                    Assert.Equal(output[i][j], result[i][j]);
                }
            }
        }

        private IList<IList<int>> TwoPointersApproach(int[] nums)
        {
            if (nums.Length < 3)
            {
                return new List<IList<int>>(0);
            }

            var result = new List<IList<int>>();

            Array.Sort(nums);

            for (var left = 0; left < nums.Length - 2; left++)
            {
                if (left > 0 && nums[left] == nums[left - 1])
                {
                    continue;
                }

                var middle = left + 1;
                var right = nums.Length - 1;

                var requiredSum = 0 - nums[left];

                while (middle < right)
                {
                    var currentResult = nums[middle] + nums[right];

                    if (currentResult < requiredSum)
                    {
                        middle++;
                    }
                    else if (currentResult > requiredSum)
                    {
                        right--;
                    }
                    else
                    {
                        result.Add(new List<int>() { nums[left], nums[middle], nums[right] });
                        middle++;

                        while (middle < right && nums[middle] == nums[middle - 1])
                        {
                            middle++;
                        }
                    }
                }
            }

            return result;
        }
    }
}