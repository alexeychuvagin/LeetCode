﻿using Xunit;

namespace LeetCode.Problems
{
    /// <summary>
    /// Given a 32-bit signed integer, reverse digits of an integer.
    /// Assume we are dealing with an environment that could only store integers within the 32-bit signed integer range: 
    /// [−231,  231 − 1]. For the purpose of this problem, assume that your function returns 0 when the reversed integer overflows.
    /// </summary>
    /// <remarks>Easy</remarks>
    /// <seealso cref="https://leetcode.com/problems/reverse-integer/"/>
    public sealed class ReverseInteger
    {
        [Theory]
        [InlineData(123, 321)]
        [InlineData(-123, -321)]
        [InlineData(120, 21)]
        [InlineData(0, 0)]
        [InlineData(1534236469, 0)]
        public void Test(int input, int output)
        {
            Assert.Equal(output, Reverse(input));
        }

        private int Reverse(int x)
        {
            var result = 0;

            while (x != 0)
            {
                var pop = x % 10;
                x /= 10;

                if (result > int.MaxValue / 10 || (result == int.MaxValue / 10 && pop > 7)) return 0;
                if (result < int.MinValue / 10 || (result == int.MinValue / 10 && pop < -8)) return 0;

                result = result * 10 + pop;
            }

            return result;
        }
    }
}