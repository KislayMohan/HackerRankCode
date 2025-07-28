using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankCode
{
    internal class TopKFrequentElements
    {
        public static int[] TopKFrequent(int[] nums, int k)
        {
            // Count the frequency of each number
            var frequencyMap = new Dictionary<int, int>();
            foreach (var num in nums)
            {
                if (frequencyMap.ContainsKey(num))
                {
                    frequencyMap[num]++;
                }
                else
                {
                    frequencyMap[num] = 1;
                }
            }
            // Use a priority queue to get the top k frequent elements
            var maxHeap = new PriorityQueue<int, int>(Comparer<int>.Create((a, b) => 
            { 
                return b.CompareTo(a); // Max heap, so we want larger frequencies first
            }));
            foreach (var kvp in frequencyMap)
            {
                maxHeap.Enqueue(kvp.Key, kvp.Value);
            }
            // Extract the top k elements
            var result = new List<int>();
            for (int i = 0; i < k; i++)
            {
                if (maxHeap.Count > 0)
                {
                    result.Add(maxHeap.Dequeue());
                }
            }
            return result.ToArray();
        }
    }
}
