using System;
using System.Collections.Generic;
using System.Text;

namespace HackerRankCode
{
    internal class EarliestAcquaintance
    {
        public int EarliestAcquaintanceDay(int[][] logs, int n)
        {
            Array.Sort(logs, (a, b) => a[0].CompareTo(b[0]));
            UnionFind uf = new UnionFind(n);
            foreach (var log in logs)
            {
                int personA = log[1];
                int personB = log[2];
                int day = log[0];
                uf.Union(personA, personB);
                if (uf.GetComponentSize(0) == n)
                {
                    return day;
                }
            }
            return -1;
        }
    }
}
