namespace LeetCode.Problems.Medium;

/// <summary>
/// 96. Given an integer n, return the number of structurally unique BST's (binary search trees) 
/// which has exactly n nodes of unique values from 1 to n.
/// </summary>
/// <remarks>Medium</remarks>
/// <seealso cref="https://leetcode.com/problems/unique-binary-search-trees/"/>
/// <seealso cref="https://www.baeldung.com/cs/get-number-of-binary-search-trees-n-distinct-elements" />
public static class UniqueBinarySearchTrees
{
    public static int RecursiveApproach(int n)
    {
        if (n == 0)
        {
            return 1;
        }

        var result = 0;

        for (int i = 1; i <= n; i++)
        {
            result += RecursiveApproach(i - 1) * RecursiveApproach(n - i);
        }

        return result;
    }

    /// <summary>
    /// Complexity 0(n^2)
    /// </summary>
    public static int DynamicProgrammingApproach(int n)
    {
        var arr = new int[n + 1];
        arr[0] = 1;

        for (var i = 1; i <= n; i++)
        {
            arr[i] = 0;

            for (var j = 1; j <= i; j++)
            {
                arr[i] += arr[j - 1] * arr[i - j];
            }
        }

        return arr[n];
    }
}
