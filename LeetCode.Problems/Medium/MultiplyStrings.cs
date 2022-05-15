using System.Text;

namespace LeetCode.Problems.Medium;

/// <summary>
/// 43. Given two non-negative integers num1 and num2 represented as strings, 
/// return the product of num1 and num2, also represented as a string.
/// Note: You must not use any built-in BigInteger library or convert 
/// the inputs to integer directly.
/// </summary>
/// <remarks>Medium</remarks>
/// <seealso cref="https://leetcode.com/problems/multiply-strings/"/>
public static class MultiplyStrings
{
    /// <summary>
    /// Complexity O(n*m)
    /// </summary>
    public static string Multiply(string num1, string num2)
    {
        if (num1.Equals("0") || num2.Equals("0"))
        {
            return "0";
        }

        var arr = new int[num1.Length + num2.Length];

        for (var pointer1 = num1.Length - 1; pointer1 >= 0; pointer1--)
        {
            var value1 = (int)char.GetNumericValue(num1[pointer1]);

            for (var pointer2 = num2.Length - 1; pointer2 >= 0; pointer2--)
            {
                var position = pointer1 + pointer2 + 1;
                var value2 = (int)char.GetNumericValue(num2[pointer2]);
                var currentResult = value1 * value2 + arr[position];
                arr[position] = currentResult % 10;
                arr[position - 1] += currentResult / 10;
            }
        }

        var result = new StringBuilder(arr.Length);
        var start = arr[0] != 0 ? 0 : 1;

        for (var i = start; i < arr.Length; i++)
        {
            result.Append(arr[i]);
        }

        return result.ToString();
    }
}
