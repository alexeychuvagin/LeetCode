﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Problems.Medium;

/// <summary>
/// Given n pairs of parentheses, write a function to generate all combinations of well-formed parentheses.
/// </summary>
/// <remarks>Medium</remarks>
/// <seealso cref="https://leetcode.com/problems/generate-parentheses/"/>
public static class GenerateParentheses
{
    /// <summary>
    /// Time complexity: 2^2n * n (we need to validate every sequence)
    /// Space complexity: 2^2n
    /// </summary>
    public static class BruteForce
    {
        public static IList<string> Solution(int n)
        {
            var result = new List<string>();
            GenerateAll(Array.Empty<char>(), 0, n * 2, result);

            return result;
        }

        private static void GenerateAll(IList<char> current, int pos, int lenght, IList<string> result)
        {
            if (pos == lenght)
            {
                if (IsValid(current))
                {
                    result.Add(new string(current.ToArray()));
                }
            }
            else
            {
                var first = new List<char>(current);
                first.Add('(');
                
                GenerateAll(first, pos + 1, lenght, result);

                var second = new List<char>(current);
                second.Add(')');

                GenerateAll(second, pos + 1, lenght, result);
            }
        }

        private static bool IsValid(IList<char> current)
        {
            int balance = 0;

            foreach (char c in current)
            {
                if (c == '(')
                {
                    balance++;
                }
                else
                {
                    balance--;
                }

                if (balance < 0)
                {
                    return false;
                }
            }

            return balance == 0;
        }
    }

    public static class Backtracking
    {
        public static IList<string> Solution(int n)
        {
            var result = new List<string>();
            Backtrack(result, String.Empty, 0, 0, n);

            return result;
        }

        private static void Backtrack(IList<string> result, string current, int opened, int closed, int max)
        {
            if (opened == closed && opened == max)
            {
                result.Add(current);
                return;
            }

            if (opened < max)
            {
                Backtrack(result, result + "(", opened + 1, closed, max);
            }

            if (closed < opened)
            {
                Backtrack(result, result + ")", opened, closed + 1, max);
            }
        }
    }

    public static class ClosureNumber
    {
        public static IList<string> Solution(int n)
        {
            var result = new List<string>();

            if (n == 0)
            {
                result.Add("");
            }
            else
            {
                for (int c = 0; c < n; c++)
                {
                    foreach (var left in Solution(c))
                    {
                        foreach (var right in Solution(n - 1 - c))
                        {
                            result.Add("(" + left + ")" + right);
                        }
                    } 
                }
            }

            return result;
        }
    }
}

