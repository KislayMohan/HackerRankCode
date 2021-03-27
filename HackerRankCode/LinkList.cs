using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankCode
{
    class SinglyLinkedListNode
    {
        public int data;
        public SinglyLinkedListNode next;

        public SinglyLinkedListNode(int nodeData)
        {
            this.data = nodeData;
            this.next = null;
        }
    }

    class SinglyLinkedList
    {
        public SinglyLinkedListNode head;
        public SinglyLinkedListNode tail;

        public SinglyLinkedList()
        {
            this.head = null;
            this.tail = null;
        }
    }

    public static class LinkList
    {
        static void GenerateLinkList()
        {
            TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            SinglyLinkedList llist = new SinglyLinkedList();

            int llistCount = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < llistCount; i++)
            {
                int llistItem = Convert.ToInt32(Console.ReadLine());
                SinglyLinkedListNode llist_head = insertNodeAtHead(llist.head, llistItem);
                llist.head = llist_head;
            }



            PrintSinglyLinkedList(llist.head, "\n", textWriter);
            textWriter.WriteLine();

            textWriter.Flush();
            textWriter.Close();
        }

        static void PrintSinglyLinkedList(SinglyLinkedListNode node, string sep, TextWriter textWriter)
        {
            while (node != null)
            {
                textWriter.Write(node.data);
                node = node.next;
                if (node != null)
                {
                    textWriter.Write(sep);
                }
            }
        }

        static SinglyLinkedListNode insertNodeAtHead(SinglyLinkedListNode llist, int data)
        {
            var insertNode = new SinglyLinkedListNode(data);
            if (llist == null)
            {
                insertNode.next = null;
                return insertNode;
            }
            else
            {
                insertNode.next = llist;
            }
            return insertNode;
        }
    }
}
