using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankCode
{
    internal class RainTapping
    {
        public static void RainTappingSol()
        {
            int[] arr = { 3, 0, 2, 0, 4 };
            Console.Write(maxWater(arr));
        }

        private static int maxWater(int[] height)
        {
            // Stores the indices of the bars 
            Stack stack = new Stack();

            // size of the array 
            int n = height.Length;

            // Stores the final result 
            int ans = 0;

            // Loop through the each bar 
            for (int i = 0; i < n; i++)
            {

                // Remove bars from the stack 
                // until the condition holds 
                while ((stack.Count != 0)
                    && (height[(int)stack.Peek()]
                        < height[i]))
                {

                    // store the height of the top 
                    // and pop it. 
                    int pop_height = height[(int)stack.Peek()];
                    stack.Pop();

                    // If the stack does not have any 
                    // bars or the popped bar 
                    // has no left boundary 
                    if (stack.Count == 0)
                        break;

                    // Get the distance between the 
                    // left and right boundary of 
                    // popped bar 
                    int distance = i - (int)stack.Peek() - 1;

                    // Calculate the min. height 
                    int min_height
                        = Math.Min(height[(int)stack.Peek()],
                                height[i])
                        - pop_height;

                    ans += distance * min_height;
                }

                // If the stack is either empty or 
                // height of the current bar is less than 
                // or equal to the top bar of stack 
                stack.Push(i);
            }
            return ans;
        }
    }
}
