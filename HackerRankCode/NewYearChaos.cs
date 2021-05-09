using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankCode
{
    public class NewYearChaos
    {
        public static void NewYearChaosFlow()
        {
            int t = Convert.ToInt32(Console.ReadLine().Trim());
            for (int tItr = 0; tItr < t; tItr++)
            {
                int n = Convert.ToInt32(Console.ReadLine().Trim());
                List<int> q = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(qTemp => Convert.ToInt32(qTemp)).ToList();
                MinimumBribes1(q);
            }
        }

        private static void MinimumBribes1(List<int> q)
        {
            var bribeCount = 0;
            for (int i = q.Count - 1; i >= 0; i--)
            {
                if (q[i] - (i + 1) > 2)
                {
                    Console.WriteLine("Too chaotic");
                    return;
                }
                for (int j = Math.Max(0, q[i] - 2); j < i; j++)
                {
                    if (q[j] > q[i])
                    {
                        bribeCount++;
                    }
                }
            }
            Console.WriteLine(bribeCount);
        }

        private static void MinimumBribes(List<int> q)
        {
            var bribeCount = 0;
            for (int i = q.Count - 1; i >= 0; i--)
            {
                if (q[i] != i + 1)
                {
                    if (q[i - 1] == i + 1)
                    {
                        bribeCount++;
                        Swap(q, i, i - 1);
                    }
                    else if (q[i - 2] == i + 1)
                    {
                        bribeCount += 2;
                        Swap(q, i - 1, i - 2);
                        Swap(q, i - 1, i);
                    }
                    else
                    {
                        Console.WriteLine("Too chaotic");
                        return;
                    }
                }
            }
            Console.WriteLine(bribeCount);
        }

        private static void Swap(List<int> q, int index1, int index2)
        {
            q[index1] = q[index1] + q[index2];
            q[index2] = q[index1] - q[index2];
            q[index1] = q[index1] - q[index2];
        }
    }
}
