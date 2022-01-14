using System.Collections.Generic;
using LeetCode.Problems.Medium;
using Xunit;
using static LeetCode.Problems.Medium.RemoveNthNodeFromEndOfList;

namespace LeetCode.Problems.Tests.Medium;

public class RemoveNthNodeFromEndOfListTests
{
    public static IEnumerable<object[]> TestCases()
    {
        yield return new object[]
        {
            new ListNode
            {
                val = 1,
                next = new ListNode
                {
                    val = 2,
                    next = new ListNode
                    {
                        val = 3,
                        next = new ListNode
                        {
                            val = 4,
                            next = new ListNode
                            {
                                val = 5,
                                next = null
                            }
                        }
                    }
                }
            },
            2,
            new ListNode
            {
                val = 1,
                next = new ListNode
                {
                    val = 2,
                    next = new ListNode
                    {
                        val = 3,
                        next = new ListNode
                        {
                            val = 5,
                            next = null
                        }
                    }
                }
            },
        };
    }

    [Theory]
    [MemberData(nameof(TestCases))]
    public void RemoveNthNodeFromEndOfList_Solution1_Test(ListNode head, int n, ListNode expectedResult)
    {
        // Act
        var result = RemoveNthNodeFromEndOfList.Solution1(head, n);

        // Assert
        var actualNode = result;
        var expectedNode = expectedResult;

        while (expectedNode.next is not null)
        {
            Assert.Equal(expectedNode.val, actualNode.val);
            Assert.Equal(expectedNode.next is null, actualNode.next is null);

            actualNode = actualNode.next; 
            expectedNode = expectedNode.next;
        }
    }

    [Theory]
    [MemberData(nameof(TestCases))]
    public void RemoveNthNodeFromEndOfList_Solution2_Test(ListNode head, int n, ListNode expectedResult)
    {
        // Act
        var result = RemoveNthNodeFromEndOfList.Solution2(head, n);

        // Assert
        var actualNode = result;
        var expectedNode = expectedResult;

        while (expectedNode.next is not null)
        {
            Assert.Equal(expectedNode.val, actualNode.val);
            Assert.Equal(expectedNode.next is null, actualNode.next is null);

            actualNode = actualNode.next;
            expectedNode = expectedNode.next;
        }
    }
}