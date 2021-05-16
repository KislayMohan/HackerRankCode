using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankCode
{
    public class FindLCA
    {
        static List<int> nodes = new List<int>();
        static int[,] memo;
        static int[] level;
        static List<int>[] graph;
        static int nodeLog;
        public static void FindLCAFlow()
        {
            var nodesCount = Convert.ToInt32(Console.ReadLine());
            nodesCount = 9;
            nodeLog = (int)Math.Ceiling(Math.Log(nodesCount) / Math.Log(2));
            level = new int[nodesCount + 1];
            memo = new int[nodesCount + 1, nodeLog + 1];
            graph = new List<int>[nodesCount + 1];

            for (int i = 0; i <= nodesCount; i++)
            {
                graph[i] = new List<int>();
                for (int j = 0; j <= nodeLog; j++)
                {
                    memo[i, j] = -1;
                }
            }
            //Create graph
            graph[1].Add(2);
            graph[2].Add(1);
            graph[1].Add(3);
            graph[3].Add(1);
            graph[1].Add(4);
            graph[4].Add(1);
            graph[2].Add(5);
            graph[5].Add(2);
            graph[3].Add(6);
            graph[6].Add(3);
            graph[3].Add(7);
            graph[7].Add(3);
            graph[3].Add(8);
            graph[8].Add(3);
            graph[4].Add(9);
            graph[9].Add(4);

            DFS(1, 1);

            Console.WriteLine("The LCA of 5 and 3 is " + LCA(5, 3));
            Console.WriteLine("The LCA of 6 and 9 is " + LCA(6, 9));
            Console.WriteLine("The LCA of 5 and 9 is " + LCA(5, 9));
            Console.WriteLine("The LCA of 6 and 8 is " + LCA(6, 8));
            Console.WriteLine("The LCA of 6 and 1 is " + LCA(6, 1));
        }

        private static void DFS(int v1, int v2)
        {
            memo[v1, 0] = v2;
            for (int i = 1; i <= nodeLog; i++)
            {
                memo[v1, i] = memo[memo[v1, i - 1], i - 1];
            }
            foreach (var v in graph[v1])
            {
                if (v != v2)
                {
                    level[v] = level[v1] + 1;
                    DFS(v, v1);
                }
            }
        }

        private static int LCA(int v1, int v2)
        {
            // find node farther from root
            var fartherNode = v1;
            var closerNode = v2;
            if (level[v1] < level[v2])
            {
                fartherNode = v2;
                closerNode = v1;
            }

            // Find ancestor of farther node which is at same level as closerNode
            for (int i = nodeLog; i >= 0; i--)
            {
                if (level[fartherNode] - (int)Math.Pow(2, i) >= level[closerNode])
                {
                    fartherNode = memo[fartherNode, i];
                }
            }

            // If after travelling up ancestors both are same then we have arrived at LCA
            if (fartherNode == closerNode)
            {
                return fartherNode;
            }

            //Find the node closest to root which is not the common ancestor i.e. x but memo[x,0] is
            for (int i = nodeLog; i >= 0; i--)
            {
                if (memo[fartherNode, i] != memo[closerNode, i])
                {
                    fartherNode = memo[fartherNode, i];
                    closerNode = memo[closerNode, i];
                }
            }

            //return first ancestor of memo
            return memo[fartherNode, 0];
        }
    }
}
