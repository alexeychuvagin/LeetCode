using System;
using System.Collections.Generic;

namespace LeetCode.Problems.Easy;

/// <summary>
/// 290. Word Pattern
/// Given a pattern and a string s, find if s follows the same pattern.
/// Here follow means a full match, such that there is a bijection between a letter in pattern and a non-empty word in s.
/// </summary>
/// <remarks>Easy</remarks>
/// <seealso cref="https://leetcode.com/problems/word-pattern/"/>
public static class WordPattern
{
    /// <summary>
    /// Time complexity: O(n)
    /// Space complexity: O(n)
    /// </summary>
    public static bool Solution(string pattern, string s)
    {
        Dictionary<char, string> map = new();
        HashSet<string> wordsInUse = new();

        string[] words = s.Split(' ');

        if (pattern.Length != words.Length)
        {
            return false;
        }

        int index = 0;

        while (index < pattern.Length)
        {
            char symbol = pattern[index];
            string word = words[index];

            if (!map.ContainsKey(symbol) && wordsInUse.Contains(word))
            {
                return false;
            }
            else if (map.ContainsKey(symbol) && !map[symbol].Equals(word, StringComparison.InvariantCultureIgnoreCase))
            {
                return false;
            }

            map[symbol] = word;
            wordsInUse.Add(word);

            index++;
        }

        return true;
    }
}