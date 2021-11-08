using LeetCode.Problems.Medium;
using Xunit;

namespace LeetCode.Problems.Tests.Medium;

public sealed class UniqueBinarySearchTreesTests
{
    [Theory]
    [InlineData(3, 5)]
    public void RecursiveApproach_Test(int input, int output)
        => Assert.Equal(output, UniqueBinarySearchTrees.RecursiveApproach(input));

    [Theory]
    [InlineData(3, 5)]
    public void DynamicProgrammingApproach_Test(int input, int output)
        => Assert.Equal(output, UniqueBinarySearchTrees.DynamicProgrammingApproach(input));
}
