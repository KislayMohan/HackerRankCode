using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankCode
{
    internal class HouseRob
    {
        public static int Rob(int[] nums)
        {
            int N = nums.Length;

            if (N == 0)
            {
                return 0;
            }
            if (N == 1)
            {
                return nums[0];
            }

            int nextRob = nums[0];
            int nextRobPlusOne = Math.Max(nums[0], nums[1]);

            for (int i = 2; i < N; i++)
            {
                int current = Math.Max( nextRobPlusOne, nextRob + nums[i]);
                nextRob = nextRobPlusOne;
                nextRobPlusOne = current;
            }

            return nextRobPlusOne;
        }
    }
}
