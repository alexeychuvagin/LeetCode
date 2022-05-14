using LeetCode.Problems.Medium;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace LeetCode.Problems.Tests.Medium;

public class PermutationsTests
{
    public static IEnumerable<object[]> TestCases()
    {
        yield return new object[]
        {
            new[] { 1, 2, 3 },
            new[]
            {
                new[] { 1, 2, 3 },
                new[] { 1, 3, 2 },
                new[] { 2, 1, 3 },
                new[] { 2, 3, 1 },
                new[] { 3, 1, 2 },
                new[] { 3, 2, 1 }
            }
        };
        yield return new object[]
        {
            new[] { 0, 1 },
            new[]
            {
                new[] { 0, 1 },
                new[] { 1, 0 }
            }
        };
        yield return new object[]
        {
            new[] { 1 },
            new[]
            {
                new[] { 1 },
            }
        };
    }

    [Theory]
    [MemberData(nameof(TestCases))]
    public void PermuteTest(int[] input, int[][] output)
    {
        var hashTable = output
            .Select(x => string.Join(string.Empty, x))
            .ToHashSet();

        var result = new Permutations().Permute(input);

        Assert.Equal(output.Length, result.Count);
        foreach (var res in result)
        {
            var hash = string.Join(string.Empty, res);
            Assert.Contains(hash, hashTable);
        }
    }
}