using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Problems.Medium;

/// <summary>
/// 17. Letter Combinations of a Phone Number
/// Given a string containing digits from 2-9 inclusive, return all possible letter combinations that the number could represent.
/// Return the answer in any order.
/// A mapping of digit to letters (just like on the telephone buttons) is given below.Note that 1 does not map to any letters.
///  1    2    3
///      abc  def
///  4    5    6
/// ghi  jkl  mno
///  7    8    9
/// pqrs tuv wxyx
/// </summary>
/// <remarks>Medium</remarks>
/// <seealso cref="https://leetcode.com/problems/letter-combinations-of-a-phone-number/"/>
public static class LettersCombinationOfAPhoneNumber
{
    private static readonly IReadOnlyDictionary<char, string> Map 
        = new Dictionary<char, string>() 
        {
            { '2', "abc" },
            { '3', "def" },
            { '4', "ghi" },
            { '5', "jkl" },
            { '6', "mno" },
            { '7', "pqrs" },
            { '8', "tuv" },
            { '9', "wxyz" }
        };

    public static IList<string> LetterCombinations(string digits)
    {
        Set? prev = null;

        for (var i = digits.Length - 1; i >= 0; i--)
        {
            var cur = new Set(digits[i], prev);
            prev = cur;
        }

        return prev is null
            ? new List<string>()
            : prev.Result.ToList();
    }

    private class Set
    {
        public IList<string> Result { get; }

        public Set(char n, Set? prev)
        {
            if (prev is null)
            {
                Result = new List<string>(Map[n].Length);

                foreach (var c in Map[n])
                    Result.Add(c.ToString());
            }
            else
            {
                Result = new List<string>(Map[n].Length * prev.Result.Count);

                foreach (var c in Map[n])
                {
                    foreach (var res in prev.Result)
                    {
                        Result.Add(c + res);
                    }
                }
            }
        }
    }
}