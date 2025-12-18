using System;
using System.Collections.Generic;
using System.Text;

namespace HackerRankCode
{
    internal class FourSumSolution
    {
        public static List<List<int>> FourSum(int[] nums, int target)
        {
            Array.Sort(nums);
            List<List<int>> result = new List<List<int>>();
            for (int i = 0; i < nums.Length - 3; i++)
            {
                if (i == 0 || (nums[i] != nums[i - 1]))
                {
                    for (int j = i + 1; j < nums.Length - 2; j++)
                    {
                        if (j == i + 1 || (nums[j] != nums[j - 1]))
                        {
                            int low = j + 1;
                            int high = nums.Length - 1;
                            int sum = target - nums[i] - nums[j];
                            while (low < high)
                            {
                                if (nums[low] + nums[high] == sum)
                                {
                                    result.Add(new List<int> { nums[i], nums[j], nums[low], nums[high] });
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
                }
            }
            return result;
        }
    }
}
