using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankCode
{
    public class ChocolateDistribution
    {
        public static void ChocolateDistributionSol()
        {
            int t = Convert.ToInt32(Console.ReadLine().Trim());

            for (int tItr = 0; tItr < t; tItr++)
            {
                int n = Convert.ToInt32(Console.ReadLine().Trim());

                List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

                int result = Distribute(arr);

                Console.WriteLine(result);
            }
        }

        private static int Distribute(List<int> arr)
        {
            int diff = 0, temp = 0;
            var rounds = int.MaxValue;
            var min = int.MaxValue;
            foreach (var item in arr)
            {
                if (item < min)
                {
                    min = item;
                }
            }
            
            for (int i = min; i > min - 3; i--)
            {
                temp= 0;
                foreach (var item in arr)
                {
                    diff = item - i;
                    temp += (diff / 5) + ((diff % 5) / 2) + (diff % 5 % 2);
                }
                rounds = temp < rounds ? temp : rounds;
            }

            return rounds;
        }
    }
}
