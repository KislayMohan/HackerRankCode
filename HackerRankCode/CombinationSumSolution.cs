using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankCode
{
    internal class CombinationSumSolution
    {
        public IList<IList<int>> CombinationSum(IList<int> nums, int target)
        {
            List<IList<int>> combinations = new List<IList<int>>();
            DepthSearch(combinations, nums, target, 0, new List<int> ());
            return combinations;
        }

        private void DepthSearch(List<IList<int>> combinations, IList<int> nums, int remain, int start, List<int> currentCombo)
        {
            if (remain == 0)
            {
                combinations.Add(new List<int> (currentCombo));
                return;
            }
            if (remain < 0)
            {
                return;
            }

            for (int i = start; i < nums.Count; i++)
            {
                currentCombo.Add(nums[i]);
                DepthSearch(combinations, nums, remain - nums[i], i, currentCombo);
                currentCombo.RemoveAt(currentCombo.Count - 1);
            }
        }
    }
}
