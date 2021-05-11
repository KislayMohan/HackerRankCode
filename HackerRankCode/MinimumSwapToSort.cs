using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankCode
{
    public class MinimumSwapToSort
    {
        public static void MinimumSwapToSortFlow()
        {
            int n = Convert.ToInt32(Console.ReadLine());
            int[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => Convert.ToInt32(arrTemp));
            int res = MinimumSwaps(arr);
            Console.WriteLine(res);
        }

        private static int MinimumSwaps(int[] arr)
        {
            var visited = new bool[arr.Length];
            var swapCount = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (visited[i])
                {
                    continue;
                }
                visited[i] = true;
                if (i + 1 == arr[i])
                {
                    continue;
                }
                else
                {
                    var chainNode = arr[i];
                    while (!visited[chainNode - 1])
                    {
                        visited[chainNode - 1] = true;
                        chainNode = arr[chainNode - 1];
                        swapCount++;
                    }
                }
            }

            return swapCount;
        }
    }
}
