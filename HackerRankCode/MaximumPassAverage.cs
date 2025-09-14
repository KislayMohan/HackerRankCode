using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankCode
{
    internal class MaximumPassAverage
    {
        public double MaxAverageRatio(int[][] classes, int extraStudents)
        {
            var pq = new PriorityQueue<(int pass, int total), double>();
            foreach (var c in classes)
            {
                var pass = c[0];
                var total = c[1];
                var diff = (double)(pass + 1) / (total + 1) - (double)pass / total;
                pq.Enqueue((pass, total), -diff);
            }
            for (int i = 0; i < extraStudents; i++)
            {
                var (pass, total) = pq.Dequeue();
                pass++;
                total++;
                var diff = (double)(pass + 1) / (total + 1) - (double)pass / total;
                pq.Enqueue((pass, total), -diff);
            }
            double result = 0;
            while (pq.Count > 0)
            {
                var (pass, total) = pq.Dequeue();
                result += (double)pass / total;
            }
            return result / classes.Length;
        }
    }
}
