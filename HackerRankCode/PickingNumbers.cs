using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankCode
{
    public class PickingNumbers
    {
        public static void PickingNumberFlow()
        {
            int n = Convert.ToInt32(Console.ReadLine().Trim());
            List<int> a = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(aTemp => Convert.ToInt32(aTemp)).ToList();
            int result = PickingSubArray(a);
            Console.WriteLine(result);
        }

        private static int PickingSubArray(List<int> a)
        {
            var maxElem = a[0];
            var lookUp = new int[100]; // as the problem states there can be maximum 100 elements.
            foreach (var item in a)
            {
                lookUp[item]++;
                if (item > maxElem)
                {
                    maxElem = item;
                }
            }

            var maxSize = 0;
            for (int i = 1; i <= maxElem; i++)
            {
                if (lookUp[i - 1] + lookUp[i] > maxSize)
                {
                    maxSize = lookUp[i - 1] + lookUp[i];
                }
            }
            return maxSize;
        }
    }
}
