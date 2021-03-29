using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankCode
{
    public class RunningMedian
    {
        public static void RunningMedianFlow()
        {
            int aCount = Convert.ToInt32(Console.ReadLine());
            int[] a = new int[aCount];
            for (int aItr = 0; aItr < aCount; aItr++)
            {
                int aItem = Convert.ToInt32(Console.ReadLine());
                a[aItr] = aItem;
            }
            double[] result = SolveRunningMedian(a);
        }

        private static double[] SolveRunningMedian(int[] a)
        {
            var result = new double[a.Length];
            for (int i = 0; i < a.Length; i++)
            {
                if (i == 0)
                {
                    result[i] = a[i];
                    continue;
                }

            }

            return result;
        }
    }
}
