namespace LeetCode.Problems.Medium;

/// <summary>
/// 5. Longest Palindromic Substring
/// Given a string s, find the longest palindromic substring in s. 
/// You may assume that the maximum length of s is 1000.
/// <remarks>Medium</remarks>
/// <seealso cref="https://leetcode.com/problems/longest-palindromic-substring/"/>
public static class LongestPalindromicSubstring
{
    public static string Solution(string s)
    {
        var result = string.Empty;

        for (var pos = 0; pos < s.Length; pos++)
        {
            int even_left = pos;
            int odd_left = pos - 1;
            int left = pos;
            int right = pos + 1;

            while (right < s.Length)
            {
                var isEqual = false;

                if (even_left >= 0 && s[even_left].Equals(s[right]))
                {
                    isEqual = true;
                    left = even_left;
                    even_left--;
                }
                else even_left = -1;

                if (odd_left >= 0 && s[odd_left].Equals(s[right]))
                {
                    isEqual = true;
                    left = odd_left;
                    odd_left--;
                }
                else odd_left = -1;

                if (!isEqual) break;

                right++;
            }

            if (right - left > result.Length)
                result = s[left..right];
        }

        return result;
    }
}