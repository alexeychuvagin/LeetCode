using System.Collections.Generic;
using Xunit;
using static LeetCode.Problems.Easy.LongestCommonPrefix;

namespace LeetCode.Problems.Tests.Easy;

public sealed class LongestCommonPrefixTests
{
    public static IEnumerable<object[]> TestCases =>
        new List<object[]>()
        {
            new object[] { new[] {"flower", "flow", "flight"}, "fl" },
            new object[] { new[] {"dog", "racecar", "car"}, "" }
        };

    [Theory]
    [MemberData(nameof(TestCases))]
    public void HorizontalScanningTest(string[] input, string output)
        => Assert.Equal(output, HorizontalScanning(input));

    [Theory]
    [MemberData(nameof(TestCases))]
    public void VerticalScanningTest(string[] input, string output)
        => Assert.Equal(output, VerticalScanning(input));

    [Theory]
    [MemberData(nameof(TestCases))]
    public void BinarySearchTest(string[] input, string output)
        => Assert.Equal(output, BinarySearch(input));
}