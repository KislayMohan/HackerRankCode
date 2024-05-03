using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankCode
{
    internal class VendorStall
    {
        public static void VendorStallSol()
        {
            var stallInput = Console.ReadLine();
            var stallsPos = stallInput.Split(' ').Select(a => Convert.ToInt32(a)).ToArray();
            var vendors = Convert.ToInt32(Console.ReadLine());
            var stallDistance = Convert.ToInt32(Console.ReadLine());

            var result = SafeVendorSetup(stallsPos, vendors, stallDistance);
        }

        private static bool SafeVendorSetup(int[] stallsPos, int vendors, int stallDistance)
        {
            Array.Sort(stallsPos);
            if (vendors < 1 || stallsPos.Length == 0)
            {
                return true;
            }
            vendors--;
            var prevStallPos = stallsPos[0];
            for (int i = 1; i < stallsPos.Length; i++)
            {
                if (stallsPos[i] - prevStallPos < stallDistance)
                {
                    continue;
                }
                vendors--;
                prevStallPos = stallsPos[i];
                if (vendors == 0)
                {
                    break;
                }
            }
            if (vendors > 0)
            {
                return false;
            }
            return true;
        }
    }
}
