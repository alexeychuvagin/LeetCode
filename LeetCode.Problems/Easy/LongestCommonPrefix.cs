using System;
using System.Linq;

namespace LeetCode.Problems.Easy;

/// <summary>
/// 14. Write a function to find the longest common prefix string amongst an array of strings.
/// If there is no common prefix, return an empty string "".
/// </summary>
/// <remarks>Easy</remarks>
/// <seealso cref="https://leetcode.com/problems/longest-common-prefix/"/>
public static class LongestCommonPrefix
{
    /// <summary>
    /// Complexity O(S) where S is the sum of letters in all strings.
    /// Space complexity: O(1). Because we use constant extra space.
    /// </summary>
    public static string HorizontalScanning(string[] strs)
    {
        if (strs is null || strs.Length == 0)
            return string.Empty;

        if (strs.Length == 1)
            return strs[0];

        var prefix = strs[0];

        for (var i = 1; i < strs.Length; i++)
        {
            while (strs[i].IndexOf(prefix, StringComparison.InvariantCultureIgnoreCase) != 0)
            {
                prefix = prefix.Substring(0, prefix.Length - 1);
                if (prefix.Equals(string.Empty))
                    return string.Empty;
            }
        }

        return prefix;
    }

    public static string VerticalScanning(string[] strs)
    {
        if (strs is null || strs.Length == 0)
            return string.Empty;

        for (var i = 0; i < strs[0].Length; i++)
        {
            var c = strs[0][i];

            for (var j = 1; j < strs.Length; j++)
            {
                if (i == strs[j].Length || strs[j][i] != c)
                    return strs[0].Substring(0, i);
            }
        }

        return strs[0];
    }

    public static string BinarySearch(string[] strs)
    {
        if (strs is null || strs.Length == 0)
            return string.Empty;

        var low = 1;
        var high = strs.Min(s => s.Length);

        while (low <= high)
        {
            var middle = (low + high) / 2;
            var prefix = strs[0].Substring(0, middle);

            if (strs.All(s => s.StartsWith(prefix)))
                low = middle + 1;
            else high = middle - 1;
        }

        return strs[0].Substring(0, (low + high) / 2);
    }
}
