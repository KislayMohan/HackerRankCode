using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankCode
{
    public class FindDigits
    {
        public static void FindDigitsFlow()
        {
            int t = Convert.ToInt32(Console.ReadLine().Trim());
            for (int tItr = 0; tItr < t; tItr++)
            {
                int n = Convert.ToInt32(Console.ReadLine().Trim());
                int result = FindDigitsDivisor(n);
                Console.WriteLine(result);
            }
        }

        private static int FindDigitsDivisor(int n)
        {
            int divisorCount = 0;
            var tempNum = n;
            while (tempNum > 0)
            {
                var divisor = tempNum % 10;
                if (divisor != 0 && n % divisor == 0)
                {
                    divisorCount++;
                }
                tempNum /= 10;
            }

            return divisorCount;
        }
    }
}
