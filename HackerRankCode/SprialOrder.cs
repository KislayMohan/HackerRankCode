using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankCode
{
    internal class SprialOrder
    {
        public static IList<int> SpiralOrder(int[][] matrix)
        {
            if (matrix == null || matrix.Length == 0 || matrix[0].Length == 0)
                return new List<int>();
            int rows = matrix.Length;
            int cols = matrix[0].Length;
            List<int> result = new List<int>();
            int top = 0, bottom = rows - 1, left = 0, right = cols - 1;
            while (top <= bottom && left <= right)
            {
                // Traverse from left to right
                for (int i = left; i <= right; i++)
                {
                    result.Add(matrix[top][i]);
                }
                top++;
                // Traverse from top to bottom
                for (int i = top; i <= bottom; i++)
                {
                    result.Add(matrix[i][right]);
                }
                right--;
                if (top <= bottom)
                {
                    // Traverse from right to left
                    for (int i = right; i >= left; i--)
                    {
                        result.Add(matrix[bottom][i]);
                    }
                    bottom--;
                }
                if (left <= right)
                {
                    // Traverse from bottom to top
                    for (int i = bottom; i >= top; i--)
                    {
                        result.Add(matrix[i][left]);
                    }
                    left++;
                }
            }
            return result;
        }
    }
}
