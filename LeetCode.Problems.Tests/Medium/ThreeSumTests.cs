using LeetCode.Problems.Medium;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace LeetCode.Problems.Tests.Medium;

public sealed class ThreeSumTests
{
    public static IEnumerable<object[]> TestCases()
    {
        yield return new object[]
        {
                new[] {-1, 0, 1, 2, -1, -4},
                new[] {new[] {-1, -1, 2}, new[] {-1, 0, 1}}
        };
        yield return new object[]
        {
                new[] {0, 0, 0, 0},
                new[] {new[] {0, 0, 0}}
        };
    }

    [Theory]
    [MemberData(nameof(TestCases))]
    public void Two_Pointers_Approach_Test(int[] input, int[][] output)
    {
        var result = ThreeSum.Approach1(input)
            .Select(x => x.ToArray())
            .ToArray();

        Assert.Equal(output.Length, result.Length);

        output = output.Select(x =>
        {
            Array.Sort(x);
            return x;
        }).ToArray();

        result = result.Select(x =>
        {
            Array.Sort(x);
            return x;
        }).ToArray();

        for (var i = 0; i < output.Length; i++)
        {
            Assert.Equal(output[i].Length, result[i].Length);

            for (var j = 0; j < output[i].Length; j++)
            {
                Assert.Equal(output[i][j], result[i][j]);
            }
        }
    }
}