using System.Collections.Generic;

namespace LeetCode.Problems.Medium;

/// <summary>
/// 6. Zigzag Conversion
/// The string "PAYPALISHIRING" is written in a zigzag pattern on a given number of rows like this: 
/// (you may want to display this pattern in a fixed font for better legibility)
/// P   A   H   N
/// A P L S I I G
/// Y   I R
/// And then read line by line: "PAHNAPLSIIGYIR"
/// Write the code that will take a string and make this conversion given a number of rows.
/// </summary>
/// <remarks>
/// Constrains
/// 1 <= s.length <= 1000
/// s consists of English letters (lower-case and upper-case), ',' and '.'
/// 1 <= numRows <= 1000
/// </remarks>
/// <remarks>Medium</remarks>
/// <seealso cref="https://leetcode.com/problems/zigzag-conversion/"/>
public static class ZigZagConversion
{
    public static string Convert(string s, int numRows)
    {
        if (numRows == 1) return s;

        var rows = new List<StringBuilder>(numRows);

        for (var index = 0; index < numRows; index++)
            rows.Add(new StringBuilder());

        var isGoingDown = false;
        var curRow = 0;

        foreach (var c in s)
        {
            rows[curRow].Append(c);

            if (curRow == 0 || curRow == numRows - 1)
                isGoingDown = !isGoingDown;

            curRow += isGoingDown ? 1 : -1;
        }

        var result = new StringBuilder(s.Length);
        foreach (var row in rows)
            result.Append(row);

        return result.ToString();
    }
}