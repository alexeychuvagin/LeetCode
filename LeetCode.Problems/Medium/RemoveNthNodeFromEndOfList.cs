namespace LeetCode.Problems.Medium;

/// <summary>
/// 19. Given the head of a linked list, remove the nth node from the end of the list and return its head.
/// </summary>
/// <remarks>Medium</remarks>
/// <seealso cref="https://leetcode.com/problems/remove-nth-node-from-end-of-list/"/>
public static class RemoveNthNodeFromEndOfList
{
    public class ListNode
    {
        public int val;
        public ListNode next;

        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }

    /// <summary>
    /// Time complexity: O(2n)
    /// Space complexity: O(1)
    /// </summary>
    public static ListNode Solution1(ListNode head, int n)
    {
        var dummyHead = new ListNode(0, head);

        // Define the list lenght
        var lenght = 0;
        var curNode = head;

        while (curNode is not null)
        {
            lenght++;
            curNode = curNode.next;
        }

        // Remove Nth node from end
        lenght -= n;
        curNode = dummyHead;

        while (lenght > 0)
        {
            lenght--;
            curNode = curNode.next;
        }

        curNode.next = curNode.next.next;

        return dummyHead.next;
    }

    /// <summary>
    /// Time complexity: O(n)
    /// Space complexity: O(1)
    /// </summary>
    public static ListNode Solution2(ListNode head, int n)
    {
        ListNode fast = head, slow = head;

        for (int i = 0; i < n; i++)
        {
            fast = fast.next;
        }

        if (fast is null)
        {
            return head.next;
        }

        while (fast.next is not null)
        {
            fast = fast.next;
            slow = slow.next;
        }

        slow.next = slow.next.next;

        return head;
    }
}