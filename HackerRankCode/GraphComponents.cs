using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankCode
{
    public class GraphComponents
    {
        public static List<int> componentsInGraph(List<List<int>> gb)
        {
            var smallestSize = 0;
            var largestSize = 0;
            var edges = new Edge(gb.Count * 2);
            foreach (var edge in gb)
            {
                edges.Union(edge[0], edge[1]);
            }
            for (int i = 0; i < gb.Count * 2; i++)
            {
                var size = edges.GetSize(i + 1);
                if (size >= 2)
                {
                    if (smallestSize == 0 && largestSize == 0)
                    {
                        smallestSize = largestSize = size;
                    }
                    else
                    {
                        if (size < smallestSize)
                        {
                            smallestSize = size;
                        }
                        else if (size > largestSize)
                        {
                            largestSize = size;
                        }
                    }
                }
            }

            return new List<int> { smallestSize, largestSize };
        }

        public class Edge
        {
            public int[] Parents { get; set; }
            public int[] Size { get; set; }

            public Edge(int size)
            {
                Parents = new int[size + 1];
                Size = new int[size + 1];
                for (int i = 0; i <= size; i++)
                {
                    Parents[i] = i;
                    Size[i] = 1;
                }
            }

            private int Find(int p)
            {
                int root = p;
                while (root != Parents[root])
                {
                    Parents[root] = Parents[Parents[root]];
                    root = Parents[root];
                }
                return root;
            }

            private bool Connected(int p, int q)
            {
                return Find(p) == Find(q);
            }

            public int GetSize(int p)
            {
                int root = Find(p);
                return Size[root];
            }

            public void Union(int p, int q)
            {
                var rootP = Find(p);
                var rootQ = Find(q);
                if (rootP == rootQ)
                {
                    return;
                }

                if (Size[rootP] < Size[rootQ])
                {
                    Parents[rootP] = rootQ;
                    Size[rootQ] += Size[rootP];
                }
                else
                {
                    Parents[rootQ] = rootP;
                    Size[rootP] += Size[rootQ];
                }
            }
        }
    }
}
