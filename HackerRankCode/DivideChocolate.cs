using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankCode
{
    internal class DivideChocolate
    {
        public static int MaximizeSweetness(int[] sweetness, int k)
        {
            if (sweetness == null || sweetness.Length == 0 || k < 0)
                return 0;
            int left = sweetness.Min();
            int right = sweetness.Sum() / (k + 1);
            int result = 0;
            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                if (CanDivide(sweetness, mid, k))
                {
                    result = mid; // Found a valid division, try for a larger minimum sweetness
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1; // Try a smaller minimum sweetness
                }
            }
            return result;
        }

        private static bool CanDivide(int[] sweetness, int minSweetness, int k)
        {
            int count = 0;
            int currentSum = 0;
            foreach (var sweet in sweetness)
            {
                currentSum += sweet;
                if (currentSum >= minSweetness)
                {
                    count++; // We can make a piece
                    currentSum = 0; // Reset for the next piece
                }
            }
            return count >= k + 1; // We need at least k + 1 pieces
        }
    }
}
