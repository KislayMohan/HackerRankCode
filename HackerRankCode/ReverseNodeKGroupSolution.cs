using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankCode
{
    internal class ReverseNodeKGroupSolution
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
        public ListNode ReverseKGroup(ListNode head, int k)
        {
            if (head == null || k <= 1)
                return head;
            ListNode dummy = new ListNode(0);
            dummy.next = head;
            ListNode prevGroupEnd = dummy;
            while (true)
            {
                ListNode kthNode = GetKthNode(prevGroupEnd, k);
                if (kthNode == null)
                    break;
                ListNode groupStart = prevGroupEnd.next;
                ListNode nextGroupStart = kthNode.next;
                // Reverse the group
                ListNode prev = nextGroupStart;
                ListNode current = groupStart;
                while (current != nextGroupStart)
                {
                    ListNode temp = current.next;
                    current.next = prev;
                    prev = current;
                    current = temp;
                }
                // Connect with the previous part
                prevGroupEnd.next = kthNode;
                prevGroupEnd = groupStart; // Move to the end of the reversed group
            }
            return dummy.next;
        }

        private ListNode GetKthNode(ListNode prevGroupEnd, int k)
        {
            ListNode current = prevGroupEnd;
            for (int i = 0; i < k; i++)
            {
                if (current.next == null)
                    return null;
                current = current.next;
            }
            return current;
        }
    }
}
