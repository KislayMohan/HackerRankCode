using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankCode
{
    internal class NextPermutationSolution
    {
        public void NextPermutation(int[] nums)
        {
            int n = nums.Length;
            int i = n - 2;
            while (i >= 0 && nums[i] >= nums[i + 1])
                i--;
            if (i >= 0)
            {
                int j = i + 1;
                while (nums[j] > nums[i] && j < n)
                    j++;
                Swap(nums, i, j - 1);
            }
            Reverse(nums, i + 1, n - 1);
        }
        private void Swap(int[] nums, int i, int j)
        {
            int temp = nums[i];
            nums[i] = nums[j];
            nums[j] = temp;
        }
        private void Reverse(int[] nums, int start, int end)
        {
            while (start < end)
            {
                Swap(nums, start, end);
                start++;
                end--;
            }
        }
    }
}
