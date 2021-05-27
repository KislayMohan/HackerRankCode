using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankCode
{
    public class GridSearch
    {
        public static void GridSearchFlow()
        {
            int t = Convert.ToInt32(Console.ReadLine().Trim());
            for (int tItr = 0; tItr < t; tItr++)
            {
                string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');
                int R = Convert.ToInt32(firstMultipleInput[0]);
                int C = Convert.ToInt32(firstMultipleInput[1]);
                List<string> G = new List<string>();
                for (int i = 0; i < R; i++)
                {
                    string GItem = Console.ReadLine();
                    G.Add(GItem);
                }
                string[] secondMultipleInput = Console.ReadLine().TrimEnd().Split(' ');
                int r = Convert.ToInt32(secondMultipleInput[0]);
                int c = Convert.ToInt32(secondMultipleInput[1]);
                List<string> P = new List<string>();
                for (int i = 0; i < r; i++)
                {
                    string PItem = Console.ReadLine();
                    P.Add(PItem);
                }
                string result = SolveGridSearch(G, P);
                Console.WriteLine(result);
            }
        }

        // NOT WORKING .Difficult to get back to next element.
        private static string SolveGridSearch_NotWorking(List<string> G, List<string> P)
        {
            var patRow = 0;
            var patCol = 0;
            for (int i = 0; i < G[0].Length; i++)
            {
                foreach (var str in G)
                {
                    if (patRow < P.Count && str[i] == P[patRow][patCol])
                    {
                        patRow++;
                        continue;
                    }

                    if (patRow == P.Count)
                    {
                        break;
                    }
                    else
                    {
                        patRow = 0;
                    }
                }
                if (patRow > 0)
                {
                    patCol++;
                }
                else
                {
                    patCol = 0;
                }
                if (patCol == P[0].Length)
                {
                    return "YES";
                }
                patRow = 0;
            }

            return "NO";
        }

        private static string SolveGridSearch(List<string> G, List<string> P)
        {
            for (int i = 0; i < G.Count; i++)
            {
                var tempCounter = i;
                int j = 0;
                for (; j < P.Count; j++)
                {
                    if (G[tempCounter].Contains(P[j]))
                    {
                        tempCounter++;
                    }
                    else
                    {
                        break;
                    }
                }
                if (j == P.Count)
                {
                    return "YES";
                }
            }
            
            return "NO";
        }
    }
}
