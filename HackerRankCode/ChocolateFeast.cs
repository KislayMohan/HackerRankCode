using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankCode
{
    public class ChocolateFeast
    {
        public static void ChocolateFeastFlow()
        {
            int t = Convert.ToInt32(Console.ReadLine().Trim());
            for (int tItr = 0; tItr < t; tItr++)
            {
                string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');
                int n = Convert.ToInt32(firstMultipleInput[0]);
                int c = Convert.ToInt32(firstMultipleInput[1]);
                int m = Convert.ToInt32(firstMultipleInput[2]);
                int result = GetChocolateCount(n, c, m);
                Console.WriteLine(result);
            }
        }

        private static int GetChocolateCount(int n, int c, int m)
        {
            int chocolateCount = n / c;
            var wrapperCount = chocolateCount;
            while (wrapperCount >= m)
            {
                var tempChocolateCount = wrapperCount / m;
                wrapperCount = tempChocolateCount + (wrapperCount % m);
                chocolateCount += tempChocolateCount;
            }

            return chocolateCount;
        }
    }
}
