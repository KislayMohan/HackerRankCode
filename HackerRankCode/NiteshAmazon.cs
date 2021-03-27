using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankCode
{
    public class NiteshAmazon
    {
        public static void TakeInput()
        {
            var node = 10;
            var edges = new List<string> { "1 2", "1 3", "2 4", "3 5", "7 8" };
            node = 8;
            edges = new List<string> { "8 1", "5 8", "7 3", "8 6" };
            node = 16;
            edges = new List<string> { "6 11", "9 5", "11 9", "15 9","13 15", "12 14", "15 16", "1 16" };
            var sum = ConnectedSum(node, edges);
            Console.WriteLine(sum);
        }
        public static int ConnectedSum(int n, List<string> edges)
        {
            int sum = 0;
            int[] nodeArr = new int[n + 1];
            for (int i = 0; i < edges.Count; i++)
            {
                var nodes = edges[i].Split(' ');
                var small = Convert.ToInt32(nodes[0]);
                var large = Convert.ToInt32(nodes[1]);
                if (small > large)
                {
                    large = large + small;
                    small = large - small;
                    large = large - small;
                }
                if (nodeArr[small] == 0 && nodeArr[large] == 0)
                {
                    nodeArr[small] = small;
                    nodeArr[large] = small;
                    continue;
                }
                else
                {

                    //var curr = nodeArr[Convert.ToInt32(nodes[0])];
                    //while (curr != nodeArr[curr])
                    //{
                    //    curr = nodeArr[curr];
                    //}
                    //nodeArr[Convert.ToInt32(nodes[1])] = curr;
                    var curr = nodeArr[small] != 0 ? nodeArr[small] : nodeArr[large];
                    var otherNode = nodeArr[small] == 0 ? small : large;
                    while (curr != nodeArr[curr])
                    {
                        curr = nodeArr[curr];
                    }
                    nodeArr[otherNode] = curr;
                }
            }
            var visit = new Dictionary<int, int>();
            int singleNode = 0;
            for (int j = 1; j < nodeArr.Length; j++)
            {
                var node = nodeArr[j];
                if (node == 0)
                {
                    singleNode++;
                }
                else
                {
                    if (!visit.ContainsKey(node))
                    {
                        visit[node] = 1;
                    }
                    else
                    {
                        visit[node] = visit[node] + 1;
                    }
                }
            }

            var pairCalc = 0;
            foreach (var item in visit.Values)
            {
                pairCalc += Convert.ToInt32(Math.Ceiling(Math.Sqrt(item)));
            }
            sum = pairCalc + singleNode;

            return sum;
        }
    }
}
