using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankCode
{
    public class BomberMan
    {
        public static void BomberManSol()
        {
            string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');
            int r = Convert.ToInt32(firstMultipleInput[0]);
            int c = Convert.ToInt32(firstMultipleInput[1]);
            int n = Convert.ToInt32(firstMultipleInput[2]);
            List<string> grid = new List<string>();
            for (int i = 0; i < r; i++)
            {
                string gridItem = Console.ReadLine();
                grid.Add(gridItem);
            }
            Console.WriteLine("------------------");
            List<string> result = BomberManFlow(n, grid);
            Console.WriteLine("------------------");
            Console.WriteLine(String.Join("\n", result));
        }

        private static List<string> BomberManFlow(int n, List<string> grid)
        {
            if (n == 1)
            {
                return grid;
            }
            if (n == 2)
            {
                for (int i = 0; i < grid.Count; i++)
                {
                    grid[i].Replace('.', 'O');
                }
                return grid;
            }
            int[,] matrix = new int[grid.Count, grid[0].Length];
            for (int i = 0; i < grid.Count; i++)
            {
                for (int j = 0; j < grid[i].Length; j++)
                {
                    if (grid[i][j] == 'O')
                    {
                        matrix[i, j] = 3;
                    }
                    if (grid[i][j] == '.')
                    {
                        matrix[i, j] = 1;
                    }
                }
            }
            for (int i = 3; i <= n; i++)
            {
                if (i % 2 != 0)
                {
                    for (int j = 0; j < matrix.GetLength(0); j++)
                    {
                        for (int k = 0; k < matrix.GetLength(1); k++)
                        {
                            if (matrix[j, k] != 0 && matrix[j, k] % 3 == 0)
                            {
                                matrix[j, k] = 0; //Self
                                if (k - 1 >= 0 && matrix[j, k - 1] % 3 != 0) //Left
                                {
                                    matrix[j, k - 1] = 0;
                                }
                                if (k + 1 < matrix.GetLength(1) && matrix[j, k + 1] % 3 != 0) //Right
                                {
                                    matrix[j, k + 1] = 0;
                                }
                                if (j - 1 >= 0 && matrix[j - 1, k] % 3 != 0) //Top
                                {
                                    matrix[j - 1, k] = 0;
                                }
                                if (j + 1 < matrix.GetLength(0) && matrix[j + 1, k] % 3 != 0) //Bottom
                                {
                                    matrix[j + 1, k] = 0;
                                }
                            }
                            else if (matrix[j, k] != 0)
                            {
                                matrix[j, k]++;
                            }
                        }
                    }
                }
                else
                {
                    for (int j = 0; j < matrix.GetLength(0); j++)
                    {
                        for (int k = 0; k < matrix.GetLength(1); k++)
                        {
                            matrix[j, k]++;
                        }
                    }
                }
            }

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                var tempStr = new StringBuilder();
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == 0)
                    {
                        tempStr.Append(".");
                    }
                    else
                    {
                        tempStr.Append("O");
                    }
                }
                grid[i] = tempStr.ToString();
            }

            return grid;
        }
        private static List<string> BomberManFlowNew(int n, List<string> grid)
        {
            if (n == 1)
            {
                return grid;
            }
            if (n % 2 == 0)
            {
                for (int i = 0; i < grid.Count; i++)
                {
                    grid[i].Replace('.', 'O');
                }
                return grid;
            }
            for (int i = 0; i < grid.Count; i++)
            {
                var tempStr = new StringBuilder();
                for (int j = 0; j < grid[0].Length; j++)
                {
                    if (grid[i][j] == 'O')
                    {
                        tempStr.Append('3');
                    }
                    else
                    {
                        tempStr.Append('O');
                    }
                }
                grid[i] = tempStr.ToString();
            }
            for (int i = 3; i < n; i++)
            {
                if (i % 2 == 0)
                {
                    for (int j = 0; j < grid.Count; j++)
                    {
                        grid[j].Replace("O", "3");
                        grid[j].Replace(".", "O");
                    }
                }
                else
                {
                    for (int j = 0; j < grid.Count; j++)
                    {
                        grid[j].Replace("3", ".");
                        grid[j].Replace("O", "3");
                    }
                }
            }
            return grid;
        }
    }
}
