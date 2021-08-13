using System;
using Xunit;

namespace LeetCode.Problems.Tests
{
    /// <summary>
    /// Determine whether an integer is a palindrome.
    /// An integer is a palindrome when it reads the same backward as forward.
    /// Follow up: Could you solve it without converting the integer to a string?
    /// </summary>
    /// <remarks>Easy</remarks>
    /// <seealso cref="https://leetcode.com/problems/palindrome-number/"/>
    public sealed class PalindromeNumber
    {
        [Theory]
        [InlineData(121, true)]
        [InlineData(-121, false)]
        [InlineData(10, false)]
        [InlineData(-101, false)]
        [InlineData(9999, true)]
        public void Test(int input, bool result)
        {
            Assert.Equal(result, IsPalindrome(input));
            Assert.Equal(result, IsPalindrome2(input));
        }

        public bool IsPalindrome(int x)
        {
            if (x < 0) return false;

            var length = (int)Math.Log10(x) + 1;
            var template = (int)Math.Pow(10, length - 1);

            while (length > 1)
            {
                var v1 = x / template;
                var v2 = x % 10;

                if (v1 != v2) return false;

                x -= (v1 * template) + v2;
                x /= 10;

                template /= 100;
                length -= 2;
            }

            return true;
        }

        public bool IsPalindrome2(int x)
        {
            if (x < 0 || (x % 10 == 0 && x != 0))
            {
                return false;
            }

            var revertedNumber = 0;

            while (x > revertedNumber)
            {
                revertedNumber = revertedNumber * 10 + x % 10;
                x /= 10;
            }

            return x == revertedNumber || x == revertedNumber / 10;
        }
    }
}