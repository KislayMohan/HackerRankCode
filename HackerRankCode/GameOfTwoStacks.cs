using System;

namespace HackerRankCode
{
    public class GameOfTwoStacks
    {
        public static void GameOfStacks()
        {
            int g = Convert.ToInt32(Console.ReadLine());

            for (int gItr = 0; gItr < g; gItr++)
            {
                string[] nmx = Console.ReadLine().Split(' ');
                int n = Convert.ToInt32(nmx[0]);
                int m = Convert.ToInt32(nmx[1]);
                int x = Convert.ToInt32(nmx[2]);
                int[] a = Array.ConvertAll(Console.ReadLine().Split(' '), aTemp => Convert.ToInt32(aTemp));
                int[] b = Array.ConvertAll(Console.ReadLine().Split(' '), bTemp => Convert.ToInt32(bTemp));
                int result = TwoStacks(x, a, b);
                Console.WriteLine(result);
            }
        }
        public static int TwoStacks(int x, int[] a, int[] b)
        {
            int movesCount = 0, sum = 0;
            int i = 0, j = 0;
            while (i < a.Length && sum + a[i] <= x)
            {
                sum += a[i];
                i++;
            }
            movesCount = i;
            while (j < b.Length && i >= 0)
            {
                sum += b[j];
                j++;
                while (sum > x && i > 0)
                {
                    i--;
                    sum -= a[i];
                }
                if (sum <= x && i + j > movesCount)
                    movesCount = i + j;
            }

            return movesCount;

        }
    }
}
