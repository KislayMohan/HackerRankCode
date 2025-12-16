using System;
using System.Collections.Generic;
using System.Text;

namespace HackerRankCode
{
    internal class ProductExceptSelfSol
    {
        public int[] ProductExceptSelf(int[] nums)
        {
            int n = nums.Length;
            int[] result = new int[n];
            // Calculate left products
            result[0] = 1;
            for (int i = 1; i < n; i++)
            {
                result[i] = result[i - 1] * nums[i - 1];
            }
            // Calculate right products and multiply with left products
            int rightProduct = 1;
            for (int i = n - 1; i >= 0; i--)
            {
                result[i] *= rightProduct;
                rightProduct *= nums[i];
            }
            return result;
        }
    }
}
