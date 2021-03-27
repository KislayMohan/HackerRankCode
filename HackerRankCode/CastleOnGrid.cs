using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankCode
{
    public class CastleOnGrid
    {
        public static void CastleOnGridFlow()
        {
            int n = Convert.ToInt32(Console.ReadLine());
            string[] grid = new string[n];
            for (int i = 0; i < n; i++)
            {
                string gridItem = Console.ReadLine();
                grid[i] = gridItem;
            }
            string[] startXStartY = Console.ReadLine().Split(' ');
            int startX = Convert.ToInt32(startXStartY[0]);
            int startY = Convert.ToInt32(startXStartY[1]);
            int goalX = Convert.ToInt32(startXStartY[2]);
            int goalY = Convert.ToInt32(startXStartY[3]);
            int result = minimumMoves(grid, startX, startY, goalX, goalY);
        }

        public static int minimumMoves(string[] grid, int startX, int startY, int goalX, int goalY)
        {
            if (startX == goalX && startY == goalY)
            {
                return 0;
            }
            int[][] moves = new int[grid.Length][];
            for (int i = 0; i < grid.Length; i++)
            {
                moves[i] = new int[grid[0].Length];
                for (int k = 0; k < grid[0].Length; k++)
                {
                    moves[i][k] = -1;
                }
                //Array.Fill(moves[i], -1);
            }
            moves[startX][startY] = 0;
            int[] xAxisMovement = new int[4] { 0, 1, 0, -1 };
            int[] yAxisMovement = new int[4] { 1, 0, -1, 0 };
            var visitQueue = new Queue<int[]>();
            visitQueue.Enqueue(new int[2] { startX, startY });
            while (true)
            {
                var vertex = visitQueue.Dequeue();
                for (int i = 0; i < xAxisMovement.Length; i++)
                {
                    var nextX = vertex[0];
                    var nextY = vertex[1];
                    while (CanTravel(grid, nextX + xAxisMovement[i], nextY + yAxisMovement[i]))
                    {
                        nextX += xAxisMovement[i];
                        nextY += yAxisMovement[i];
                        if (nextX == goalX && nextY == goalY)
                        {
                            return moves[vertex[0]][vertex[1]] + 1;
                        }
                        if (moves[nextX][nextY] < 0)
                        {
                            moves[nextX][nextY] = moves[vertex[0]][vertex[1]] + 1;
                            visitQueue.Enqueue(new int[2] { nextX, nextY });
                        }
                    }
                }
            }
        }

        private static bool CanTravel(string[] grid, int xCoordinate, int yCoordinate)
        {
            return xCoordinate >= 0 && xCoordinate < grid.Length && yCoordinate >= 0 && yCoordinate < grid[0].Length && grid[xCoordinate][yCoordinate] == '.';
        }
    }
}
