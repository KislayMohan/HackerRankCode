/*
 *Kitty has a tree, , consisting of  nodes where each node is uniquely labeled from  to . Her friend Alex gave her  sets, where each set contains  distinct nodes. Kitty needs to calculate the following expression on each set:

where:

 denotes an unordered pair of nodes belonging to the set.
 denotes the number of edges on the unique path between nodes  and .
Given  and  sets of  distinct nodes, can you help her calculate the expression for each set? For each set of nodes, print the value of the expression modulo  on a new line.

Input Format

The first line contains two space-separated integers describing the respective values of  (the number of nodes in tree ) and (the number of sets). 
Each of the  subsequent lines contains two space-separated integers,  and , describing an undirected edge between nodes  and . 
The  subsequent lines define each set over two lines in the following format:

The first line contains an integer, , denoting the size of the set.
The second line contains  space-separated integers describing the set's elements.
Constraints

The sum of  over all  does not exceed .
All elements in each set are distinct.
Subtasks

 for  of the maximum score.
 for  of the maximum score.
 for  of the maximum score.
Output Format

Print  lines of output where each line  contains the expression for the  query, modulo .

Sample Input 0

7 3
1 2
1 3
1 4
3 5
3 6
3 7
2
2 4
1
5
3
2 4 5
Sample Output 0

16
0
106
Explanation 0

Tree  looks like this:

image

We perform the following calculations for  sets:

Set : Given set , the only pair we can form is , where . We then calculate the following answer and print it on a new line:
Set : Given set , we cannot form any pairs because we don't have at least two elements. Thus, we print  on a new line.

Set : Given set , we can form the pairs , , and . We then calculate the following answer and print it on a new line:

 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace HackerRankCode
{
    public class KittyTreeCalculation
    {
        public void NewKittyTree()
        {
            var content = File.ReadAllLines("../../input.txt");
            //var content = Console.ReadLine();
            var input = content[0].Split(' ');
            //var input = content.Split(' ');
            var nodeCount = Convert.ToInt32(input[0]);
            var setCount = Convert.ToInt32(input[1]);
            var neighbours = new Dictionary<int, HashSet<int>>();
            var querySubset = new List<List<Tuple<int, int>>>();
            int counter = 1;
            var output = new List<string>();
            var root = Convert.ToInt32(content[1].Split(' ')[0]);
            var rootPath = new Dictionary<long, List<long>>();
            rootPath[root] = new List<long> { root };
            for (; counter < nodeCount; counter++)
            {
                var nodes = content[counter].Split(' ');
                var node1 = Convert.ToInt64(nodes[0]);
                var node2 = Convert.ToInt64(nodes[1]);
                //if (!neighbours.ContainsKey(node1))
                //{
                //    neighbours[node1] = new HashSet<int>();
                //}
                //if (!neighbours.ContainsKey(node2))
                //{
                //    neighbours[node2] = new HashSet<int>();
                //}
                //neighbours[node1].Add(node2);
                //neighbours[node2].Add(node1);
                if (!rootPath.ContainsKey(node2))
                {
                    rootPath[node2] = new List<long> { node2 };
                    rootPath[node2].AddRange(rootPath[node1]);
                }
                if (!rootPath.ContainsKey(node1))
                {
                    rootPath[node1] = new List<long> { node1 };
                    rootPath[node1].AddRange(rootPath[node2]);
                }
            }
            Console.ReadLine();
        }

        public void KittyTree()
        {
            var content = File.ReadAllLines("../../KittyTreeCalculation/input.txt");
            var input = content[0].Split(' ');
            //var content = Console.ReadLine();
            //var input = content.Split(' ');
            var nodeCount = Convert.ToInt32(input[0]);
            var setCount = Convert.ToInt32(input[1]);
            var neighbours = new Dictionary<int, HashSet<int>>();
            var querySubset = new List<List<Tuple<int, int>>>();
            int counter = 1;
            var output = new List<string>();
            var root = Convert.ToInt32(content[1].Split(' ')[0]);
            var rootDistance = new Dictionary<int, Tuple<List<int>, int>>();
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            for (; counter < nodeCount; counter++)
            {
                var nodes = content[counter].Split(' ');
                //var nodes = Console.ReadLine().Split(' ');
                var node1 = Convert.ToInt32(nodes[0]);
                var node2 = Convert.ToInt32(nodes[1]);
                if (!neighbours.ContainsKey(node1))
                {
                    neighbours[node1] = new HashSet<int>();
                }
                if (!neighbours.ContainsKey(node2))
                {
                    neighbours[node2] = new HashSet<int>();
                }
                neighbours[node1].Add(node2);
                neighbours[node2].Add(node1);
            }
            /*
            for (int i = 1; i <= nodeCount; i++)
            {
                var visited = new bool[nodeCount + 1];
                var path = new List<int>();
                RootPath(i, root, path, neighbours, visited);
                rootDistance[i] = Tuple.Create(path, path.Count - 1);
                //ComputeRootDistance(i, neighbours, root, rootDistance);
            }
            */
            for (; setCount > 0; setCount--, counter += 2)
            {
                var queryCount = Convert.ToInt32(content[counter]);
                //var queryCount = Convert.ToInt32(Console.ReadLine());
                var nodes = content[counter + 1].Split(' ').Select(c => Convert.ToInt32(c)).ToList();
                output.Add(Evaluate(neighbours, queryCount, nodes, root, nodeCount).ToString());
            }
            /*
            for (; setCount > 0; setCount--, counter += 2)
            {
                var queryCount = Convert.ToInt32(content[counter]);
                //var queryCount = Convert.ToInt32(Console.ReadLine());
                var nodes = content[counter + 1].Split(' ').Select(c => Convert.ToInt32(c)).ToList();
                //var nodes = Console.ReadLine().Split(' ').Select(c => Convert.ToInt32(c)).ToList();
                //querySubset.Add(GetNodeNeighbourSubset(nodes));
                output.Add(NewCompute(neighbours, queryCount, nodes).ToString());
            }
            */
            //output = ComputeFunction(neighbours, querySubset);
            //foreach (var resp in output)
            //{
            //    Console.WriteLine(resp);
            //}
            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed);
            File.WriteAllLines("../../KittyTreeCalculation/output.txt", output);
            //Console.ReadLine();
        }

        private ulong Evaluate(Dictionary<int, HashSet<int>> neighbours, int queryCount, List<int> nodes, int root, int nodeCount)
        {
            var lcaDist = new Dictionary<int, int>();
            ulong queryResult = 0;
            var visited = new bool[nodeCount + 1];
            if (queryCount <= 1)
            {
                return 0;
            }
            var rootpath1 = new List<int>();
            RootPath(nodes[0], root, rootpath1, neighbours, visited);
            var rootpath2 = new List<int>();
            visited = new bool[nodeCount + 1];
            RootPath(nodes[1], root, rootpath2, neighbours, visited);
            var lca = rootpath1.Intersect(rootpath2).FirstOrDefault();
            if (!lcaDist.ContainsKey(nodes[0]))
            {
                lcaDist[nodes[0]] = rootpath1.Count - rootpath1.IndexOf(lca) - 1;
            }
            else
            {
                lcaDist[nodes[0]] += rootpath1.Count - rootpath1.IndexOf(lca) - 1;
            }
            if (!lcaDist.ContainsKey(nodes[1]))
            {
                lcaDist[nodes[1]] = rootpath2.Count - rootpath2.IndexOf(lca) - 1;
            }
            else
            {
                lcaDist[nodes[1]] += rootpath2.Count - rootpath2.IndexOf(lca) - 1;
            }
            ulong product = 1;
            ulong dist = 0;
            foreach (var item in lcaDist)
            {
                product *= Convert.ToUInt64(item.Key);
                dist += Convert.ToUInt64(item.Value);
            }
            queryResult = product * dist;
            for (int i = 2; i < queryCount; i++)
            {
                rootpath1 = new List<int>();
                visited = new bool[nodeCount + 1];
                RootPath(nodes[i], root, rootpath1, neighbours, visited);
                rootpath2 = new List<int>();
                visited = new bool[nodeCount + 1];
                RootPath(lca, root, rootpath2, neighbours, visited);
                lca = rootpath1.Intersect(rootpath2).FirstOrDefault();
                var tempDist = rootpath1.Count - rootpath1.IndexOf(lca) - 1;
                var keys = new List<int>(lcaDist.Keys);
                foreach (var key in keys)
                {
                    if (lcaDist[key] != lca)
                    {
                        lcaDist[key] += rootpath2.Count - rootpath2.IndexOf(lca) - 1;
                    }
                    queryResult += Convert.ToUInt64(nodes[i]) * Convert.ToUInt64(key) * (Convert.ToUInt64(lcaDist[key]) + Convert.ToUInt64(tempDist));
                }
                lcaDist[nodes[i]] = tempDist;
            }
            return queryResult % 1000000007;
        }

        private bool RootPath(int i, int root, List<int> path, Dictionary<int, HashSet<int>> neighboursDict, bool[] visited)
        {
            visited[root] = true;
            path.Add(root);
            if (root == i)
            {
                return true;
            }
            var neighbours = neighboursDict[root];
            foreach (var neighbour in neighbours)
            {
                if (!visited[neighbour] && neighbour <= i)
                {
                    if (RootPath(i, neighbour, path, neighboursDict, visited))
                    {
                        return true;
                    }
                }
            }
            path.RemoveAt(path.Count - 1);
            return false;
        }

        private long NewCompute(Dictionary<int, HashSet<int>> neighbours, int queryCount, List<int> nodes)
        {
            var neighboursSubset = new List<Tuple<int, int>>();
            long queryResult = 0;
            for (int i = 0; i < queryCount - 1; i++)
            {
                for (int j = i + 1; j < nodes.Count(); j++)
                {
                    var visited = new bool[neighbours.Count + 1];
                    var distance = NewGetDistance(neighbours, nodes[i], nodes[j], visited, 0);
                    queryResult += Convert.ToInt64(nodes[i]) * Convert.ToInt64(nodes[j]) * distance;
                }
            }
            //Console.WriteLine(queryResult % 1000000007);
            return queryResult % 1000000007;
        }

        private int NewGetDistance(Dictionary<int, HashSet<int>> neighbours, int item1, int item2, bool[] visited, int dist)
        {
            var newDist = dist;
            var nearest = neighbours[item1];
            visited[item1] = true;
            if (nearest.Contains(item2))
            {
                return newDist + 1;
            }
            else
            {
                var tempDist = new List<int>();
                foreach (var near in nearest)
                {
                    if (near != item1 && !visited[near])
                    {
                        var hop = NewGetDistance(neighbours, near, item2, visited, dist + 1);
                        if (hop >= 0)
                        {
                            tempDist.Add(hop);
                        }
                    }
                }
                if (tempDist.Count == 0)
                {
                    return -1;
                }
                return tempDist.Max();
            }
        }

        private List<string> ComputeFunction(Dictionary<int, HashSet<int>> neighbours, List<List<Tuple<int, int>>> querySubset)
        {
            var result = new List<string>();
            foreach (var query in querySubset)
            {
                var queryResult = 0;
                foreach (var subset in query)
                {
                    var visited = new bool[neighbours.Count + 1];
                    var distance = GetDistance(neighbours, subset, visited, 0);
                    queryResult += subset.Item1 * subset.Item2 * distance;
                }
                result.Add((queryResult % 1000000007).ToString());
            }

            return result;
        }

        private int GetDistance(Dictionary<int, HashSet<int>> neighbours, Tuple<int, int> subset, bool[] visited, int dist)
        {
            var newDist = dist;
            var nearest = neighbours[subset.Item1];
            visited[subset.Item1] = true;
            if (nearest.Contains(subset.Item2))
            {
                return newDist + 1;
            }
            else
            {
                var tempDist = new List<int>();
                foreach (var near in nearest)
                {
                    if (near != subset.Item1 && !visited[near])
                    {
                        tempDist.Add(GetDistance(neighbours, new Tuple<int, int>(near, subset.Item2), visited, dist + 1));
                    }
                }
                if (tempDist.Count == 0)
                {
                    return -1;
                }
                return tempDist.FirstOrDefault(t => t != -1);
            }
        }

        private List<Tuple<int, int>> GetNodeNeighbourSubset(IList<int> nodes)
        {
            var neighboursSubset = new List<Tuple<int, int>>();
            for (int i = 0; i < nodes.Count() - 1; i++)
            {
                for (int j = i + 1; j < nodes.Count(); j++)
                {
                    neighboursSubset.Add(new Tuple<int, int>(nodes[i], nodes[j]));
                }
            }
            return neighboursSubset;
        }
    }
}
