using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankCode
{
    internal class MaxValueOfCoinFromPiles
    {
        public static int MaxValueOfCoins(IList<IList<int>> piles, int k)
        {
            int n = piles.Count;
            // dp[i][j] represents the maximum value we can get from the first i piles with j coins
            int[,] dp = new int[n + 1, k + 1];
            for (int i = 1; i <= n; i++)
            {
                for (int j = 0; j <= k; j++)
                {
                    // Calculate the maximum value without taking any coins from the current pile
                    dp[i, j] = dp[i - 1, j];
                    // Try taking coins from the current pile
                    int currentPileSize = piles[i - 1].Count;
                    int currentSum = 0;
                    for (int x = 0; x < Math.Min(currentPileSize, j); x++)
                    {
                        currentSum += piles[i - 1][x];
                        dp[i, j] = Math.Max(dp[i, j], dp[i - 1, j - x - 1] + currentSum);
                    }
                }
            }
            return dp[n, k];
        }
    }
}
