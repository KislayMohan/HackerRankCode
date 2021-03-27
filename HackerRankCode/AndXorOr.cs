using System;
using System.Collections.Generic;
using System.Linq;

namespace HackerRankCode
{
    public class AndXorOrSol
    {
        public static void AndXorOrData()
        {
            int aCount = Convert.ToInt32(Console.ReadLine());
            int[] a = Array.ConvertAll(Console.ReadLine().Split(' '), aTemp => Convert.ToInt32(aTemp));
            int result = AndXorOr(a);
            Console.WriteLine(result);
        }

        private static int AndXorOr(int[] a)
        {
            var max = 0;
            var numStack = new Stack<int>();
            foreach (var num in a)
            {
                while (numStack.Count() > 0)
                {
                    var result = num ^ numStack.Peek();
                    if (result > max)
                    {
                        max = result;
                    }
                    if (num < numStack.Peek())
                    {
                        numStack.Pop();
                    }
                    else
                    {
                        break;
                    }
                }
                numStack.Push(num);
            }
            return max;
        }
    }
}
