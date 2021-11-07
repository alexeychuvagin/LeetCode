using System;
using System.Collections.Generic;

namespace LeetCode.Problems.Easy;

/// <summary>
/// Given an array of integers, return indices of the two numbers such that they add up to a specific target.
/// You may assume that each input would have exactly one solution, and you may not use the same element twice.
/// </summary>
/// <remarks>Easy</remarks>
/// <seealso cref="https://leetcode.com/problems/two-sum/"/>
public static class TwoSum
{
    /// <summary>
    /// Approach 1: Brute Force
    /// Complexity O(n^2)
    /// </summary>
    public static int[] Approach1(int[] nums, int target)
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

        return Array.Empty<int>();
    }

    /// <summary>
    /// Approach 2: Two-pass Hash Table
    /// Complexity O(2n)
    /// </summary>
    public static int[] Approach2(int[] nums, int target)
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
    public static int[] Approach3(int[] nums, int target)
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