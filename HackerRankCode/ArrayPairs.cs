using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankCode
{
    public class ArrayPairs
    {
        public static void ArrayPairsInput()
        {
            int arrCount = Convert.ToInt32(Console.ReadLine());
            int[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => Convert.ToInt32(arrTemp));
            long result = SolveNew(arr);
            Console.WriteLine(result);
        }

        private static long Solve(int[] arr)
        {
            long pairCount = 0;
            for (int i = 0; i < arr.Count() - 1; ++i)
            {
                int max = arr[i];
                for (int j = i + 1; j < arr.Count(); ++j)
                {
                    if (arr[j] > max)
                    {
                        max = arr[j];
                    }
                    if ((long)arr[i] * (long)arr[j] <= max)
                    {
                        ++pairCount;
                    }
                }
            }
            return pairCount;
        }

        private static long SolveNew(int[] arr)
        {
            var newList = arr.ToList();
            newList.Sort();
            Console.WriteLine("New list: {0}", string.Join(", ", newList));
            long pairCount = 0;
            for (int i = 0; i < newList.Count() - 1; ++i)
            {
                for (int j = i + 1; j < newList.Count(); ++j)
                {
                    if ((long)newList[i] * (long)newList[j] <= newList[j])
                    {
                        Console.WriteLine(i + ", " + j);
                        ++pairCount;
                    }
                }
            }
            return pairCount;
        }
    }
}
