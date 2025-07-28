using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankCode
{
    internal class RottenOranges
    {
        public static int OrangesRotting(int[][] grid)
        {
            if (grid == null || grid.Length == 0 || grid[0].Length == 0)
                return -1;
            int rows = grid.Length;
            int cols = grid[0].Length;
            Queue<(int, int)> queue = new Queue<(int, int)>();
            int freshCount = 0;
            int minutes = 0;
            // Initialize the queue with rotten oranges and count fresh oranges
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (grid[i][j] == 2)
                    {
                        queue.Enqueue((i, j));
                    }
                    else if (grid[i][j] == 1)
                    {
                        freshCount++;
                    }
                }
            }
            // Directions for adjacent cells (up, down, left, right)
            int[][] directions = new int[][]
            {
                new int[] { -1, 0 }, // Up
                new int[] { 1, 0 },  // Down
                new int[] { 0, -1 }, // Left
                new int[] { 0, 1 }   // Right
            };
            // BFS to rot the oranges
            while (queue.Count > 0 && freshCount > 0)
            {
                int size = queue.Count;
                for (int i = 0; i < size; i++)
                {
                    var (x, y) = queue.Dequeue();
                    foreach (var dir in directions)
                    {
                        int newX = x + dir[0];
                        int newY = y + dir[1];
                        if (newX >= 0 && newX < rows && newY >= 0 && newY < cols && grid[newX][newY] == 1)
                        {
                            grid[newX][newY] = 2; // Rot the orange
                            freshCount--; // Decrease fresh count
                            queue.Enqueue((newX, newY)); // Add to queue
                        }
                    }
                }
                minutes++; // Increment minutes after processing one level of BFS
            }
            return freshCount == 0 ? minutes : -1; // If all fresh oranges are rotted, return minutes; otherwise return -1
        }
    }
}
