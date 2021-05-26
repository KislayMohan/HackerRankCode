using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankCode
{
    public class FairRation
    {
        public static void FairRationFlow()
        {
            int N = Convert.ToInt32(Console.ReadLine().Trim());
            List<int> B = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(BTemp => Convert.ToInt32(BTemp)).ToList();
            string result = GetRationCount(B);
            Console.WriteLine(result);
        }

        private static string GetRationCount(List<int> b)
        {
            var sum = b.Aggregate(0, (num1, num2) => num1 + num2);
            if (sum % 2 != 0)
            {
                return "NO";
            }

            var count = 0;
            for (int i = 0; i < b.Count; i++)
            {
                if (b[i] % 2 != 0)
                {
                    b[i]++;
                    b[i + 1]++;
                    count += 2;
                }
            }
            return count.ToString();
        }
    }
}
