using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankCode
{
    internal class FirstAndLastPositionOfElementSolution
    {
        public int[] SearchRange(int[] nums, int target)
        {
            int left = 0, right = nums.Length - 1;
            int first = -1, last = -1;
            // Find the first occurrence
            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                if (nums[mid] == target)
                {
                    first = mid;
                    right = mid - 1; // Continue searching in the left half
                }
                else if (nums[mid] < target)
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }
            if (first == -1) // Target not found
                return new int[] { -1, -1 };
            left = 0;
            right = nums.Length - 1;
            // Find the last occurrence
            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                if (nums[mid] == target)
                {
                    last = mid;
                    left = mid + 1; // Continue searching in the right half
                }
                else if (nums[mid] < target)
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }
            return new int[] { first, last };
        }
    }
}
