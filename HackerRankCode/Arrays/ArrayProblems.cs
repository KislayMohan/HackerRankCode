using System;
using System.Collections.Generic;
using System.Linq;

namespace HackerRankCode.Arrays
{
    public class ArrayProblems
    {
        public static int[] ReverArray(int[] input)
        {
            int[] retArray = new int[input.Length];
            for (int i = 0; i < input.Length; i++)
            {
                retArray[input.Length - i - 1] = input[i];
            }
            return retArray;
        }

        public static int[] RotateArray(int[] input, int rotation)
        {
            int[] retArray = new int[input.Length];
            for (int i = rotation; i < input.Length; i++)
            {
                retArray[i - rotation] = input[i];
            }
            for (int i = 0; i < rotation; i++)
            {
                retArray[input.Length - rotation + i] = input[i];
            }
            return retArray;
        }

        public static int[] QueryOccurence(string[] strings, string[] queries)
        {
            var queryCount = new List<int>(queries.Length);
            var strJoint = "|" + string.Join("||", strings) + "|";
            foreach (var query in queries)
            {
                var tempCount = 0;
                int i = 0;
                while ((i = strJoint.IndexOf("|" + query + "|", i)) != -1)
                {
                    i += query.Length + 1;
                    tempCount++;
                }
                queryCount.Add(tempCount);
            }
            return queryCount.ToArray();
        }

        public static int removeObstacle(int numRows, int numCols, int[,] lot)
        {
            var visited = new bool[lot.GetLength(0), lot.GetLength(1)];
            var rowsInLot = lot.GetLength(0);
            var colsInLot = lot.GetLength(1);
            if (numRows != rowsInLot || numCols != colsInLot)
            {
                return -1;
            }
            var destination = FindDestination(0, 0, numRows, numCols, 0, 9, lot, visited);

            if (destination == 0)
                return -1;
            else return destination;
        }

        public static int FindDestination(int row, int col, int rows, int cols, int hop, int val, int[,] lot, bool[,] visited)
        {
            int neigh1, neigh2, neigh3, neigh4 = -1;
            if (row >= rows - 1 || row < 0)
            {
                return -1;
            }
            if (col >= cols - 1 || col < 0)
            {
                return -1;
            }
            if (visited[row, col] || lot[row, col] == 0)
            {
                return -1;
            }
            visited[row, col] = true;
            if (col < cols - 1 && lot[row, col + 1] == val) //right
            {
                return hop + 1;
            }
            if (row < rows - 1 && lot[row + 1, col] == val) //down
            {
                return hop + 1;
            }
            if (row > 0 && lot[row - 1, col] == val) //up
            {
                return hop + 1;
            }
            if (col > 0 && lot[row, col - 1] == val) // left
            {
                return hop + 1;
            }
            neigh1 = FindDestination(row + 1, col, rows, cols, hop + 1, val, lot, visited);
            neigh2 = FindDestination(row - 1, col, rows, cols, hop + 1, val, lot, visited);
            neigh3 = FindDestination(row, col + 1, rows, cols, hop + 1, val, lot, visited);
            neigh4 = FindDestination(row, col - 1, rows, cols, hop + 1, val, lot, visited);

            var sortedHop = new SortedSet<int>();
            if (neigh1 > 0)
                sortedHop.Add(neigh1);
            if (neigh2 > 0)
                sortedHop.Add(neigh2);
            if (neigh3 > 0)
                sortedHop.Add(neigh3);
            if (neigh4 > 0)
                sortedHop.Add(neigh4);
            return sortedHop.FirstOrDefault();
        }

        // METHOD SIGNATURE BEGINS, THIS METHOD IS REQUIRED
        public int minimumTime(int numOfSubFiles, int[] files)
        {
            int totalTimeTaken = 0;
            for (int counter = 0; counter < numOfSubFiles - 1; counter++)
            {
                var reducedResult = reduce(files);
                totalTimeTaken = totalTimeTaken + reducedResult.Item1;
                files = reducedResult.Item2;
            }

            return totalTimeTaken;
        }

        private Tuple<int, int[]> reduce(int[] inputFiles)
        {
            var sortedArray = inputFiles.OrderBy(item => item);
            var sum = sortedArray.Take(2).Sum();
            var mergedArray = new int[inputFiles.Length - 1];
            mergedArray[0] = sum;
            int counter = 1;
            foreach (var item in sortedArray.Skip(2))
            {
                mergedArray[counter] = item;
                counter++;
            }

            return new Tuple<int, int[]>(sum, mergedArray);
        }
    }
}
