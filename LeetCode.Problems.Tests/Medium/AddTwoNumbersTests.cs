using System.Collections.Generic;
using Xunit;
using static LeetCode.Problems.Medium.AddTwoNumbers;

namespace LeetCode.Problems.Tests.Medium
{
    public sealed class AddTwoNumbers
    {
        public static IEnumerable<object[]> TestCases()
        {
            // Test case 1: (2 -> 4 -> 3) + (5 -> 6 -> 4) = 7 -> 0 -> 8
            yield return new object[]
            {
                new ListNode(2, new ListNode(4, new ListNode(3))),
                new ListNode(5, new ListNode(6, new ListNode(4))),
                "708"
            };
        }

        [Theory]
        [MemberData(nameof(TestCases))]
        public void Test(ListNode node1, ListNode node2, string result)
        {
            var resultNode = Solution(node1, node2);
            Assert.Equal(result, resultNode.ToString());
        }
    }
}