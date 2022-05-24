using System.Text;

namespace LeetCode.Problems.Medium;

/// <summary>
/// 2. Add Two Numbers
/// You are given two non-empty linked lists representing two non-negative integers. 
/// The digits are stored in reverse order and each of their nodes contain a single digit. 
/// Add the two numbers and return it as a linked list.
/// You may assume the two numbers do not contain any leading zero, except the number 0 itself.
/// </summary>
/// <remarks>Medium</remarks>
/// <seealso cref="https://leetcode.com/problems/add-two-numbers/"/>
public static class AddTwoNumbers
{
    public class ListNode
    {
        public int val;
        public ListNode? next;
        public ListNode(int val = 0, ListNode? next = null)
        {
            this.val = val;
            this.next = next;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append(val);

            if (next is not null)
            {
                sb.Append(next.ToString());
            }

            return sb.ToString();
        }
    }

    public static ListNode Solution(ListNode l1, ListNode l2)
    {
        var head = new ListNode();
        var currentNode = head;
        var node1 = l1;
        var node2 = l2;
        var remainder = 0;

        while (node1 is { } || node2 is { })
        {
            var result = remainder;

            if (node1 is { })
            {
                result += node1.val;
                node1 = node1.next;
            }

            if (node2 is { })
            {
                result += node2.val;
                node2 = node2.next;
            }

            remainder = result / 10;
            currentNode.next = new ListNode(result % 10);
            currentNode = currentNode.next;
        }

        if (remainder != 0)
            currentNode.next = new ListNode(remainder);

        return head.next;
    }
}