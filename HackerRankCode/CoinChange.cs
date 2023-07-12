namespace HackerRankCode
{
    internal class CoinChange
    {
        /*
         * 
        n=3
        c=[8,3,1,2]
        There are 3 ways to make change for n=3: {1,1,1},{1,2} and {3}
         */
        public static void CoinChangeSol()
        {
            string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');
            int n = Convert.ToInt32(firstMultipleInput[0]);
            int m = Convert.ToInt32(firstMultipleInput[1]);
            List<long> c = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(cTemp => Convert.ToInt64(cTemp)).ToList();
            long ways = GetWays(n, c);

            Console.WriteLine(ways);
        }

        private static long GetWays(int n, List<long> c)
        {
            long[] combination = new long[n + 1];
            combination[0] = 1;
            for (int i = 0; i < c.Count; i++)
            {
                for (long j = c[i]; j < n + 1; j++)
                {
                    combination[j] += combination[j - c[i]];
                }
            }
            return combination[n];
        }
    }
}
