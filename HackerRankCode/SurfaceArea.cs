using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankCode
{
    public class SurfaceArea
    {
        public static void SurfaceAreaFlow()
        {
            string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');
            int H = Convert.ToInt32(firstMultipleInput[0]);
            int W = Convert.ToInt32(firstMultipleInput[1]);
            List<List<int>> A = new List<List<int>>();
            for (int i = 0; i < H; i++)
            {
                A.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(ATemp => Convert.ToInt32(ATemp)).ToList());
            }
            int result = SurfaceAreaSolution(A);
            
            Console.WriteLine(result);
        }

        private static int SurfaceAreaSolution(List<List<int>> A)
        {
            var surfaceArea = 0;
            for (var i = 0; i < A.Count; i++)
            {
                for (var j = 0; j < A[0].Count; j++)
                {
                    surfaceArea += (A[i][j] * 4) + 2;
                    if (j >= 1) surfaceArea -= Math.Min(A[i][j - 1], A[i][j]) * 2;
                    if (i >= 1) surfaceArea -= Math.Min(A[i - 1][j], A[i][j]) * 2;
                }
            }
            return (surfaceArea);
        }
    }
}
