using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankCode
{
    public class ArrayQueries
    {
        public static void ArrayQuerySol()
        {
            var inputData = Console.ReadLine().Split(' ');
            var numCount = Convert.ToInt32(inputData[0]);
            var queryCount = Convert.ToInt32(inputData[1]);
            var numList = Array.ConvertAll(Console.ReadLine().Split(' '), a => Convert.ToInt32(a)).Take(numCount).ToList();

            for (int i = 0; i < queryCount; i++)
            {
                var query = Console.ReadLine().Split(' ');
                var startIndex = Convert.ToInt32(query[1]);
                var endIndex = Convert.ToInt32(query[2]);
                var counter = 0;
                var dataQueue = new Queue<int>();
                if (startIndex == 1 && endIndex == numList.Count)
                {
                    continue;
                }
                switch (query[0])
                {
                    case "1":
                        if (startIndex == 1)
                        {
                            continue;
                        }
                        counter = startIndex - 2;
                        for (int j = endIndex - 1; j >= 0; j--)
                        {
                            if (counter >= 0)
                            {
                                if (j > startIndex - 2)
                                {
                                    dataQueue.Enqueue(numList[j]);
                                }
                                numList[j] = numList[counter--];
                            }
                            else if (j > startIndex - 2)
                            {
                                dataQueue.Enqueue(numList[j]);
                                numList[j] = dataQueue.Dequeue();
                            }
                            else if (dataQueue.Count > 0)
                            {
                                numList[j] = dataQueue.Dequeue();
                            }
                        }
                        break;

                    case "2":
                        if (endIndex == numList.Count)
                        {
                            continue;
                        }
                        counter = endIndex;
                        for (int j = startIndex - 1; j < numList.Count; j++)
                        {
                            if (counter < numList.Count)
                            {
                                if (j < endIndex)
                                {
                                    dataQueue.Enqueue(numList[j]);
                                }
                                numList[j] = numList[counter++];
                            }
                            else if (j < endIndex)
                            {
                                dataQueue.Enqueue(numList[j]);
                                numList[j] = dataQueue.Dequeue();
                            }
                            else if (dataQueue.Count > 0)
                            {
                                numList[j] = dataQueue.Dequeue();
                            }
                        }
                        break;
                }
            }
            Console.WriteLine(Math.Abs(numList[0] - numList[numList.Count - 1]));
            Console.WriteLine(string.Join(" ", numList));
        }

        public static void ArrayQuerySol_LinkList()
        {
            var inputData = Console.ReadLine().Split(' ');
            var numCount = Convert.ToInt32(inputData[0]);
            var queryCount = Convert.ToInt32(inputData[1]);
            var numList = Array.ConvertAll(Console.ReadLine().Split(' '), a => Convert.ToInt32(a)).Take(numCount).ToList();
            ListNode temp = null;
            ListNode linkStart = null;
            ListNode linkMid = null;
            ListNode linkEnd = null;
            for (int i = 0; i < queryCount; i++)
            {
                var query = Console.ReadLine().Split(' ');
                var startIndex = Convert.ToInt32(query[1]);
                var endIndex = Convert.ToInt32(query[2]);
                linkStart = new ListNode(numList.Take(startIndex - 1));
                linkMid = new ListNode(numList.Skip(startIndex - 1).Take(endIndex - startIndex + 1));
                linkEnd = new ListNode(numList.Skip(endIndex));
                if (startIndex == 1 && endIndex == numList.Count)
                {
                    continue;
                }
                switch (query[0])
                {
                    case "1":
                        linkStart.Next = linkEnd;
                        linkMid.Next = linkStart;
                        //swap start and mid
                        temp = linkStart;
                        linkStart = linkMid;
                        linkMid = temp;
                        break;

                    case "2":
                        linkStart.Next = linkEnd;
                        linkEnd.Next = linkMid;
                        linkMid.Next = null;
                        //swap mid and end
                        temp = linkMid;
                        linkMid = linkEnd;
                        linkEnd = temp;
                        break;
                }
                numList = linkStart.GetData().Union(linkMid.GetData()).Union(linkEnd.GetData()).ToList();
            }
            Console.WriteLine(Math.Abs(numList[0] - numList[numList.Count - 1]));
            Console.WriteLine(string.Join(" ", numList));
        }

        public class ListNode
        {
            public IEnumerable<int> Data { get; set; }
            public ListNode Next { get; set; }

            public ListNode(IEnumerable<int> val)
            {
                Data = val;
            }

            public IEnumerable<int> GetData()
            {
                return Data;
            }
        }
    }
}
