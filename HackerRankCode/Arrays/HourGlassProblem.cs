using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankCode.Arrays
{
    public class HourGlassProblem
    {
        public static int HourGlassSum(int[][] arr)
        {
            if (arr.GetLength(0) < 3)
            {
                return 0;
            }
            var hourGlassSum = 0;
            var firstIter = true;
            for (int i = 1; i < arr.GetLength(0) - 1; i++)
            {
                for (int j = 1; j < arr[i-1].Length - 1; j++)
                {
                    var tempSum = arr[i - 1][j - 1] + arr[i - 1][j] + arr[i - 1][j + 1] + arr[i][j] + arr[i + 1][j - 1] + arr[i + 1][j] + arr[i + 1][j + 1];
                    if (firstIter)
                    {
                        firstIter = false;
                        hourGlassSum = tempSum;
                    }
                    else if(hourGlassSum < tempSum)
                    {
                        hourGlassSum = tempSum;
                    }
                }
                
            }
            return hourGlassSum;
        }
    }
}
