using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankCode
{
    public class SinglyLinkedListNode
    {
        public int data;
        public SinglyLinkedListNode next;

        public SinglyLinkedListNode(int nodeData)
        {
            this.data = nodeData;
            this.next = null;
        }
    }

    public class SinglyLinkedList
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

        public static SinglyLinkedListNode insertNodeAtHead(SinglyLinkedListNode llist, int data)
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

        public static SinglyLinkedListNode Reverse(SinglyLinkedListNode head)
        {
            SinglyLinkedListNode currentNode = head;
            SinglyLinkedListNode nextNode = null;
            SinglyLinkedListNode prevNode = null;
            while (currentNode != null)
            {
                nextNode = currentNode.next;
                currentNode.next = prevNode;
                prevNode = currentNode;
                currentNode = nextNode;
            }
            head = prevNode;
            return head;
        }

        public static void ReversePrint(SinglyLinkedListNode head)
        {
            SinglyLinkedListNode currentNode = head;
            SinglyLinkedListNode nextNode = null;
            SinglyLinkedListNode prevNode = null;
            while (currentNode != null)
            {
                nextNode = currentNode.next;
                currentNode.next = prevNode;
                prevNode = currentNode;
                currentNode = nextNode;
            }
            head = prevNode;
            while (head != null)
            {
                Console.WriteLine(head.data);
                head = head.next;
            }
        }

        public static long ConvertBinaryToNumberUsingLinklist(SinglyLinkedListNode head)
        {
            long result = 0;
            double counter = 0;
            SinglyLinkedListNode currentNode = head;
            SinglyLinkedListNode nextNode = null;
            SinglyLinkedListNode prevNode = null;
            while (currentNode != null)
            {
                nextNode = currentNode.next;
                currentNode.next = prevNode;
                prevNode = currentNode;
                currentNode = nextNode;
            }
            head = prevNode;
            while (head != null)
            {
                result += (long)head.data * (long)Math.Pow(2, counter);
                counter++;
                head = head.next;
            }

            return result;
        }
    }
}
