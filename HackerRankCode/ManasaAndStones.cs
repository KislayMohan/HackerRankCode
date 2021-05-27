using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankCode
{
    public class ManasaAndStones
    {
        public static void ManasaAndStonesFlow()
        {
            int T = Convert.ToInt32(Console.ReadLine().Trim());
            for (int TItr = 0; TItr < T; TItr++)
            {
                int n = Convert.ToInt32(Console.ReadLine().Trim());
                int a = Convert.ToInt32(Console.ReadLine().Trim());
                int b = Convert.ToInt32(Console.ReadLine().Trim());
                List<int> result = Stones(n, a, b);
                Console.WriteLine(String.Join(" ", result));
            }
        }

        private static List<int> Stones(int n, int a, int b)
        {
            var result = new HashSet<int>();
            var smaller = Math.Min(a, b);
            int larger = Math.Max(a, b);
            for (int i = n - 1; i >= 0; i--)
            {
                result.Add((smaller * i) + (larger * (n - 1 - i)));
            }

            return result.ToList();
        }
    }
}
