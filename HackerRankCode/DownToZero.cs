using System;
using System.Collections.Generic;

namespace HackerRankCode
{
    public static class DownToZero
    {
        public static void DownToZeroSol()
        {
            int q = Convert.ToInt32(Console.ReadLine().Trim());
            for (int qItr = 0; qItr < q; qItr++)
            {
                int n = Convert.ToInt32(Console.ReadLine().Trim());
                int result = MinMove_1(n);
                Console.WriteLine(result);
            }
        }

        private static int MinMove_1(int n)
        {
            if (n <= 3) return n;
            var check = new HashSet<int>();
            var queue = new Queue<Tuple<int, int>>();
            int moves = 0;
            queue.Enqueue(new Tuple<int, int>(n, moves));
            while (queue.Count > 0)
            {
                var data = queue.Dequeue();
                n = data.Item1;
                moves = data.Item2;

                if (n <= 1)
                {
                    if (n == 1)
                    {
                        moves++;
                    }
                    break;
                }

                if (!check.Contains(n - 1))
                {
                    check.Add(n - 1);
                    queue.Enqueue(new Tuple<int, int>(n - 1, moves + 1));
                }
                for (int i = (int)Math.Sqrt(n); i >= 2; i--)
                {
                    if (n % i == 0)
                    {
                        var factor = Math.Max(n / i, i);
                        if (!check.Contains(factor))
                        {
                            check.Add(factor);
                            queue.Enqueue(new Tuple<int, int>(factor, moves + 1));
                        }
                    }
                }
            }

            return moves;
        }
    }
}
