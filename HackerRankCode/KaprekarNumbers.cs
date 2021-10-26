using System;
using System.Collections.Generic;
using System.Linq;

namespace HackerRankCode
{
    public class KaprekarNumbers
    {
        public static void KaprekarNumbersFlow()
        {
            int p = Convert.ToInt32(Console.ReadLine().Trim());
            int q = Convert.ToInt32(Console.ReadLine().Trim());
            KaprekarNumber(p, q);
        }

        private static void KaprekarNumber(int p, int q)
        {
            var kaprekarNum = new List<int>();
            for (int i = p; i <= q; i++)
            {
                var digit = i.ToString().Length;
                var sqr = Math.Pow(i, 2);
                var right = (sqr % Math.Pow(10, digit));
                var left = Math.Floor(sqr / Math.Pow(10, digit));
                if (left + right == i)
                {
                    kaprekarNum.Add(i);
                }
            }
            if (kaprekarNum.Any())
            {
                Console.WriteLine(string.Join(' ', kaprekarNum));
            }
            else
            {
                Console.WriteLine("INVALID RANGE");
            }
        }
    }
}