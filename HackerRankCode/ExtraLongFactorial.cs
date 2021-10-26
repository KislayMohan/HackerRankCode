using System;
using System.Numerics;

namespace HackerRankCode
{
    public class ExtraLongFactorial
    {
        public static void ExtraLongFactorialSol()
        {
            int n = Convert.ToInt32(Console.ReadLine().Trim());
            ExtraLongFactorials(n);
        }

        private static void ExtraLongFactorials(int n)
        {
            var result = GetFactorial(n);
            Console.WriteLine(result);
        }

        private static BigInteger GetFactorial(BigInteger num)
        {
            if (num == 1)
            {
                return 1;
            }
            else
            {
                return num * GetFactorial(num - 1);
            }
        }
    }
}
