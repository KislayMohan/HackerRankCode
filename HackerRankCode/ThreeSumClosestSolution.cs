using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankCode
{
    internal class ThreeSumClosestSolution
    {
        public static int ThreeSumClosest(int[] nums, int target)
        {
            var st = new Stack<char>();
            if(st.Count == 0)
            {
                var val = st.Peek();
            }
            Array.Sort(nums);
            var diff = int.MaxValue;
            var sum = int.MaxValue;
            for (int i = 0; i < nums.Length - 2; i++)
            {
                var low = i + 1;
                var high = nums.Length - 1;
                while (low < high)
                {
                    sum = nums[i] + nums[low] + nums[high];
                    if (Math.Abs(sum - target) < Math.Abs(diff))
                    {
                        diff = target - sum;
                    }
                    if (sum < target)
                    {
                        low++;
                    }
                    else
                    {
                        high--;
                    }
                }
            }

            return target - diff;
        }
    }
}
