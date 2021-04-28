using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankCode
{
    public class UtopianTree
    {
        public static void UtopianTreeFlow()
        {
            int t = Convert.ToInt32(Console.ReadLine().Trim());
            for (int tItr = 0; tItr < t; tItr++)
            {
                int n = Convert.ToInt32(Console.ReadLine().Trim());
                int result = BuildUtopianTree(n);
                Console.WriteLine(result);
            }
        }

        private static int BuildUtopianTree(int n)
        {
            var initialHeight = 1;
            for (int i = 0; i < n; i++)
            {
                if (i % 2 == 0)
                {
                    initialHeight *= 2;
                }
                else
                {
                    initialHeight++;
                }
            }
            return initialHeight;
        }
    }
}
