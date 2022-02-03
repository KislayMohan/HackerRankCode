using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankCode
{
    public class AbsolutePermutation
    {
        public static void AbsolutePermutationSol()
        {
            int t = Convert.ToInt32(Console.ReadLine().Trim());
            for (int tItr = 0; tItr < t; tItr++)
            {
                string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');
                int n = Convert.ToInt32(firstMultipleInput[0]);
                int k = Convert.ToInt32(firstMultipleInput[1]);
                List<int> result = Permutation(n, k);
                Console.WriteLine(String.Join(" ", result));
            }
        }

        private static List<int> Permutation(int n, int k)
        {
            var smallestPermutation = new List<int>();
            if (k == 0)
            {
                for (int i = 1; i <= n; i++)
                {
                    smallestPermutation.Add(i);
                }
                return smallestPermutation;
            }

            if (n % 2 != 0) //for Odd number
            {
                smallestPermutation.Add(-1);
            }
            else // for even number
            {
                // if n % k is not 0 so it can't form group as "k" has to be added and subtracted in group
                // second condition comes when n = 12 and k=4, it doesn't form group too so n / k should also be even as in first half k will be subtracted and second half k is added
                if (n % k != 0 || (n / k) % 2 != 0)
                {
                    smallestPermutation.Add(-1);
                }
                else
                {
                    var add = true;
                    for (int i = 1; i <= n; i++)
                    {
                        if (add)
                        {
                            smallestPermutation.Add(i + k);
                        }
                        else
                        {
                            smallestPermutation.Add(i - k);
                        }
                        if (i % k == 0)
                        {
                            add = !add;
                        }
                    }
                }
            }
            
            return smallestPermutation;
        }
    }
}
