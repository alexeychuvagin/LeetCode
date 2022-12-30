using System;

namespace LeetCode.Problems.Hard;

/// <summary>
/// 4. Median of Two Sorted Arrays
/// There are two sorted arrays nums1 and nums2 of size m and n respectively.
/// Find the median of the two sorted arrays.The overall run time complexity should be O(log (m+n)).
/// You may assume nums1 and nums2 cannot be both empty.
/// </summary>
/// <remarks>Hard</remarks>
/// <seealso href="https://leetcode.com/problems/median-of-two-sorted-arrays/"/>
public static class MedianOfTwoSortedArrays
{
    /// <summary>
    /// Complexity O(log(n+m))
    /// </summary>
    public static double Solution(int[] nums1, int[] nums2)
    {
        var pos1 = 0;
        var pos2 = 0;
        var curPos = 0;
        var length = nums1.Length + nums2.Length;
        var center = Math.Ceiling(length / 2D);
        double currentValue = 0;

        while (curPos < center)
        {
            if (pos2 >= nums2.Length || pos1 < nums1.Length && nums1[pos1] < nums2[pos2])
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