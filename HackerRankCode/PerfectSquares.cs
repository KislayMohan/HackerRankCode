namespace HackerRankCode
{
    internal class PerfectSquares
    {
        public int NumSquares(int n)
        {
            if (n <= 0) return 0;
            var dp = new int[n + 1];
            for (int i = 1; i <= n; i++)
            {
                dp[i] = int.MaxValue;
                var t = dp.Count();
                for (int j = 1; j * j <= i; j++)
                {
                    dp[i] = Math.Min(dp[i], dp[i - j * j] + 1);
                }
            }
            return dp[n];
        }
    }
}
