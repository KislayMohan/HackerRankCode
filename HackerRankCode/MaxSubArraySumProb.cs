using System;

namespace HackerRankCode
{
    public class MaxSubArraySumProb
    {
        public static void MaxSubArraySumSol()
        {
            var val = MaxSubArraySum(new int[4] { -1, -2, -3, -4 });
            Console.WriteLine(val);
            Console.ReadLine();
        }

        private static int MaxSubArraySum(int[] a)
        {
            int size = a.Length;
            int max_so_far = int.MinValue,
                max_ending_here = 0;

            for (int i = 0; i < size; i++)
            {
                max_ending_here = max_ending_here + a[i];

                if (max_so_far < max_ending_here)
                    max_so_far = max_ending_here;

                if (max_ending_here < 0)
                    max_ending_here = 0;
            }

            return max_so_far;
        }
    }
}
