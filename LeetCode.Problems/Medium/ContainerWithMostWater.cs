using System;

namespace LeetCode.Problems.Medium;

/// <summary>
/// 11. Container With Most Water
/// Given n non-negative integers a1, a2, ..., an , where each represents a point at coordinate (i, ai).
/// n vertical lines are drawn such that the two endpoints of the line i is at (i, ai) and (i, 0). Find two lines, which, together with the x-axis forms a container, such that the container contains the most water.
/// Notice that you may not slant the container.
/// </summary>
/// <remarks>Medium</remarks>
/// <seealso href="https://leetcode.com/problems/container-with-most-water/"/>
public sealed class ContainerWithMostWater
{
    public static int MaxArea(int[] height)
    {
        var result = 0;
        var i = 0;
        var j = height.Length - 1;

        while (i < j)
        {
            var curentResult = Math.Min(height[i], height[j]) * (j - i);
            result = Math.Max(result, curentResult);

            if (height[i] < height[j]) i++;
            else j--;
        }

        return result;
    }
}