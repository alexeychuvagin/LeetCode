using LeetCode.Problems.Easy;
using FluentAssertions;
using Xunit;

namespace LeetCode.Problems.Tests.Easy;

public class WordPatternTests
{
    [Theory]
    [InlineData("abba", "dog cat cat dog", true)]
    [InlineData("abba", "dog cat cat fish", false)]
    [InlineData("aaaa", "dog cat cat dog", false)]
    [InlineData("abba", "dog dog dog dog", false)]
    [InlineData("jquery", "jquery", false)]
    public void WordPattern_Problem_Test(string pattern, string s, bool expectedResult)
    {
        WordPattern.Solution(pattern, s)
            .Should()
            .Be(expectedResult);
    }
}