using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankCode
{
    public class SubArrayDivision
    {
        public static void SubArrayDivisionFlow()
        {
            int n = Convert.ToInt32(Console.ReadLine().Trim());
            List<int> s = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(sTemp => Convert.ToInt32(sTemp)).ToList();
            string[] dm = Console.ReadLine().TrimEnd().Split(' ');
            int d = Convert.ToInt32(dm[0]);
            int m = Convert.ToInt32(dm[1]);
            int result = birthday(s, d, m);
            Console.WriteLine(result);
        }

        private static int birthday(List<int> s, int d, int m)
        {
            var groupCount = 0;
            for (int i = 0; i < s.Count; i++)
            {
                var sum = s[i];
                for (int j = i + 1; j < i + m && j < s.Count; j++)
                {
                    sum += s[j];
                }
                if (sum == d)
                {
                    groupCount++;
                }
            }
            return groupCount;
        }
    }
}
