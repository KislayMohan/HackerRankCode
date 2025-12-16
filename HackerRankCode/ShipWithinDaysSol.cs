using System;
using System.Collections.Generic;
using System.Text;

namespace HackerRankCode
{
    internal class ShipWithinDaysSol
    {
        public int ShipWithinDays(int[] weights, int days)
        {
            int left = 0;
            int right = 0;
            foreach (int weight in weights)
            {
                left = Math.Max(left, weight);
                right += weight;
            }
            while (left < right)
            {
                int mid = left + (right - left) / 2;
                if (CanShip(weights, days, mid))
                {
                    right = mid;
                }
                else
                {
                    left = mid + 1;
                }
            }
            return left;
        }

        private bool CanShip(int[] weights, int days, int mid)
        {
            int currentLoad = 0;
            int requiredDays = 1;
            foreach (int weight in weights)
            {
                if (currentLoad + weight > mid)
                {
                    requiredDays++;
                    currentLoad = 0;
                }
                currentLoad += weight;
            }
            return requiredDays <= days;
        }
    }
}
