namespace LeetCode.Problems;

/// <summary>
/// Given an array nums of n integers, are there elements a, b, c in nums such that a + b + c = 0?
/// Find all unique triplets in the array which gives the sum of zero.Notice that the solution set must not contain duplicate triplets.
/// Notice that the solution set must not contain duplicate triplets.
/// </summary>
/// <remarks>Medium</remarks>
/// <seealso cref="https://leetcode.com/problems/3sum/"/>
public static class ThreeSum
{
    /// <summary>
    /// Approach 1: Two pointers
    /// Complexity O(n)
    /// </summary>
    public static IList<IList<int>> Approach1(int[] nums)
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