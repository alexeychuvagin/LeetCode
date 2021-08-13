using System;
using Xunit;

namespace LeetCode.Problems.Tests
{
    /// <summary>
    /// Given an input string (s) and a pattern (p), implement regular expression matching with support for '.' and '*' where: 
    /// - '.' Matches any single character.​​​​
    /// - '*' Matches zero or more of the preceding element.
    /// The matching should cover the entire input string (not partial).
    /// </summary>
    /// <remarks>Hard</remarks>
    /// <seealso cref="https://leetcode.com/problems/regular-expression-matching/"/>
    public sealed class RegularExpressionMatching
    {
        [Theory]
        [InlineData("aa", "a", false)]
        [InlineData("aa", "aa", true)]
        [InlineData("aa", "aaa", false)]
        [InlineData("aa", "a*", true)]
        [InlineData("ab", ".*", true)]
        [InlineData("aab", "c*a*b", true)]
        [InlineData("mississippi", "mis*is*p*.", false)]
        [InlineData("aaa", "a*a.", true)]
        public void Test(string input, string pattern, bool output)
            => Assert.Equal(output, IsMatch(input, pattern));

        public bool IsMatch(string s, string p)
        {
            if (string.IsNullOrEmpty(p))
                return string.IsNullOrEmpty(s);

            var result = !string.IsNullOrEmpty(s) && (p[0].Equals('.') || p[0].Equals(s[0]));

            if (p.Length >= 2 && p[1] == '*')
            {
                return (IsMatch(s, p[2..])) || (result && IsMatch(s[1..], p));
            }
            else return result && IsMatch(s[1..], p[1..]);
        }
    }
}