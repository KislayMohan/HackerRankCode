using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankCode
{
    public static class MagicSquare
    {
        public static void MagicSquareSol()
        {
            List<List<int>> s = new List<List<int>>();
            for (int i = 0; i < 3; i++)
            {
                s.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(sTemp => Convert.ToInt32(sTemp)).ToList());
            }
            int result = FormingMagicSquare(s);
            Console.WriteLine(result);
        }

        private static int FormingMagicSquare(List<List<int>> s)
        {
            var cost = 0;
            var visited = new bool[10];
            cost += Math.Abs(5 - s[1][1]);
            visited[5] = true;

            var cost82 = Math.Abs(8 - s[0][0]) + Math.Abs(2 - s[2][2]) < Math.Abs(2 - s[0][0]) + Math.Abs(8 - s[2][2]) ? Math.Abs(8 - s[0][0]) + Math.Abs(2 - s[2][2]) : Math.Abs(2 - s[0][0]) + Math.Abs(8 - s[2][2]);
            var cost64 = Math.Abs(6 - s[0][0]) + Math.Abs(4 - s[2][2]) < Math.Abs(4 - s[0][0]) + Math.Abs(6 - s[2][2]) ? Math.Abs(6 - s[0][0]) + Math.Abs(4 - s[2][2]) : Math.Abs(4 - s[0][0]) + Math.Abs(6 - s[2][2]);
            if (cost82 < cost64)
            {
                cost += cost82;
                visited[8]=true;
                visited[2]=true;
            }
            else
            {
                cost+= cost64;
                visited[6]=true;
                visited[4]=true;
            }

            if (visited[8])
            {
                cost+= Math.Abs(6 - s[0][2]) + Math.Abs(4 - s[2][0]) < Math.Abs(4 - s[0][2]) + Math.Abs(6 - s[2][0]) ? Math.Abs(6 - s[0][2]) + Math.Abs(4 - s[2][0]) : Math.Abs(4 - s[0][2]) + Math.Abs(6 - s[2][0]);
                visited[6] = true;
                visited[4] = true;
            }
            else
            {
                cost += Math.Abs(8 - s[0][2]) + Math.Abs(2 - s[2][0]) < Math.Abs(2 - s[0][2]) + Math.Abs(8 - s[2][0]) ? Math.Abs(8 - s[0][2]) + Math.Abs(2 - s[2][0]) : Math.Abs(2 - s[0][2]) + Math.Abs(8 - s[2][0]);
                visited[8] = true;
                visited[2] = true;
            }

            var cost91 = Math.Abs(9 - s[0][1]) + Math.Abs(1 - s[2][1]) < Math.Abs(1 - s[0][1]) + Math.Abs(9 - s[2][1]) ? Math.Abs(9 - s[0][1]) + Math.Abs(1 - s[2][1]) : Math.Abs(1 - s[0][1]) + Math.Abs(9 - s[2][1]);
            var cost73 = Math.Abs(7 - s[0][1]) + Math.Abs(3 - s[2][1]) < Math.Abs(3 - s[0][1]) + Math.Abs(7 - s[2][1]) ? Math.Abs(7 - s[0][1]) + Math.Abs(3 - s[2][1]) : Math.Abs(3 - s[0][1]) + Math.Abs(7 - s[2][1]);
            if (cost91 < cost73)
            {
                cost += cost91;
                visited[9] = true;
                visited[1] = true;
            }
            else
            {
                cost += cost73;
                visited[7] = true;
                visited[3] = true;
            }

            if (visited[9])
            {
                cost += Math.Abs(7 - s[1][0]) + Math.Abs(3 - s[1][2]) < Math.Abs(3 - s[1][0]) + Math.Abs(7 - s[1][2]) ? Math.Abs(7 - s[1][0]) + Math.Abs(3 - s[1][2]) : Math.Abs(3 - s[1][0]) + Math.Abs(7 - s[1][2]);
                visited[7] = true;
                visited[3] = true;
            }
            else
            {
                cost += Math.Abs(9 - s[1][0]) + Math.Abs(1 - s[1][2]) < Math.Abs(1 - s[1][0]) + Math.Abs(9 - s[1][2]) ? Math.Abs(9 - s[1][0]) + Math.Abs(1 - s[1][2]) : Math.Abs(1 - s[1][0]) + Math.Abs(9 - s[1][2]);
                visited[9] = true;
                visited[1] = true;
            }

            return cost;
        }
    }
}
