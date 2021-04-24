using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankCode
{
    public class DivisibleSumPairs
    {
        public static void DivisibleSumPairsFlow()
        {
            string[] nk = Console.ReadLine().Split(' ');
            int n = Convert.ToInt32(nk[0]);
            int k = Convert.ToInt32(nk[1]);
            int[] ar = Array.ConvertAll(Console.ReadLine().Split(' '), arTemp => Convert.ToInt32(arTemp));
            int result = SumPairs(n, k, ar);
            Console.WriteLine(result);
        }

        private static int SumPairs(int n, int k, int[] ar)
        {
            var count = 0;
            int[] bucket = new int[k];
            for (int i = 0; i < k; i++)
            {
                bucket[i] = 0;
            }
            for (int i = 0; i < ar.Length; i++)
            {
                var modVal = ar[i] % k;
                bucket[modVal]++;
            }
            count += (bucket[0] * (bucket[0] - 1)) / 2;
            for (int i = 1; i <= k / 2 && i != k - i; i++)
            {
                count += bucket[i] * bucket[k - i];
            }
            if (k % 2 == 0)
            {
                count += (bucket[k / 2] * (bucket[k / 2] - 1)) / 2;
            }
            return count;
        }
    }
}
