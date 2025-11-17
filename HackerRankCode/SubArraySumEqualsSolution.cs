using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankCode
{
    internal class SubArraySumEqualsSolution
    {
        public int SubarraySum(int[] nums, int k)
        {
            int count = 0;
            int n = nums.Length;
            for (int start = 0; start < n; start++)
            {
                int sum = 0;
                for (int end = start; end < n; end++)
                {
                    sum += nums[end];
                    if (sum == k)
                    {
                        count++;
                    }
                }
            }
            return count;
        }
    }
}
