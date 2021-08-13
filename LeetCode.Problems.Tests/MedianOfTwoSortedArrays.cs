using System;
using Xunit;

namespace LeetCode.Problems.Tests
{
    /// <summary>
    /// There are two sorted arrays nums1 and nums2 of size m and n respectively.
    /// Find the median of the two sorted arrays.The overall run time complexity should be O(log (m+n)).
    /// You may assume nums1 and nums2 cannot be both empty.
    /// </summary>
    /// <remarks>Hard</remarks>
    /// <seealso cref="https://leetcode.com/problems/median-of-two-sorted-arrays/"/>
    public sealed class MedianOfTwoSortedArrays
    {
        [Theory]
        [InlineData(new int[] { 1, 3 }, new int[] { 2 }, 2)]
        [InlineData(new int[] { 1, 2 }, new int[] { 3, 4 }, 2.5)]
        public void Test(int[] nums1, int[] nums2, double result)
        {
            Assert.Equal(result, Solution(nums1, nums2));
        }

        /// <summary>
        /// Complexity O(log(n+m))
        /// </summary>
        private double Solution(int[] nums1, int[] nums2)
        {
            var pos1 = 0;
            var pos2 = 0;
            var curPos = 0;
            var length = nums1.Length + nums2.Length;
            var center = Math.Ceiling(length / 2D);
            double currentValue = 0;

            while (curPos < center)
            {
                if (pos2 >= nums2.Length || (pos1 < nums1.Length && nums1[pos1] < nums2[pos2]))
                {
                    currentValue = nums1[pos1];
                    pos1++;
                }
                else
                {
                    currentValue = nums2[pos2];
                    pos2++;
                }

                curPos = pos1 + pos2;
            }

            if (length % 2 == 0)
            {
                var nextValue = int.MaxValue;

                if (pos1 < nums1.Length)
                    nextValue = nums1[pos1];

                if (pos2 < nums2.Length)
                    nextValue = Math.Min(nextValue, nums2[pos2]);

                currentValue = (currentValue + nextValue) / 2;
            }

            return currentValue;
        }
    }
}