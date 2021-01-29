using Xunit;

namespace LeetCode.Problems
{
    /// <summary>
    /// Implement atoi which converts a string to an integer.
    /// The function first discards as many whitespace characters as necessary until the first non-whitespace character is found.
    /// Then, starting from this character takes an optional initial plus or minus sign followed by as many numerical digits as possible, and interprets them as a numerical value.
    /// The string can contain additional characters after those that form the integral number, which are ignored and have no effect on the behavior of this function.
    /// If the first sequence of non-whitespace characters in str is not a valid integral number, or if no such sequence exists because either str is empty or it contains only whitespace characters, no conversion is performed.
    /// If no valid conversion could be performed, a zero value is returned.
    /// </summary>
    /// <remarks></remarks>
    /// <remarks>Medium</remarks>
    /// <seealso cref="https://leetcode.com/problems/string-to-integer-atoi/"/>
    public sealed class StringToInteger
    {
        [Theory]
        [InlineData("   -42", -42)]
        [InlineData("-42   ", -42)]
        [InlineData("4193 with words", 4193)]
        [InlineData("words and 987", 0)]
        [InlineData("-91283472332", -2147483648)]
        [InlineData("-2147483648", -2147483648)]
        public void Test(string input, int output)
        {
            Assert.Equal(output, MyAtoi(input));
        }
        
        private int MyAtoi(string s)
        {
            var result = 0;

            if (string.IsNullOrEmpty(s)) 
                return result;
            
            short sign = 1;
            var curPos = 0;

            while (char.IsWhiteSpace(s[curPos]))
            {
                curPos++;

                if (curPos >= s.Length) 
                    return result;
            }

            switch (s[curPos])
            {
                case '-':
                    sign = -1;
                    curPos++;
                    break;
                case '+':
                    curPos++;
                    break;
            }

            while (curPos < s.Length && char.IsDigit(s[curPos]))
            {
                var pop = s[curPos] - '0';

                if (result > int.MaxValue / 10 || (result == int.MaxValue / 10 && pop > int.MaxValue % 10))
                    return sign == 1 ? int.MaxValue : int.MinValue;

                result = result * 10 + pop;
                curPos++;
            }

            return result * sign;
        }
    }
}