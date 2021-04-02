using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankCode
{
    public class RunningMedian
    {
        public static void RunningMedianFlow()
        {
            int aCount = Convert.ToInt32(Console.ReadLine());
            int[] a = new int[aCount];
            for (int aItr = 0; aItr < aCount; aItr++)
            {
                int aItem = Convert.ToInt32(Console.ReadLine());
                a[aItr] = aItem;
            }
            string[] result = SolveRunningMedian(a);
            Console.WriteLine("-----------------");
            Console.WriteLine(string.Join("\n", result));
        }

        private static string[] SolveRunningMedian(int[] a)
        {
            var result = new string[a.Length];
            var maxHeap = new List<int>(a.Length / 2 + 1);
            var minHeap = new List<int>(a.Length / 2 + 1);
            for (int i = 0; i < a.Length; i++)
            {
                if (i == 0)
                {
                    maxHeap.Add(a[i]);
                    result[i] = string.Format("{0:0.0}", a[i]);
                    continue;
                }
                InsertInHeap(a[i], maxHeap, minHeap);

                if (maxHeap.Count == minHeap.Count)
                {
                    result[i] = string.Format("{0:0.0}", Math.Round(((double)maxHeap[0] + (double)minHeap[0]) / 2, 1));
                }
                else
                {
                    var largerHeap = maxHeap.Count > minHeap.Count ? maxHeap : minHeap;
                    result[i] = string.Format("{0:0.0}", Math.Round((double)largerHeap[0], 1));
                }
            }
            return result;
        }

        private static void InsertInHeap(int num, List<int> maxHeap, List<int> minHeap)
        {
            if (maxHeap[0]  > num)
            {
                maxHeap.Add(num);
                BuildMaxHeap(maxHeap);
            }
            else
            {
                minHeap.Add(num);
                BuildMinHeap(minHeap);
            }
            int tempNum = -1;
            if (maxHeap.Count - minHeap.Count > 1)
            {
                while (maxHeap.Count - minHeap.Count > 1)
                {
                    tempNum = maxHeap[0];
                    maxHeap[0] = maxHeap[maxHeap.Count - 1];
                    maxHeap.RemoveAt(maxHeap.Count - 1);
                    BuildMaxHeap(maxHeap);

                    minHeap.Add(tempNum);
                    BuildMinHeap(minHeap);
                }
            }
            else if (minHeap.Count - maxHeap.Count > 1)
            {
                while (minHeap.Count - maxHeap.Count > 1)
                {
                    tempNum = minHeap[0];
                    minHeap[0] = minHeap[minHeap.Count - 1];
                    minHeap.RemoveAt(minHeap.Count - 1);
                    BuildMinHeap(minHeap);

                    maxHeap.Add(tempNum);
                    BuildMaxHeap(maxHeap);
                }
            }
            /*
            if (maxHeap.Count > minHeap.Count)
            {
                if (maxHeap.First() < num)
                {
                    minHeap.Add(num);
                    BuildMinHeap(minHeap);
                }
                else
                {
                    minHeap.Add(maxHeap.First());
                    BuildMinHeap(minHeap);
                    maxHeap[0] = num;
                    BuildMaxHeap(maxHeap);
                }
            }
            else if (maxHeap.Count < minHeap.Count)
            {
                if (maxHeap.First() > num)
                {
                    maxHeap.Add(num);
                    BuildMaxHeap(maxHeap);
                }
                else
                {
                    maxHeap.Add(minHeap.First());
                    BuildMaxHeap(maxHeap);
                    minHeap[0] = num;
                    BuildMinHeap(minHeap);
                }
            }
            else
            {
                if (maxHeap.First() < num)
                {
                    minHeap.Add(num);
                    BuildMinHeap(minHeap);
                }
                else
                {
                    maxHeap.Add(num);
                    BuildMaxHeap(maxHeap);
                }
            }
            */
        }

        private static void BuildMinHeap(List<int> numList)
        {
            var startIndex = numList.Count / 2 - 1;
            for (int i = startIndex; i >= 0; i--)
            {
                MinHeapify(numList, i);
            }
        }

        private static void MinHeapify(List<int> numList, int i)
        {
            var smallest = i;
            var leftChild = 2 * i + 1;
            var rightChild = 2 * i + 2;
            if (leftChild < numList.Count && numList[leftChild] < numList[smallest])
            {
                smallest = leftChild;
            }

            if (rightChild < numList.Count && numList[rightChild] < numList[smallest])
            {
                smallest = rightChild;
            }

            if (smallest != i)
            {
                var temp = numList[i];
                numList[i] = numList[smallest];
                numList[smallest] = temp;

                MinHeapify(numList, smallest);
            }
        }

        private static void BuildMaxHeap(List<int> numList)
        {
            var startIndex = numList.Count / 2 - 1;
            for (int i = startIndex; i >= 0; i--)
            {
                MaxHeapify(numList, i);
            }
        }

        private static void MaxHeapify(List<int> numList, int i)
        {
            var largest = i;
            var leftChild = 2 * i + 1;
            var rightChild = 2 * i + 2;
            if (leftChild < numList.Count && numList[leftChild] > numList[largest])
            {
                largest = leftChild;
            }

            if (rightChild < numList.Count && numList[rightChild] > numList[largest])
            {
                largest = rightChild;
            }

            if (largest != i)
            {
                var temp = numList[i];
                numList[i] = numList[largest];
                numList[largest] = temp;

                MaxHeapify(numList, largest);
            }
        }
    }
}
