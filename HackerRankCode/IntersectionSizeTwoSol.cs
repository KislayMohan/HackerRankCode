using System;
using System.Collections.Generic;
using System.Text;

namespace HackerRankCode
{
    internal class IntersectionSizeTwoSol
    {
        public int IntersectionSizeTwo(int[][] intervals)
        {
            Array.Sort(intervals, (a, b) =>
            {
                if (a[1] != b[1])
                    return a[1].CompareTo(b[1]);
                return b[0].CompareTo(a[0]);
            });
            int count = 0;
            int secondLast = -1;
            int last = -1;
            foreach (var interval in intervals)
            {
                int start = interval[0];
                int end = interval[1];
                if (secondLast >= start)
                    continue;
                else if (last >= start)
                {
                    secondLast = last;
                    last = end;
                    count++;
                }
                else
                {
                    secondLast = end - 1;
                    last = end;
                    count += 2;
                }
            }
            return count;
        }
    }
}
