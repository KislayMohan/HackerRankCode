using System;
using System.Collections.Generic;
using System.Text;

namespace HackerRankCode
{
    internal class GreatestSumDivisibleByThree
    {
        public int MaxSumDivThree(int[] nums)
        {
            int totalSum = 0;
            List<int> mod1 = new List<int>();
            List<int> mod2 = new List<int>();
            foreach (var num in nums)
            {
                totalSum += num;
                if (num % 3 == 1)
                {
                    mod1.Add(num);
                }
                else if (num % 3 == 2)
                {
                    mod2.Add(num);
                }
            }
            mod1.Sort();
            mod2.Sort();
            if (totalSum % 3 == 1)
            {
                int option1 = (mod1.Count >= 1) ? mod1[0] : int.MaxValue;
                int option2 = (mod2.Count >= 2) ? mod2[0] + mod2[1] : int.MaxValue;
                totalSum -= Math.Min(option1, option2);
            }
            else if (totalSum % 3 == 2)
            {
                int option1 = (mod2.Count >= 1) ? mod2[0] : int.MaxValue;
                int option2 = (mod1.Count >= 2) ? mod1[0] + mod1[1] : int.MaxValue;
                totalSum -= Math.Min(option1, option2);
            }
            return totalSum;
        }
    }
}
