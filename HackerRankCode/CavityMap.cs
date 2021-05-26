using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankCode
{
    public class CavityMap
    {
        public static void CavityMapFlow()
        {
            int n = Convert.ToInt32(Console.ReadLine().Trim());
            List<string> grid = new List<string>();
            for (int i = 0; i < n; i++)
            {
                string gridItem = Console.ReadLine();
                grid.Add(gridItem);
            }
            List<string> result = SolveCavityMap(grid);
            Console.WriteLine(String.Join("\n", result));
        }

        private static List<string> SolveCavityMap(List<string> grid)
        {
            for (int i = 1; i < grid.Count - 1; i++)
            {
                for (int j = 1; j < grid[0].Length - 1; j++)
                {
                    if (Convert.ToInt32(grid[i][j]) > Convert.ToInt32(grid[i - 1][j]) //compare with left
                        && Convert.ToInt32(grid[i][j]) > Convert.ToInt32(grid[i + 1][j]) //compare with right
                        && Convert.ToInt32(grid[i][j]) > Convert.ToInt32(grid[i][j - 1]) //compare with bottom
                        && Convert.ToInt32(grid[i][j]) > Convert.ToInt32(grid[i][j + 1])) //compare with top
                    {
                        var strBuilder = new StringBuilder();
                        strBuilder.Append(grid[i].Substring(0, j));
                        strBuilder.Append("X");
                        strBuilder.Append(grid[i].Substring(j + 1, grid[0].Length - j - 1));
                        grid[i] = strBuilder.ToString();
                    }
                }
            }
            return grid;
        }
    }
}
