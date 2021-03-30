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
            double[] result = SolveRunningMedian(a);
        }

        private static double[] SolveRunningMedian(int[] a)
        {
            var result = new double[a.Length];
            for (int i = 0; i < a.Length; i++)
            {
                if (i == 0)
                {
                    result[i] = a[i];
                    continue;
                }

            }

            return result;
        }

        private static void BuildMinHeap(List<int> numList)
        {
            var startIndex = numList.Count / 2 - 1;
            for (int i = startIndex; i >= 0; i--)
            {
                MinHeapify(numList, numList.Count, i);
            }
        }

        private static void MinHeapify(List<int> numList, int length, int i)
        {
            var smallest = i;
            var leftChild = 2 * i + 1;
            var rightChild = 2 * i + 2;
            if (leftChild < length && numList[leftChild] < numList[smallest])
            {
                smallest = leftChild;
            }

            if (rightChild < length && numList[rightChild] < numList[smallest])
            {
                smallest = rightChild;
            }

            if (smallest != i)
            {
                var temp = numList[i];
                numList[i] = numList[smallest];
                numList[smallest] = temp;

                MinHeapify(numList, length, smallest);
            }
        }

        private static void BuildMaxHeap(List<int> numList)
        {
            var startIndex = numList.Count / 2 - 1;
            for (int i = startIndex; i >= 0; i--)
            {
                MaxHeapify(numList, numList.Count, i);
            }
        }

        private static void MaxHeapify(List<int> numList, int length, int i)
        {
            var largest = i;
            var leftChild = 2 * i + 1;
            var rightChild = 2 * i + 2;
            if (leftChild < length && numList[leftChild] > numList[largest])
            {
                largest = leftChild;
            }

            if (rightChild < length && numList[rightChild] > numList[largest])
            {
                largest = rightChild;
            }

            if (largest != i)
            {
                var temp = numList[i];
                numList[i] = numList[largest];
                numList[largest] = temp;

                MaxHeapify(numList, length, largest);
            }
        }
    }
}
