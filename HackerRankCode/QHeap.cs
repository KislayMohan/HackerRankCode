using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankCode
{
    public class QHeap
    {
        public static void PerformQHeap()
        {
            var opCount = Convert.ToInt32(Console.ReadLine());
            var input = new List<string>();
            for (int i = 0; i < opCount; i++)
            {
                input.Add(Console.ReadLine());
            }
            var heap = new List<long>();
            long data = 0;
            for (int i = 0; i < input.Count; i++)
            {
                var splitInput = input[i].Split(' ');
                var op = splitInput[0];
                switch (op)
                {
                    case "1":
                        data = Convert.ToInt64(splitInput[1]);
                        heap.Add(data);
                        if (i > 0)
                        {
                            InsertHeapify(heap, heap.Count - 1);
                        }
                        break;
                    case "2":
                        data = Convert.ToInt64(splitInput[1]);
                        var indexOfData = heap.IndexOf(data);
                        heap[indexOfData] = heap[heap.Count - 1];
                        heap.RemoveAt(heap.Count - 1);
                        DeleteHeapify(heap, indexOfData);
                        break;
                    case "3":
                        Console.WriteLine(heap[0]);
                        break;
                }
            }
        }

        private static void InsertHeapify(List<long> heap, int index)
        {
            if (index == 0)
            {
                return;
            }
            int parentIndex = (index - 1) / 2;
            if (heap[index] < heap[parentIndex])
            {
                heap[index] = heap[index] + heap[parentIndex];
                heap[parentIndex] = heap[index] - heap[parentIndex];
                heap[index] = heap[index] - heap[parentIndex];

                InsertHeapify(heap, parentIndex);
            }
        }

        private static void DeleteHeapify(List<long> heap, int pos)
        {
            var smallest = pos;
            var left = 2 * pos + 1;
            var right = 2 * pos + 2;

            if (left < heap.Count && heap[left] < heap[smallest])
            {
                smallest = left;
            }

            if (right < heap.Count && heap[right] < heap[smallest])
            {
                smallest = right;
            }

            if (smallest != pos)
            {
                heap[pos] = heap[smallest] + heap[pos];
                heap[smallest] = heap[pos] - heap[smallest];
                heap[pos] = heap[pos] - heap[smallest];

                DeleteHeapify(heap, smallest);
            }
        }
    }
}
