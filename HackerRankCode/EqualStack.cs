using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankCode
{
    public class EqualStack
    {
        public static int equalStacks(int[] h1, int[] h2, int[] h3)
        {
            if (h1.Length > 100000 || h2.Length > 100000 || h3.Length > 100000 || h1.Length < 0 || h2.Length < 0 || h3.Length < 0)
            {
                return 0;
            }
            var equalHeight = 0;
            var newArr1 = new List<int>(h1.Length);
            var newArr2 = new List<int>(h2.Length);
            var newArr3 = new List<int>(h3.Length);
            for (int i = h1.Length - 1; i >= 0; i--)
            {
                if (h1[i] > 100 || h1[i] < 0)
                {
                    return 0;
                }
                if (i == h1.Length - 1)
                {
                    newArr1.Add(h1[i]);
                }
                else
                {
                    newArr1.Add(h1[i] + newArr1[newArr1.Count - 1]);
                }
            }
            for (int i = h2.Length - 1; i >= 0; i--)
            {
                if (h2[i] > 100 || h2[i] < 0)
                {
                    return 0;
                }
                if (i == h2.Length - 1)
                {
                    newArr2.Add(h2[i]);
                }
                else
                {
                    newArr2.Add(h2[i] + newArr2[newArr2.Count - 1]);
                }
            }
            for (int i = h3.Length - 1; i >= 0; i--)
            {
                if (h3[i] > 100 || h3[i] < 0)
                {
                    return 0;
                }
                if (i == h3.Length - 1)
                {
                    newArr3.Add(h3[i]);
                }
                else
                {
                    newArr3.Add(h3[i] + newArr3[newArr3.Count - 1]);
                }
            }
            if (newArr1.Count > 0 && newArr2.Count > 0 && newArr3.Count > 0)
            {
                var commnonHeight = newArr1.Intersect(newArr2).Intersect(newArr3);
                if (commnonHeight.Count() > 0)
                {
                    equalHeight = commnonHeight.Max();
                }
            }

            return equalHeight;
        }
    }
}
