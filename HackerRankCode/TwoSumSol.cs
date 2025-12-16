using System;
using System.Collections.Generic;
using System.Text;

namespace HackerRankCode
{
    internal class TwoSumSol
    {
        public int[] TwoSum(int[] nums, int target)
        {
            Dictionary<int, int> numDict = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                int complement = target - nums[i];
                if (numDict.ContainsKey(complement))
                {
                    return new int[] { numDict[complement] + 1, i + 1 };
                }
                if (!numDict.ContainsKey(nums[i]))
                {
                    numDict[nums[i]] = i;
                }
            }
            return new int[] { -1, -1 }; // Return an invalid pair if no solution is found
        }
    }
}
