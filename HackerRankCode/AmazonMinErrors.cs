using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankCode
{
    internal class AmazonMinErrors
    {
        public static void AmazonMinErrorsSol() 
        {
            var str = Console.ReadLine();
            var x = Convert.ToInt32(Console.ReadLine());
            var y = Convert.ToInt32(Console.ReadLine());
            var result=MinErrors(str,x, y);
            Console.WriteLine(result);
        }
        private static int MinErrors(string s, int x, int y)
        {
            int MOD = 1000000007;
            int n = s.Length;
            int[,] dp = new int[n + 1, 2];

            for (int i = 1; i <= n; i++)
            {
                dp[i, 0] = dp[i, 1] = int.MaxValue / 2; // Divide by 2 to avoid overflow
            }
            dp[0, 0] = dp[0, 1] = 0;

            for (int i = 1; i <= n; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    for (int k = 0; k < 2; k++)
                    {
                        if (s[i - 1] == '?' || s[i - 1] == (char)(j + '0'))
                        {
                            int new_j = k;
                            if (i > 1 && j != new_j)
                            {
                                dp[i, new_j] = Math.Min(dp[i, new_j], dp[i - 1, j] + (new_j == 1 ? y : x));
                            }
                            else
                            {
                                dp[i, new_j] = Math.Min(dp[i, new_j], dp[i - 1, j]);
                            }
                        }
                    }
                }
            }

            return Math.Min(dp[n, 0], dp[n, 1]) % MOD;
        }
    }
}
