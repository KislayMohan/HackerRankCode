using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankCode
{
    internal class MergeIntervalsSol
    {
        public static int[][] Merge(int[][] intervals)
        {
            if (intervals.Length == 0)
            {
                return new int[0][];
            }
            Array.Sort(intervals, (a, b) => a[0].CompareTo(b[0]));
            List<int[]> merged = new List<int[]>();
            int[] currentInterval = intervals[0];
            merged.Add(currentInterval);
            foreach (var interval in intervals)
            {
                if (interval[0] <= currentInterval[1])
                {
                    currentInterval[1] = Math.Max(currentInterval[1], interval[1]);
                }
                else
                {
                    currentInterval = interval;
                    merged.Add(currentInterval);
                }
            }
            return merged.ToArray();
        }
    }
}
