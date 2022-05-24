using System;
using System.Collections.Generic;

namespace LeetCode.Problems.Medium;

/// <summary>
/// 3. Longest Substring Without Repeating Characters
/// Given a string, find the length of the longest substring without repeating characters.
/// </summary>
/// <remarks>Medium</remarks>
/// <seealso cref="https://leetcode.com/problems/longest-substring-without-repeating-characters/"/>
public static class LengthOfLongestSubstring
{
    /// <summary>
    /// Complexity O(n)
    /// </summary>
    public static int Solution(string s)
    {
        var dict = new Dictionary<char, int>();
        var result = 0;
        var startPos = 0;

        for (var pos = 0; pos < s.Length; pos++)
        {
            var key = s[pos];

            if (dict.TryGetValue(key, out var value) && value >= startPos)
            {
                result = Math.Max(result, pos - startPos);
                startPos = dict[key] + 1;
            }

            dict[key] = pos;
        }

        return Math.Max(result, s.Length - startPos);
    }

    /// <summary>
    /// Complexity O(n^2)
    /// </summary>
    public static int Solution2(string s)
    {
        var result = 0;
        var set = new HashSet<char>();
        var pos = 0;

        while (pos < s.Length)
        {
            for (var i = pos; i < s.Length; i++)
            {
                if (set.Add(s[i]))
                    continue;

                result = Math.Max(result, set.Count);

                set.Clear();
                break;
            }

            pos++;

            if (result > s.Length - pos)
                break;
        }

        return Math.Max(result, set.Count);
    }
}
