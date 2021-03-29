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
            int result = cookies1(k, A);
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
            var numList = A.ToList();
            var moves = 0;
            BuildMinHeap(numList);
            while (true)
            {
                var smallest = numList[0];
                if (smallest >= k)
                {
                    return moves;
                }
                if(numList.Count >= 2)
                {
                    numList[0] = numList[numList.Count - 1];
                    numList.RemoveAt(numList.Count - 1);
                    Heapify(numList, numList.Count, 0);
                    var secondSmallest = numList[0];
                    numList[0] = numList[numList.Count - 1];
                    numList.RemoveAt(numList.Count - 1);
                    numList.Add(smallest + 2 * secondSmallest);
                    Heapify(numList, numList.Count, 0);
                    moves++;
                }
                else if(numList.Count == 1 && numList[0] < k)
                {
                    return -1;
                }
            }
            //return moves;
        }

        private static void BuildMinHeap(List<int> numList)
        {
            var startIndex = numList.Count / 2 - 1;
            for (int i = startIndex; i >= 0; i--)
            {
                Heapify(numList, numList.Count, i);
            }
        }

        private static void Heapify(List<int> numList, int length, int i)
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

                Heapify(numList, length, smallest);
            }
        }
    }
}
