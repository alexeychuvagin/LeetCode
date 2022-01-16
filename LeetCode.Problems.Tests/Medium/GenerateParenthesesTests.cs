using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using LeetCode.Problems.Medium;
using Xunit;

namespace LeetCode.Problems.Tests.Medium;

public class GenerateParenthesesTests 
{
    public static IEnumerable<object[]> TestCases()
    {
        yield return new object[]
        {
            3,
            new List<string>() { "((()))", "(()())", "(())()", "()(())", "()()()" }
        };
        yield return new object[]
        {
            4,
            new List<string>() { "(((())))", "((()()))", "((())())", "((()))()", "(()(()))", "(()()())", "(()())()", "(())(())", "(())()()", "()((()))", "()(()())", "()(())()", "()()(())", "()()()()" }
        };
    }

    [Theory]
    [MemberData(nameof(TestCases))]
    public void GenerateParentheses_BruteForce_Approach_Test(int n, List<string> expectedResult)
    {
        // Act
        var actualResult = GenerateParentheses.BruteForce.Solution(n);

        // Assert
        actualResult.Should().HaveCount(expectedResult.Count);

        foreach (var item in expectedResult)
        {
            actualResult.Should().Contain(item);
        } 
    }

    [Theory]
    [MemberData(nameof(TestCases))]
    public void GenerateParentheses_Backtracking_Approach_Test(int n, List<string> expectedResult)
    {
        // Act
        var actualResult = GenerateParentheses.Backtracking.Solution(n);

        // Assert
        actualResult.Should().HaveCount(expectedResult.Count);

        foreach (var item in expectedResult)
        {
            actualResult.Should().Contain(item);
        }
    }

    [Theory]
    [MemberData(nameof(TestCases))]
    public void GenerateParentheses_ClosureNumber_Approach_Test(int n, List<string> expectedResult)
    {
        // Act
        var actualResult = GenerateParentheses.ClosureNumber.Solution(n);

        // Assert
        actualResult.Should().HaveCount(expectedResult.Count);

        foreach (var item in expectedResult)
        {
            actualResult.Should().Contain(item);
        }
    }
}