using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankCode
{
    internal class RotatedSortedArray
    {
        public static int Search(int[] nums, int target)
        {
            if (nums == null || nums.Length == 0)
                return -1;
            int left = 0, right = nums.Length - 1;
            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                if (nums[mid] == target)
                    return mid;
                // Determine which side is sorted
                if (nums[left] <= nums[mid]) // Left side is sorted
                {
                    if (nums[left] <= target && target < nums[mid])
                        right = mid - 1; // Target is in the left sorted part
                    else
                        left = mid + 1; // Target is in the right part
                }
                else // Right side is sorted
                {
                    if (nums[mid] < target && target <= nums[right])
                        left = mid + 1; // Target is in the right sorted part
                    else
                        right = mid - 1; // Target is in the left part
                }
            }
            return -1; // Target not found
        }
    }
}
