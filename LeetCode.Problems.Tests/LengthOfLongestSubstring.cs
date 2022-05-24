using Xunit;
using static LeetCode.Problems.Medium.LengthOfLongestSubstring;

namespace LeetCode.Problems.Tests
{
    public sealed class LengthOfLongestSubstringTests
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
    }
}