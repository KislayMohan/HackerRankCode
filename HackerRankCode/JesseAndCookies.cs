using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankCode
{
    public class JesseAndCookies
    {
        public static void JesseAndCookiesFlow()
        {
            string[] nk = Console.ReadLine().Split(' ');
            int n = Convert.ToInt32(nk[0]);
            int k = Convert.ToInt32(nk[1]);
            int[] A = Array.ConvertAll(Console.ReadLine().Split(' '), ATemp => Convert.ToInt32(ATemp));
            int result = cookies2(k, A);
            Console.WriteLine(result);
        }

        private static int cookies(int k, int[] A)
        {
            Array.Sort(A);
            return SolveCookies(k, A.ToList());
        }

        private static int SolveCookies(int k, List<int> A)
        {
            var moves = -1;
            if (A.Count == 0)
            {
                return 0;
            }
            if (A.Count == 1 && A[0] < k)
            {
                return -1;
            }
            var smallest = A[0];
            var secondSmallest = A[1];
            if (smallest >= k)
            {
                return 0;
            }
            A.RemoveRange(0, 2);
            int i = 0;
            var insertElement = smallest + 2 * secondSmallest;
            for (; i < A.Count; i++)
            {
                if (A[i] < insertElement)
                {
                    continue;
                }
                break;
            }
            var tempA = new List<int>(A.Count + 1);
            for (int j = 0; j < A.Count + 1; j++)
            {
                if (j < i)
                {
                    tempA.Add(A[j]);
                }
                else if (j == i)
                {
                    tempA.Add(insertElement);
                }
                else
                {
                    tempA.Add(A[j - 1]);
                }
            }

            var tempMove = SolveCookies(k, tempA);
            if (tempMove == -1)
            {
                return -1;
            }
            moves = tempMove + 1;

            return moves;
        }

        private static int cookies1(int k, int[] A)
        {
            var moves = -1;
            BuildMinHeap(A);
            if (A.Length == 1)
            {
                return moves;
            }
            int smallest = -1, secondSmallest = -1, secondSmallestIndex = -1;
            smallest = A[0];
            if (A.Length == 2)
            {
                secondSmallest = A[1];
                secondSmallestIndex = 1;
            }
            else
            {
                if (A[1] < A[2])
                {
                    secondSmallest = A[1];
                    secondSmallestIndex = 1;
                }
                else
                {
                    secondSmallest = A[2];
                    secondSmallestIndex = 2;
                }
            }
            moves = 0;
            if (smallest >= k && secondSmallest >= k)
            {
                return moves;
            }
            var tempA = A.ToList();
            tempA.RemoveAt(0);
            tempA.RemoveAt(secondSmallestIndex - 1);
            tempA.Add(smallest + 2 * secondSmallest);
            A = tempA.ToArray();
            Heapify(A, A.Length, 0);
            moves = cookies(k, A) + 1;
            return moves;
        }

        private static void BuildMinHeap(int[] arr)
        {
            var startIndex = arr.Length / 2 - 1;
            for (int i = startIndex; i >= 0; i--)
            {
                Heapify(arr, arr.Length, i);
            }
        }

        private static void Heapify(int[] arr, int length, int i)
        {
            var smallest = i;
            var leftChild = 2 * i + 1;
            var rightChild = 2 * i + 2;
            if (leftChild < length && arr[leftChild] < arr[smallest])
            {
                smallest = leftChild;
            }

            if (rightChild < length && arr[rightChild] < arr[smallest])
            {
                smallest = rightChild;
            }

            if (smallest != i)
            {
                var temp = arr[i];
                arr[i] = arr[smallest];
                arr[smallest] = temp;

                Heapify(arr, length, smallest);
            }
        }

        private static int cookies2(int k, int[] A)
        {
            var moves = 0;
            if (A.Length == 0 || (A.Length == 1 && A[0] < k))
            {
                return -1;
            }
            var heap = new List<int>();
            for (int i = 0; i < A.Length; i++)
            {
                heap.Add(A[i]);
                InsertHeapify(heap, i);
            }
            while (heap[0] < k)
            {
                var smallest = heap[0];
                heap.RemoveAt(0);
                DeleteHeapify(heap, 0);
                var secondSmallest = heap[0];
                heap.RemoveAt(0);
                DeleteHeapify(heap, 0);
                heap.Add(smallest + 2 * secondSmallest);
                InsertHeapify(heap, heap.Count - 1);
                moves++;
            }
            return moves;
        }

        private static void InsertHeapify(List<int> heap, int index)
        {
            int parentIndex = (index - 1) / 2;
            while (index >= 0 && heap[parentIndex] > heap[index])
            {
                heap[index] = heap[index] + heap[parentIndex];
                heap[parentIndex] = heap[index] - heap[parentIndex];
                heap[index] = heap[index] - heap[parentIndex];

                index = (index - 1) / 2;
                parentIndex = (index - 1) / 2;
            }
        }

        private static void DeleteHeapify(List<int> heap, int pos)
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
