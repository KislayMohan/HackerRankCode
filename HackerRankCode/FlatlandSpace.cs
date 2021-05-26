using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankCode
{
    public class FlatlandSpace
    {
        public static void FlatlandSpaceFlow()
        {
            string[] nm = Console.ReadLine().Split(' ');
            int n = Convert.ToInt32(nm[0]);
            int m = Convert.ToInt32(nm[1]);
            int[] c = Array.ConvertAll(Console.ReadLine().Split(' '), cTemp => Convert.ToInt32(cTemp));
            int result = FlatlandSpaceStations(n, c);
            Console.WriteLine(result);
        }

        private static int FlatlandSpaceStations(int n, int[] c)
        {
            int max = 0;
            Array.Sort(c);
            for (int i = 1; i < c.Length - 1; i++)
            {
                var tempDist = (c[i] - c[i - 1]) / 2;
                if (tempDist > max)
                {
                    max = tempDist;
                }
            }

            if (c[0] > max)
            {
                max = c[0];
            }
            if (n - 1 - c[c.Length - 1] > max)
            {
                max = n - 1 - c[c.Length - 1];
            }

            return max;
        }
    }
}
