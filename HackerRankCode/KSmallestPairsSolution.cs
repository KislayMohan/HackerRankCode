using System;
using System.Collections.Generic;
using System.Text;

namespace HackerRankCode
{
    internal class KSmallestPairsSolution
    {
        public IList<IList<int>> KSmallestPairs(int[] nums1, int[] nums2, int k)
        {
            var result = new List<IList<int>>();
            var minHeap = new SortedSet<(int sum, int i, int j)>();
            for (int j = 0; j < Math.Min(nums2.Length, k); j++)
            {
                minHeap.Add((nums1[0] + nums2[j], 0, j));
            }
            while (k > 0 && minHeap.Count > 0)
            {
                var (sum, i, j) = minHeap.Min;
                minHeap.Remove(minHeap.Min);
                result.Add(new List<int> { nums1[i], nums2[j] });
                if (i + 1 < nums1.Length)
                {
                    minHeap.Add((nums1[i + 1] + nums2[j], i + 1, j));
                }
                k--;
            }
            return result;
        }
    }
}
