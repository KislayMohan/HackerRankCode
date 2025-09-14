using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankCode
{
    internal class DivideSolution
    {
        public int Divide(int dividend, int divisor)
        {
            if (dividend == int.MinValue && divisor == -1)
                return int.MaxValue;
            bool isNegative = (dividend < 0) ^ (divisor < 0);
            long absDividend = Math.Abs((long)dividend);
            long absDivisor = Math.Abs((long)divisor);
            long quotient = 0;
            while (absDividend >= absDivisor)
            {
                long temp = absDivisor, multiple = 1;
                while (absDividend >= (temp << 1))
                {
                    temp <<= 1;
                    multiple <<= 1;
                }
                absDividend -= temp;
                quotient += multiple;
            }
            return isNegative ? (int)-quotient : (int)quotient;
        }
    }
}
