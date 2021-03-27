using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankCode
{
    public class LargestRectangle
    {
        public static long largestRectangle(int[] h)
        {
            long largestRect = 0;
            int counter = 0;
            var positionStack = new Stack<int>();
            var heightStack = new Stack<int>();
            for (int i = 0; i < h.Length; i++)
            {
                if (heightStack.Count == 0 || heightStack.Peek() < h[i])
                {
                    heightStack.Push(h[i]);
                    positionStack.Push(i);
                }
                else
                {
                    var position = -1;
                    while (heightStack.Count > 0 && heightStack.Peek() >= h[i])
                    {
                        var height = heightStack.Pop();
                        position = positionStack.Pop();
                        var area = height * (counter - position);
                        if (area > largestRect)
                        {
                            largestRect = area;
                        }
                    }
                    heightStack.Push(h[i]);
                    positionStack.Push(position);
                }
                counter++;
            }
            while (positionStack.Count > 0)
            {
                var height = heightStack.Pop();
                var position = positionStack.Pop();
                var area = height * (counter - position);
                if (area > largestRect)
                {
                    largestRect = area;
                }
            }

            return largestRect;
        }
    }
}
