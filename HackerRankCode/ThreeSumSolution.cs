using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankCode
{
    internal class ThreeSumSolution
    {
        public static List<List<int>> ThreeSum(int[] nums)
        {
            Array.Sort(nums);
            List<List<int>> result = new List<List<int>>();

            for (int i = 0; i < nums.Length - 2; i++)
            {
                if (i == 0 || (nums[i] != nums[i - 1]))
                {
                    var low = i + 1;
                    var high = nums.Length - 1;
                    var sum = 0 - nums[i];
                    while (low < high)
                    {
                        if (nums[low] + nums[high] == sum)
                        {
                            result.Add(new List<int> { nums[i], nums[low], nums[high] });
                            while (low < high && nums[low] == nums[low + 1])
                            {
                                low++;
                            }
                            while (low < high && nums[high] == nums[high - 1])
                            {
                                high--;
                            }
                            low++;
                            high--;
                        }
                        else if (nums[low] + nums[high] > sum)
                        {
                            high--;
                        }
                        else
                        {
                            low++;
                        }
                    }
                }
            }

            return result;
        }
    }
}
