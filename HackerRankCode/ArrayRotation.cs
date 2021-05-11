using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankCode
{
    public class ArrayRotation
    {
        public static void ArrayRotationFlow()
        {
            string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');
            int n = Convert.ToInt32(firstMultipleInput[0]);
            int d = Convert.ToInt32(firstMultipleInput[1]);
            List<int> a = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(aTemp => Convert.ToInt32(aTemp)).ToList();
            List<int> result = RotLeft(a, d);
            Console.WriteLine(String.Join(" ", result));
        }

        private static List<int> RotLeft(List<int> a, int d)
        {
            var result = new int[a.Count];
            for (int i = 0; i < a.Count; i++)
            {
                var index = i - d;
                if (index < 0)
                {
                    index = a.Count + index;
                }
                result[index] = a[i];
            }
            return result.ToList();
        }
    }
}
