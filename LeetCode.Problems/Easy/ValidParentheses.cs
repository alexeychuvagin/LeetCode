using System.Collections.Generic;

namespace LeetCode.Problems.Easy;

/// <summary>
/// 20. Valid Parentheses
/// Given a string s containing just the characters '(', ')', '{', '}', '[' and ']', determine if the input string is valid.
/// An input string is valid if:
/// - Open brackets must be closed by the same type of brackets.
/// - Open brackets must be closed in the correct order.
/// </summary>
/// <remarks>Easy</remarks>
/// <seealso cref="https://leetcode.com/problems/valid-parentheses/"/>
public static class ValidParentheses
{
    /// <summary>
    /// Approach 1
    /// Complexity O(n)
    /// </summary>
    public static bool IsValid(string s)
    {
        var dict = new Dictionary<char, char>
        {
            { '(', ')' },
            { '{', '}' },
            { '[', ']' }
        };

        var stack = new Stack<char>();

        foreach (var c in s)
        {
            if (dict.ContainsKey(c))
            {
                stack.Push(c);
            }
            else if (!stack.TryPop(out var prev) || !dict[prev].Equals(c))
            {
                return false;
            }
        }

        return stack.Count == 0;
    }
}
