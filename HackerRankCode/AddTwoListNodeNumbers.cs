using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankCode
{
    internal class AddTwoListNodeNumbers
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

        public static void AddTwoListNodeNumbersSol()
        {
            var l1 = new ListNode(2, null);
            l1.next = new ListNode(4, null);
            l1.next.next = new ListNode(3, null);

            var l2 = new ListNode(5, null);
            l2.next = new ListNode(6, null);
            l2.next.next = new ListNode(4, null);
            var result = AddTwoNumbers(l1, l2);
        }

        public static ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            var carryOn = 0;
            ListNode result = null;
            ListNode temp = null;
            while (l1 != null || l2 != null)
            {
                int l1Val = l1 != null ? l1.val : 0;
                int l2Val = l2 != null ? l2.val : 0;
                var sum = l1Val + l2Val + carryOn;
                if (sum / 10 > 0)
                {
                    carryOn = sum / 10;
                    sum = sum % 10;
                }
                if (result == null)
                {
                    result = new ListNode(sum, null);
                }
                else
                {
                    if (temp == null)
                    {
                        temp = new ListNode(sum, null);
                        result.next = temp;
                    }
                    else
                    {
                        temp.next = new ListNode(sum, null);
                        temp = temp.next;
                    }
                }
                if (l1 != null)
                {
                    l1 = l1.next;
                }
                if (l2 != null)
                {
                    l2 = l2.next;
                }
            }
            return result;
        }
    }
}
