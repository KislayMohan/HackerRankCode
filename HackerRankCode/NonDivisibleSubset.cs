using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankCode
{
    public class NonDivisibleSubset
    {
        public static void NonDivisibleSubsetFlow()
        {
            string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');
            int n = Convert.ToInt32(firstMultipleInput[0]);
            int k = Convert.ToInt32(firstMultipleInput[1]);
            List<int> s = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(sTemp => Convert.ToInt32(sTemp)).ToList();
            int result = FindNonDivisibleSubset(k, s);
            Console.WriteLine(result);
        }

        private static int FindNonDivisibleSubset(int k, List<int> s)
        {
            var bucket = new int[k];
            foreach (var item in s)
            {
                bucket[item % k]++;
            }
            var maxSubset = bucket[0] >= 1 ? 1 : 0; //Pick only 1 number if remainder is 0, as adding other will create divisible pair
            for (int i = 1; i <= k / 2; i++)
            {
                var higher = bucket[i];
                if (k - i == i)
                {
                    higher = bucket[i] >= 1 ? 1 : 0;//Pick only 1 number if remainder is half of k, as adding other will create divisible pair
                }
                else if (bucket[k - i] > bucket[i])
                {
                    higher = bucket[k - i];
                }
                maxSubset += higher;
            }
            return maxSubset;
        }
    }
}
