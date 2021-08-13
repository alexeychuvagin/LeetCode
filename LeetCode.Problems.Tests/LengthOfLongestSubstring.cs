using System;
using System.Collections.Generic;
using Xunit;

namespace LeetCode.Problems.Tests
{
    /// <summary>
    /// Given a string, find the length of the longest substring without repeating characters.
    /// </summary>
    /// <remarks>Medium</remarks>
    /// <seealso cref="https://leetcode.com/problems/longest-substring-without-repeating-characters/"/>
    public sealed class LengthOfLongestSubstring
    {
        [Theory]
        // Explanation: The answer is "abc", with the length of 3.
        [InlineData("abcabcbb", 3)]
        // Explanation: The answer is "b", with the length of 1.
        [InlineData("bbbbb", 1)]
        // Explanation: The answer is "wke", with the length of 3. 
        // Note that the answer must be a substring, "pwke" is a subsequence and not a substring.
        [InlineData("pwwkew", 3)]
        [InlineData("aab", 2)]
        [InlineData("dvdf", 3)]
        public void Test(string input, int output)
        {
            Assert.Equal(output, Solution(input));
            Assert.Equal(output, Solution2(input));
        }

        /// <summary>
        /// Complexity O(n)
        /// </summary>
        public int Solution(string s)
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
        public int Solution2(string s)
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
}