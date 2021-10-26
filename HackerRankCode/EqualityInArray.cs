using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankCode
{
    public class EqualityInArray
    {
        public static void EqualityInArraySol()
        {
            int n = Convert.ToInt32(Console.ReadLine().Trim());
            List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();
            int result = EqualizeArray(arr);
            Console.WriteLine(result);
        }

        private static int EqualizeArray(List<int> arr)
        {
            var intDict = new Dictionary<int, int>();
            foreach (var item in arr)
            {
                if (intDict.ContainsKey(item))
                {
                    intDict[item] = intDict[item] + 1;
                }
                else
                {
                    intDict[item] = 1;
                }
            }
            var maxCounter = 0;
            foreach (var val in intDict.Values)
            {
                if (maxCounter < val)
                {
                    maxCounter = val;
                }
            }

            return arr.Count - maxCounter;
        }
    }
}
