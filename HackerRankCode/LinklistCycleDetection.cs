using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankCode
{
    public class LinklistCycleDetection
    {
        static bool hasCycle(SinglyLinkedListNode head)
        {
            if (head == null || head.next == null)
            {
                return false;
            }
            var fastNode = head;
            var slowNode = head;
            while (fastNode != null && fastNode.next != null)
            {
                slowNode = slowNode.next;
                fastNode = fastNode.next.next;
                if (slowNode == fastNode)
                {
                    return true;
                }
            }
            return false;
        }

        public class SinglyLinkedListNode
        {
            public int data { get; set; }
            public SinglyLinkedListNode next { get; set; }
        }
    }
}
