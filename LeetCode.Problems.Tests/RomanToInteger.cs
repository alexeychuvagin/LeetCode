using System.Collections.Generic;
using Xunit;

namespace LeetCode.Problems.Tests
{
    /// <summary>
    /// Roman numerals are represented by seven different symbols: I, V, X, L, C, D and M.
    /// For example, 2 is written as II in Roman numeral, just two one's added together. 12 is written as XII, which is simply X + II.
    /// The number 27 is written as XXVII, which is XX + V + II.
    /// Roman numerals are usually written largest to smallest from left to right. However, the numeral for four is not IIII.
    /// Instead, the number four is written as IV.
    /// Because the one is before the five we subtract it making four.
    /// The same principle applies to the number nine, which is written as IX. There are six instances where subtraction is used:
    /// - I can be placed before V (5) and X (10) to make 4 and 9. 
    /// - X can be placed before L(50) and C(100) to make 40 and 90. 
    /// - C can be placed before D(500) and M(1000) to make 400 and 900.
    /// Given a roman numeral, convert it to an integer.
    /// </summary>
    /// <remarks>Easy</remarks>
    /// <seealso cref="https://leetcode.com/problems/roman-to-integer/"/>
    public sealed class RomanToInteger
    {
        [Theory]
        [InlineData("III", 3)]
        [InlineData("IV", 4)]
        [InlineData("IX", 9)]
        [InlineData("LVIII", 58)]
        [InlineData("MCMXCIV", 1994)]
        public void Test(string input, int result)
            => Assert.Equal(result, RomanToInt(input));

        private int RomanToInt(string input)
        {
            var map = new Dictionary<char, int>()
            {
                { 'I', 1 },
                { 'V', 5 },
                { 'X', 10 },
                { 'L', 50 },
                { 'C', 100 },
                { 'D', 500 },
                { 'M', 1000 }
            };

            var result = 0;
            var index = 0;

            while (index < input.Length)
            {
                var current = map[input[index]];
                index++;

                if (index < input.Length)
                {
                    var next = map[input[index]];

                    if (current < next)
                    {
                        index++;
                        result += next - current;
                        continue;
                    }
                }
                
                result += current;
            }
            
            return result;
        }
    }
}