using System;
using System.Collections.Generic;
using System.Linq;

namespace HackerRankCode
{
    public class JumpingOnTheClouds
    {
        public static void JumpingOnTheCloudsSol()
        {
            int n = Convert.ToInt32(Console.ReadLine().Trim());
            List<int> c = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(cTemp => Convert.ToInt32(cTemp)).ToList();
            int result = JumpingOnClouds(c);
            Console.WriteLine(result);
        }

        private static int JumpingOnClouds(List<int> c)
        {
            int steps = 0, currentPos = 0;
            while (currentPos != c.Count - 1)
            {
                if (currentPos + 2 < c.Count && c[currentPos + 2] == 0)
                {
                    currentPos += 2;
                }
                else
                {
                    currentPos++;
                }
                steps++;
            }
            return steps;
        }
    }
}
