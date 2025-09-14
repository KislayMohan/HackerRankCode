using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankCode
{
    internal class SwapNodesInPairsSolution
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
        public ListNode SwapPairs(ListNode head)
        {
            if (head == null || head.next == null)
                return head;
            ListNode dummy = new ListNode(0);
            dummy.next = head;
            ListNode prev = dummy;
            while (prev.next != null && prev.next.next != null)
            {
                ListNode first = prev.next;
                ListNode second = prev.next.next;
                // Swapping
                first.next = second.next;
                second.next = first;
                prev.next = second;
                // Move prev to the next pair
                prev = first;
            }
            return dummy.next;
        }
    }
}
