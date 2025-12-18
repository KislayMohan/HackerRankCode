using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace HackerRankCode
{
    internal class ConcatenateNonZeroDigitsandMultiplybySum
    {
        public long ConcatenateAndMultiply(int[] digits)
        {
            StringBuilder concatenatedNumber = new StringBuilder();
            int sum = 0;
            foreach (var digit in digits)
            {
                if (digit != 0)
                {
                    concatenatedNumber.Append(digit);
                }
                sum += digit;
            }
            long concatenatedValue = concatenatedNumber.Length > 0 ? long.Parse(concatenatedNumber.ToString()) : 0;
            return concatenatedValue * sum;
        }

        public int[] SumAndMultiply(string s, int[][] queries)
        {
            int[] results = new int[queries.Length];
            for (int i = 0; i < queries.Length; i++)
            {
                int left = queries[i][0];
                int right = queries[i][1];
                List<int> subDigits = new List<int>();
                for (int j = left; j <= right; j++)
                {
                    subDigits.Add(s[j] - '0');
                }
                results[i] = (int)(ConcatenateAndMultiply(subDigits.ToArray()) % 1000000007);
            }
            return results;
        }

        public int[] SumAndMultiply1(string s, int[][] queries)
        {
            int[] results = new int[queries.Length];
            for (int i = 0; i < queries.Length; i++)
            {
                int left = queries[i][0];
                int right = queries[i][1];
                int power = 0, sum = 0;
                BigInteger finalNumber = new BigInteger();
                for (int j = right; j >= left; j--)
                {
                    if (s[j] != '0')
                    {
                        int digit = s[j] - '0';
                        finalNumber += (ulong)Math.Pow(10, power) * (ulong)digit;
                        sum += digit;
                        power++;
                    }
                }
                finalNumber = finalNumber * sum;
                results[i] = (int)(finalNumber % 1000000007);
            }
            return results;
        }
    }
}
