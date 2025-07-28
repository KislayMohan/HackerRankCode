using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankCode
{
    internal class IdleNetwork
    {
        public void NetworkBecomesIdleSol()
        {
            int[][] edges = new int[][] { new int[] { 0, 1 }, new int[] { 0, 2 }, new int[] { 1, 2 } };
            int[] patience = new int[] { 0, 10, 10 };
            Console.WriteLine(NetworkBecomesIdle(edges, patience));
        }

        private int NetworkBecomesIdle(int[][] edges, int[] patience)
        {
            int n = patience.Length;
            List<int>[] graph = new List<int>[n];
            for (int i = 0; i < n; i++)
            {
                graph[i] = new List<int>();
            }

            foreach (var edge in edges)
            {
                graph[edge[0]].Add(edge[1]);
                graph[edge[1]].Add(edge[0]);
            }

            int[] dist = new int[n];
            Array.Fill(dist, int.MaxValue);
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(0);
            dist[0] = 0;

            while (queue.Count > 0)
            {
                int node = queue.Dequeue();
                foreach (int neighbor in graph[node])
                {
                    if (dist[neighbor] == int.MaxValue)
                    {
                        dist[neighbor] = dist[node] + 1;
                        queue.Enqueue(neighbor);
                    }
                }
            }

            int maxTime = 0;
            for (int i = 1; i < n; i++)
            {
                int roundTripTime = dist[i] * 2;
                int lastSentTime = (roundTripTime - 1) / patience[i] * patience[i];
                int lastReplyTime = lastSentTime + roundTripTime;
                maxTime = Math.Max(maxTime, lastReplyTime);
            }

            return maxTime + 1;
        }
    }
}
