using System;
using System.Collections.Generic;
using System.Text;

namespace HackerRankCode
{
    internal class SequenceReconstructionSol
    {
        public bool CanConstruct(int[] nums, IList<IList<int>> sequences)
        {
            int n = nums.Length;
            var graph = new Dictionary<int, HashSet<int>>();
            var inDegree = new Dictionary<int, int>();
            for (int i = 1; i <= n; i++)
            {
                graph[i] = new HashSet<int>();
                inDegree[i] = 0;
            }
            foreach (var seq in sequences)
            {
                for (int i = 0; i < seq.Count; i++)
                {
                    if (seq[i] < 1 || seq[i] > n) return false;
                    if (i > 0)
                    {
                        if (graph[seq[i - 1]].Add(seq[i]))
                        {
                            inDegree[seq[i]]++;
                        }
                    }
                }
            }
            var queue = new Queue<int>();
            for (int i = 1; i <= n; i++)
            {
                if (inDegree[i] == 0)
                {
                    queue.Enqueue(i);
                }
            }
            int index = 0;
            while (queue.Count > 0)
            {
                if (queue.Count > 1) return false;
                int current = queue.Dequeue();
                if (nums[index] != current) return false;
                index++;
                foreach (var neighbor in graph[current])
                {
                    inDegree[neighbor]--;
                    if (inDegree[neighbor] == 0)
                    {
                        queue.Enqueue(neighbor);
                    }
                }
            }
            return index == n;
        }
    }
}
