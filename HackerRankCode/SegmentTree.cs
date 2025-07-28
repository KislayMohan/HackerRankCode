using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankCode
{
    internal class SegmentTree
    {
        public void SegmentTreeSol()
        {
            int[] arr = { 1, 3, 2, 7, 9, 11 };
            int n = arr.Length;

            // Build segment tree from given array
            int[] st = constructST(arr, n);

            // Starting index of query range
            int qs = 1;

            // Ending index of query range
            int qe = 5;

            // Print minimum value in arr[qs..qe]
            Console.WriteLine("Minimum of values in range [" + qs + ", " + qe + "] " +
                              "is = " + RMQ(st, n, qs, qe));
        }

        private int RMQ(int[] st, int n, int queryStart, int queryEnd)
        {
            if(queryStart < 0 || queryEnd > n - 1 || queryStart > queryEnd)
            {
                return -1;
            }
            return RMQUtil(st, 0, n - 1, queryStart, queryEnd, 0);
        }

        private int RMQUtil(int[] segmentTree, int segmentStart, int segmentEnd, int queryStart, int queryEnd, int index)
        {
            if(queryStart <= segmentStart && queryEnd >= segmentEnd)
            {
                return segmentTree[index];
            }
            if(queryStart > segmentEnd || segmentStart >queryEnd)
            {
                return int.MaxValue;
            }
            int mid = segmentStart + (segmentEnd - segmentStart) / 2;
            return MinVal(RMQUtil(segmentTree, segmentStart, mid, queryStart, queryEnd, 2 * index + 1), RMQUtil(segmentTree, mid + 1, segmentEnd, queryStart, queryEnd, 2 * index + 2));

        }

        private int[] constructST(int[] arr, int n)
        {
            int height = (int)Math.Ceiling(Math.Log(n, 2));
            int[] segmentTree = new int[2 * (int)Math.Pow(2, height) - 1];
            constructSTUtil(arr, 0, n - 1, segmentTree, 0);
            return segmentTree;
        }

        private int constructSTUtil(int[] arr, int segmentStart, int segmentEnd, int[] segmentTree, int segmentIndex)
        {
            if(segmentStart == segmentEnd)
            {
                segmentTree[segmentIndex] = arr[segmentStart];
                return arr[segmentStart];
            }

            int mid = segmentStart + (segmentEnd - segmentStart) / 2;
            segmentTree[segmentIndex] = MinVal(constructSTUtil(arr, segmentStart, mid, segmentTree, segmentIndex * 2 + 1), constructSTUtil(arr, mid + 1, segmentEnd, segmentTree, segmentIndex * 2 + 2));

            return segmentTree[segmentIndex];
        }

        private int MinVal(int x, int y)
        {
            return x < y ? x : y;
        }
    }
}
