using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankCode
{
    internal class KokoEatingBanana
    {
        public static int MinEatingSpeed(int[] piles, int h)
        {
            if (piles == null || piles.Length == 0 || h <= 0)
                return 0;
            int left = 1, right = piles.Max();
            while (left < right)
            {
                int mid = left + (right - left) / 2;
                if (CanEatAll(piles, mid, h))
                {
                    right = mid; // Try a smaller speed
                }
                else
                {
                    left = mid + 1; // Increase speed
                }
            }
            return left; // Minimum speed found
        }

        private static bool CanEatAll(int[] piles, int speed, int h)
        {
            int hours = 0;
            foreach (var pile in piles)
            {
                hours += (int)Math.Ceiling((double)pile / speed);
                if (hours > h) // If it exceeds the allowed hours, return false
                    return false;
            }
            return hours <= h; // Return true if within allowed hours
        }
    }
}
