using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankCode
{
    internal class PerfectRiceBag
    {
        public static void PerfectRiceBagSol()
        {
            var ricebags = new List<int>(){625,4,2,5,25};
            var result = GetPerfectRiceBag(ricebags);
            Console.WriteLine(result);
        }

        private static int GetPerfectRiceBag(List<int> ricebags)
        {
            int maxRicebag = -1;
            var riceBagDict=new Dictionary<int, int>();
            ricebags.Sort();
            for (int i = 0; i < ricebags.Count; i++)
            {
                var riceSqrt = Math.Sqrt(ricebags[i]);
                if (riceSqrt % 1 == 0)
                {
                    var ricesqrtInt = Convert.ToInt32(riceSqrt);
                    if (riceBagDict.ContainsKey(ricesqrtInt))
                    {
                        riceBagDict[ricebags[i]] = riceBagDict[ricesqrtInt] + 1;
                    }
                    else
                    {
                        riceBagDict[ricebags[i]] = 1;
                    }
                }
                else
                {
                    riceBagDict[ricebags[i]] = 1;
                }
            }
            foreach (var item in riceBagDict)
            {
                if (item.Value > 1 && item.Value > maxRicebag)
                {
                    maxRicebag = item.Value;
                }
            }

            return maxRicebag;
        }
    }
}
