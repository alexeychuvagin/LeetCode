using System;
using Xunit;

namespace LeetCode.Problems
{
    /// <summary>
    /// Given a string s, find the longest palindromic substring in s. 
    /// You may assume that the maximum length of s is 1000.
    /// <remarks>Medium</remarks>
    /// <seealso cref="https://leetcode.com/problems/longest-palindromic-substring/"/>
    public sealed class LongestPalindromicSubstring
    {
        [Theory]
        [InlineData("babad", "bab")]
        [InlineData("cbbd", "bb")]
        [InlineData("a", "a")]
        [InlineData("aaaa", "aaaa")]
        public void Test(string input, string output)
        {
            Assert.Equal(output, Solution(input));
        }

        public string Solution(string s)
        {
            var result = string.Empty;
            var pos = 0;

            while (pos < s.Length)
            {
                int m_left = pos;
                int s_left = pos - 1;
                int left = pos;
                int right = pos + 1;

                var mirror = true;
                var symmetric = true;

                while (right < s.Length)
                {
                    var isEqual = false;

                    if (mirror)
                    {
                        if (m_left >= 0 && s[m_left].Equals(s[right]))
                        {
                            isEqual = true;
                            left = m_left;
                            m_left--;
                        }
                        else mirror = false;
                    }

                    if (symmetric)
                    {
                        if (s_left >= 0 && s[s_left].Equals(s[right]))
                        {
                            isEqual = true;
                            left = s_left;
                            s_left--;
                        }
                        else symmetric = false;
                    }

                    if (isEqual) right++;
                    else break;
                }

                if (right - left > result.Length)
                    result = s[left..right];

                pos++;
            }

            return result;
        }
    }
}