using System;
using System.Collections.Generic;
using System.Text;

namespace HackerRankCode
{
    internal class CanSeePersonsCountSol
    {
        public int[] CanSeePersonsCount(int[] heights)
        {
            int n = heights.Length;
            int[] result = new int[n];
            Stack<int> stack = new Stack<int>();
            for (int i = n - 1; i >= 0; i--)
            {
                while (stack.Count > 0 && heights[i] > heights[stack.Peek()])
                {
                    stack.Pop();
                    result[i]++;
                }
                if (stack.Count > 0)
                {
                    result[i]++;
                }
                stack.Push(i);
            }
            return result;
        }
    }
}
